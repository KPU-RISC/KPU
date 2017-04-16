using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.Collections;
using System.Diagnostics;

namespace KPU_Assembler
{
    public class Program
    {
        private static string rootFolder = @"c:\Github\KPU\Assembler\";
        private static string outputFolder = rootFolder + @"Output\";

        private static void Main(string[] args)
        {
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            RunAssembler(rootFolder + @"AssemblyCode\INT.asm");
           
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        public static string IntToBinary(int IntValue, int Size)
        {
            BitArray b = new BitArray(new int[] { IntValue });
            int[] bits = b.Cast<bool>().Select(bit => bit ? 1 : 0).ToArray();
            string bitValue = string.Empty;
            int i = 0;

            foreach (int bit in bits)
            {
                if (i == Size)
                    break;

                bitValue += bit;
                i++;
            }

            return new string(bitValue.Reverse().ToArray());
        }

        private static string FloatingPointToBinary(float value)
        {
            byte[] raw = BitConverter.GetBytes(value);
            BitArray b = new BitArray(raw);

            int[] bits = b.Cast<bool>().Select(bit => bit ? 1 : 0).ToArray();
            string bitValue = string.Empty;
            int i = 0;

            foreach (int bit in bits)
            {
                if (i == 32)
                    break;

                bitValue += bit;
                i++;
            }

            return new string(bitValue.Reverse().ToArray());
        }

        public static void RunAssembler(string AssemblyFile)
        {
            RunPreProcessor(AssemblyFile);
            GenerateLowLevelAssemblyCode();
            GenerateBinaryCode();
            GenerateArduinoLoadFile();
            CheckForDuplicateMemoryAddresses();
            GenerateMapFile();
        }

        private static void GenerateArduinoLoadFile()
        {
            using (System.IO.StreamReader inputFile = new System.IO.StreamReader(outputFolder + "BinaryCode.bin"))
            {
                List<string> programLines = ReadProgram(inputFile);

                using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(outputFolder + "Arduino.c"))
                {
                    outputFile.WriteLine("void AssemblyCodeLoader()");
                    outputFile.WriteLine("{");

                    foreach (string line in programLines)
                    {
                        if (line.StartsWith(";;"))
                            outputFile.Write("\t// " + line + Environment.NewLine);
                        else
                        {
                            string memoryAddress = line.Substring(0, 16);
                            string opcode = line.Substring(17, 8);
                            string comment = line.Substring(28);

                            outputFile.Write("\t");
                            outputFile.Write("SetSRAM(0b");
                            outputFile.Write(memoryAddress);
                            outputFile.Write(", 0b");
                            outputFile.Write(opcode);
                            outputFile.Write("); // ");
                            outputFile.Write(comment);
                            outputFile.Write(Environment.NewLine);
                        }
                    }

                    outputFile.WriteLine("}");
                }
            }
        }

        private static void GenerateASCIIOutputFile()
        {
            using (System.IO.StreamReader file = new System.IO.StreamReader(outputFolder + "OutputData.bin"))
            {
                List<string> outputLines = ReadProgram(file);
                string result = string.Empty;

                foreach (string line in outputLines)
                {
                    if (line == "00001101")
                        result += Environment.NewLine;
                    else
                    {
                        int number = Convert.ToInt32(line, 2);
                        result += (char)number;
                    }
                }

                using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(outputFolder + "OutputData.txt"))
                {
                    outputFile.Write(result);
                }
            }
        }

