using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPU.Emulation;

namespace KPU.ConsoleEmulator
{
    public class Program
    {
        private static Processor cpu;
        
        public static void Main(string[] args)
        {
            CPUExecution context = CPUExecution.MORE_INSTRUCTIONS_AVAILABLE;
            string outC, outD;
            char keyPressed = ' ';

            LoadBinaryCode();

            while (context != CPUExecution.FINISHED)
            {
                context = cpu.SingleStep(out outC, out outD);

                if (context == CPUExecution.IN_A)
                {
                    // Pass the read character from the console into the CPU Input Port A...
                    cpu.XL.SetBits(Convert.ToByte(keyPressed));
                }

                if (context == CPUExecution.IN_B)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    keyPressed = key.KeyChar;

                    // Set the Ready Bit on Input Port B when we have read the character from the console
                    cpu.XL.SetBits(1);
                }

                if (context == CPUExecution.INTERRUPT)
                {
                    // We have triggered a software based interrupt...
                    switch (cpu.XL.GetInt())
                    {
                        case 1:
                            {
                                HandleHardDiskInterrupt();
                                break;
                            }
                        default:
                            throw new ArgumentException("Invalid Interrupt Number!");
                    }

                    // After we have handled the interrupt, we continue program execution by incrementing the Program Counter...
                    cpu.ProgramCounter.Increment();
                    continue;
                }

                if (outC != string.Empty)
                    Console.Write(Convert.ToChar(Helper.GetByte(outC)));
            }

            Console.WriteLine();
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        /// <summary>
        /// Interrupt 1 is used for accessing hard disks.
        ///
        /// The parameters are passed in through the following registers:
        /// => D Register: Requested service:
        ///                => 1: Read Disk Sector
        ///                => 2: Write Disk Sector
        /// => E Register: LBA Sector Index (Sector Size is 512 bytes)
        /// => F Register: Sectors to read/write count
        /// => Y Register: Source/Destination Memory Address
        /// </summary>
        private static void HandleHardDiskInterrupt()
        {
            int SECTOR_SIZE = 512;

            using (StreamReader reader = new StreamReader(@"Z:\Klaus\OneDrive\KPU\VirtualDisk.img"))
            {    
                // int sectorsToRead = cpu.F.GetInt();
                // int startSector = cpu.E.GetInt();
                // int startMemoryAddress = cpu.Y.GetInt();
                int sectorsToRead = 1;
                int startSector = 0;
                int startMemoryAddress = 128;
                int i = 0;

                char[] buffer = new char[sectorsToRead * SECTOR_SIZE];
                reader.ReadBlock(buffer, startSector * SECTOR_SIZE, sectorsToRead * SECTOR_SIZE);

                foreach (char c in buffer)
                {
                    cpu.WriteSRAMValue(startMemoryAddress + i, (byte)c);
                    i++;
                }
            }
        }

        private static void LoadBinaryCode()
        {
            StreamReader reader = new StreamReader(@"Z:\Klaus\OneDrive\KPU\BinaryCode.bin");
            List<byte> opcodes = new List<byte>();
            cpu = new Processor();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                // Bypass comments...
                if (!line.StartsWith(";;") && !line.Contains("; DATA"))
                {
                    opcodes.Add(Helper.GetByte(line.Substring(17, 8)));
                }
                else if (line.Contains("; DATA"))
                    InitializeSRAM(line);
            }

            reader.Close();
            cpu.LoadProgram(0, opcodes.ToArray<byte>());
        }

        private static void InitializeSRAM(string Line)
        {
            BitArray b = new BitArray(16);
            b.Set(0, Line.Substring(15, 1) == "1");
            b.Set(1, Line.Substring(14, 1) == "1");
            b.Set(2, Line.Substring(13, 1) == "1");
            b.Set(3, Line.Substring(12, 1) == "1");
            b.Set(4, Line.Substring(11, 1) == "1");
            b.Set(5, Line.Substring(10, 1) == "1");
            b.Set(6, Line.Substring(9, 1) == "1");
            b.Set(7, Line.Substring(8, 1) == "1");
            b.Set(8, Line.Substring(7, 1) == "1");
            b.Set(9, Line.Substring(6, 1) == "1");
            b.Set(10, Line.Substring(5, 1) == "1");
            b.Set(11, Line.Substring(4, 1) == "1");
            b.Set(12, Line.Substring(3, 1) == "1");
            b.Set(13, Line.Substring(2, 1) == "1");
            b.Set(14, Line.Substring(1, 1) == "1");
            b.Set(15, Line.Substring(0, 1) == "1");
            int[] address = new int[1];
            b.CopyTo(address, 0);

            b = new BitArray(8);
            b.Set(0, Line.Substring(24, 1) == "1");
            b.Set(1, Line.Substring(23, 1) == "1");
            b.Set(2, Line.Substring(22, 1) == "1");
            b.Set(3, Line.Substring(21, 1) == "1");
            b.Set(4, Line.Substring(20, 1) == "1");
            b.Set(5, Line.Substring(19, 1) == "1");
            b.Set(6, Line.Substring(18, 1) == "1");
            b.Set(7, Line.Substring(17, 1) == "1");
            byte[] data = new byte[1];
            b.CopyTo(data, 0);

            // Initialize the SRAM memory
            cpu.WriteSRAMValue(address[0], data[0]);
        }
    }
}