        private static void GenerateMapFile()
        {
            using (System.IO.StreamReader file = new System.IO.StreamReader(outputFolder + "BinaryCode.bin"))
            {
                List<string> programLines = ReadProgram(file);
                List<string> functionNames = FindFunctionNames(programLines);

                using (System.IO.StreamWriter fileMap = new System.IO.StreamWriter(outputFolder + "BinaryCode.map"))
                {
                    foreach (string function in functionNames)
                    {
                        int index = programLines.IndexOf(function) + 1;

                        for (int i = index; i < programLines.Count; i++)
                        {
                            if (programLines[i].Trim() == ";; END RET")
                            {
                                string endFunction = programLines[i - 1];
                                string startAddress = function.Substring(0, 16);
                                string endAddress = endFunction.Substring(0, 16);
                                string functionName = function.Substring(32);

                                fileMap.WriteLine(startAddress + " " + endAddress + " " + functionName);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static List<string> FindFunctionNames(List<string> ProgramLines)
        {
            List<string> result = new List<string>();

            foreach (string line in ProgramLines)
            {
                if (line.Contains("NOP:_"))
                    result.Add(line);
            }

            return result;
        }

        private static void RunPreProcessor(string InputFile)
        {
            using (System.IO.StreamReader file = new System.IO.StreamReader(InputFile))
            {
                List<string> programLines = ReadProgram(file);
                List<string> includeFiles = FindIncludeFiles(programLines);
                List<string> dataEntries = new List<string>();

                using (System.IO.StreamWriter filePreProcessor = new System.IO.StreamWriter(outputFolder + "PreProcessor.asm"))
                {
                    // Write out the original file
                    foreach (string line in programLines)
                    {
                        // We skip the Include Files and the Data Entries. They will be added at the very end of the generated file.
                        if (!line.StartsWith("#INCLUDE") && !line.StartsWith("DATA "))
                            filePreProcessor.WriteLine(line);

                        // Save the Data Entry...
                        if (line.StartsWith("DATA "))
                            dataEntries.Add(line);
                    }

                    filePreProcessor.WriteLine();

                    // Process the Include Files...
                    foreach (string inc in includeFiles)
                    {
                        try
                        {
                            // Appening every include file at the end of the newly written file
                            using (System.IO.StreamReader includeFileReader = new System.IO.StreamReader(rootFolder + @"AssemblyCode\" + inc))
                            {
                                List<string> programLinesIncludeFile = ReadProgram(includeFileReader);

                                foreach (string line in programLinesIncludeFile)
                                {
                                    filePreProcessor.WriteLine(line);
                                }
                            }
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("Include file " + inc + " was not found!");
                        }
                    }

                    filePreProcessor.WriteLine();

                    // Process the Data Entries
                    foreach (string data in dataEntries)
                    {
                        filePreProcessor.WriteLine(data);
                    }
                }
            }
        }

        private static List<string> FindIncludeFiles(List<string> ProgramLines)
        {
            List<string> includeFiles = new List<string>();
            List<string> finalFileList = new List<string>();

            foreach (string line in ProgramLines)
            {
                if (line.StartsWith("#INCLUDE "))
                    includeFiles.Add(line.Substring(10));
            }

            foreach (string inc in includeFiles)
            {
                finalFileList.Add(inc.Substring(0, inc.IndexOf("\"")));
            }

            return finalFileList;
        }

        private static void GenerateLowLevelAssemblyCode()
        {
            using (StreamReader preProcesserReader = new StreamReader(outputFolder + "PreProcessor.asm"))
            {
                AntlrInputStream input = new AntlrInputStream(preProcesserReader);
                HighLevelAssemblyLexer lexer = new HighLevelAssemblyLexer(input);
                CommonTokenStream tokens = new CommonTokenStream(lexer);
                HighLevelAssemblyParser parser = new HighLevelAssemblyParser(tokens);

                IParseTree tree = parser.program();

                HighLevelAssemblyVisitor<string> eval = new HighLevelAssemblyVisitor<string>();
                eval.Visit(tree);

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(outputFolder + "Assembly_LowLevel.asm"))
                {
                    foreach (string line in eval.Assembly)
                    {
                        file.WriteLine(line);
                    }
                }   
            }
        }

        private static void GenerateBinaryCode()
        {
            using (StreamReader lowLevelAssemblyReader = new StreamReader(outputFolder + "Assembly_LowLevel.asm"))
            {
                AntlrInputStream input = new AntlrInputStream(lowLevelAssemblyReader);
                LowLevelAssemblyLexer lexer = new LowLevelAssemblyLexer(input);
                CommonTokenStream tokens = new CommonTokenStream(lexer);
                LowLevelAssemblyParser parser = new LowLevelAssemblyParser(tokens);

                IParseTree tree = parser.program();

                LowLevelAssemblyVisitor<string> eval = new LowLevelAssemblyVisitor<string>();
                eval.Visit(tree);

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(outputFolder + "BinaryCode_1stPass.bin"))
                {
                    int i = 0;

                    foreach (string line in eval.Assembly)
                    {
                        if (!line.StartsWith(";;"))
                        {
                            BitArray b = new BitArray(new int[] { i });
                            int[] bits = b.Cast<bool>().Select(bit => bit ? 1 : 0).ToArray();

                            string memoryAddress = CreateMemoryAddress(bits);

                            file.WriteLine(memoryAddress + line);
                            i++;
                        }
                        else
                            file.WriteLine(line);
                    }
                }
            }

            // The following code changes the address placeholders to the correct target addresses of the jump locations
            using (System.IO.StreamReader file = new System.IO.StreamReader(outputFolder + "BinaryCode_1stPass.bin"))
            {
                List<string> programLines = ReadProgram(file);
                List<string> jumps = FindJumps(programLines);

                // Process each individual jump
                foreach (string jump in jumps)
                {
                    string[] parts = jump.Split(':');
                    string label = parts[1].Trim();

                    string jumpAddress = FindJumpAddress(label, programLines);
                    programLines = FixJumpAddress(jumpAddress, label, programLines);
                }

                List<string> dataEntries = FindDataEntries(programLines);

                foreach (string dataEntry in dataEntries)
                {
                    string comment = dataEntry.Split(';')[1];
                    string[] parts = comment.Split(',');

                    string memoryAddress = parts[0].Substring(parts[0].IndexOf("DATA") + 5, 16);
                    string data = parts[1].Substring(1, parts[1].Length - 2);
                    programLines = FixDataEntries(memoryAddress, data, programLines);
                }

                using (System.IO.StreamWriter finalFile = new System.IO.StreamWriter(outputFolder + "BinaryCode.bin"))
                {
                    foreach (string line in programLines)
                    {
                        finalFile.WriteLine(line);
                    }
                }
            }
        }

        private static void CheckForDuplicateMemoryAddresses()
        {
            // The following code changes the address placeholders to the correct target addresses of the jump locations
            using (System.IO.StreamReader file = new System.IO.StreamReader(outputFolder + "BinaryCode.bin"))
            {
                List<string> programLines = ReadProgram(file);
                Hashtable ht = new Hashtable();

                foreach (string line in programLines)
                {
                    try
                    {
                        if (!line.StartsWith(";;"))
                            ht.Add(line.Substring(0, 16), line);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Duplicate Memory Address: " + line);
                    }
                }
            }
        }

        private static List<string> FindDataEntries(List<string> ProgramLines)
        {
            List<string> dataEntries = new List<string>();

            foreach (string line in ProgramLines)
            {
                if (line.Contains("DATA"))
                {
                    if (!line.StartsWith(";;"))
                        dataEntries.Add(line);
                }
            }

            return dataEntries;
        }

        private static List<string> FixDataEntries(string MemoryAddress, string Data, List<string> programLines)
        {
            List<string> newProgramLines = new List<string>();

            foreach (string line in programLines)
            {
                if (line.Contains(MemoryAddress))
                {
                    newProgramLines.Add(MemoryAddress + " " + Data + " ; DATA " + MemoryAddress + "b, " + Data + "b");
                }
                else
                {
                    newProgramLines.Add(line);
                }
            }

            return newProgramLines;
        }

        /// <summary>
        /// Changes the jump address for the specified label to the provided jump address
        /// </summary>
        /// <param name="jumpAddress"></param>
        /// <param name="programLines"></param>
        private static List<string> FixJumpAddress(string jumpAddress, string jumpLabel, List<string> programLines)
        {
            List<string> newProgramLines1 = new List<string>();
            List<string> newProgramLines2 = new List<string>();
            List<string> newProgramLines3 = new List<string>();
            List<string> newProgramLines4 = new List<string>();
            string newLine = string.Empty;
            int i = 0;

            // Now we fix the bits 7 - 4 of the jump address
            foreach (string line in programLines)
            {
                if (line.Contains(":" + jumpLabel + "_LN1"))
                {
                    newLine = line.Replace(" 11101111", " 1110" + jumpAddress.Substring(12, 4));
                    newProgramLines1.Add(newLine);
                }
                else
                {
                    newProgramLines1.Add(line);
                }

                i++;
            }

            if (newLine == string.Empty)
                throw new Exception("Label \"" + jumpLabel + "_LN1\" not found");

            newLine = string.Empty;

            // Now we fix the bits 3 - 0 of the jump address
            i = 0;

            foreach (string line in newProgramLines1)
            {
                if (line.Contains(":" + jumpLabel + "_LN2"))
                {
                    newLine = line.Replace(" 11111111", " 1111" + jumpAddress.Substring(8, 4));
                    newProgramLines2.Add(newLine);
                }
                else
                {
                    newProgramLines2.Add(line);
                }

                i++;
            }

            if (newLine == string.Empty)
                throw new Exception("Label \"" + jumpLabel + "_LN2\" not found");

            newLine = string.Empty;

            // Now we fix the bits 15 - 12 of the jump address
            i = 0;

            foreach (string line in newProgramLines2)
            {
                if (line.Contains(":" + jumpLabel + "_HN1"))
                {
                    newLine = line.Replace(" 11101111", " 1110" + jumpAddress.Substring(4, 4));
                    newProgramLines3.Add(newLine);
                }
                else
                {
                    newProgramLines3.Add(line);
                }

                i++;
            }

            if (newLine == string.Empty)
                throw new Exception("Label \"" + jumpLabel + "_HN1\" not found");

            newLine = string.Empty;

            // Now we fix the bits 11 - 8 of the jump address
            i = 0;

            foreach (string line in newProgramLines3)
            {
                if (line.Contains(":" + jumpLabel + "_HN2"))
                {
                    newLine = line.Replace(" 11111111", " 1111" + jumpAddress.Substring(0, 4));
                    newProgramLines4.Add(newLine);
                }
                else
                {
                    newProgramLines4.Add(line);
                }

                i++;
            }

            if (newLine == string.Empty)
                throw new Exception("Label \"" + jumpLabel + "_HN2\" not found");

            return newProgramLines4;
        }

        private static List<string> ReadProgram(StreamReader file)
        {
            List<string> lines = new List<string>();

            while (!file.EndOfStream)
            {
                lines.Add(file.ReadLine());
            }

            return lines;
        }

        private static List<string> FindJumps(List<string> ProgramLines)
        {
            List<string> jumps = new List<string>();

            foreach (string line in ProgramLines)
            {
                if (line.Contains("JMP") || line.Contains("JZ") || line.Contains("JNZ") || line.Contains("JNS") || line.Contains("JNC"))
                {
                    if (!line.StartsWith(";;"))
                        jumps.Add(line);
                }
            }

            return jumps;
        }

        /// <summary>
        /// Returns the memory address of the specified jump label.
        /// </summary>
        /// <param name="JumpLabel"></param>
        /// <param name="ProgramLines"></param>
        /// <returns></returns>
        private static string FindJumpAddress(string JumpLabel, List<string> ProgramLines)
        {
            foreach (string line in ProgramLines)
            {
                if (line.Contains("NOP:" + JumpLabel))
                    return line.Substring(0, 16);
            }

            throw new Exception("Jump Label \"" + JumpLabel + "\" not found!");
        }

        /// <summary>
        /// Creates a 16-bit long memory address.
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        private static string CreateMemoryAddress(int[] bits)
        {
            string memoryAddress = string.Empty;
            string memoryAddressNew = string.Empty;
            int i = 0;

            foreach (int bit in bits)
            {
                if (i == 16)
                    break;

                memoryAddress += bit.ToString();
                i++;
            }

            for (int j = memoryAddress.Length - 1; j >= 0; j--)
            {
                memoryAddressNew += memoryAddress[j];
            }

            return memoryAddressNew + " ";
        }
    }
}
