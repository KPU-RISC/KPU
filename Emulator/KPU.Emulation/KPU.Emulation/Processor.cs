using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU.Emulation
{
    /// <summary>
    /// Implements the emulation of the 8-bit RISC based KPU processor.
    /// </summary>
    public class Processor
    {
        /// <summary>
        /// Reference to the RAM of the processor.
        /// </summary>
        private Memory ram;

        /// <summary>
        /// Stores all active breakpoint addresses.
        /// </summary>
        private List<string> breakpointAddresses;

        /// <summary>
        /// The Program Counter.
        /// </summary>
        private Register16 programCounter;

        /// <summary>
        /// The current Instruction.
        /// </summary>
        private InstructionRegister instruction;

        /// <summary>
        /// 1st input parameter to the ALU operation.
        /// </summary>
        private Register a;

        /// <summary>
        /// 2nd input parameter to the ALU operation.
        /// </summary>
        private Register b;

        /// <summary>
        /// The result of the ALU operation.
        /// </summary>
        private Register c;

        /// <summary>
        /// General Purpose Register D.
        /// </summary>
        private Register d;

        /// <summary>
        /// General Purpose Register E.
        /// </summary>
        private Register e;

        /// <summary>
        /// General Purpose Register F.
        /// </summary>
        private Register f;

        /// <summary>
        /// General Purpose Register G.
        /// </summary>
        private Register g;

        /// <summary>
        /// General Purpose Register H.
        /// </summary>
        private Register h;

        /// <summary>
        /// General Purpose Register XL.
        /// </summary>
        private Register xl;

        /// <summary>
        /// General Purpose Register XH.
        /// </summary>
        private Register xh;

        /// <summary>
        /// Flags Register.
        /// </summary>
        private Register flags;

        /// <summary>
        /// FlagsSaved Register.
        /// </summary>
        private Register flagsSaved;

        private Register16 m;

        private Register16 j;

        private Register16 sp;

        private Register16 bp;

        private Register16 y;

        private Register16 z;

        /// <summary>
        /// Individual Carry Flags
        /// </summary>
        private bool carryADD;
        private bool carrySUB;
        private bool carrySHL;
        private bool carrySHR;

        /// <summary>
        /// The Program Counter.
        /// </summary>
        public Register16 ProgramCounter
        {
            get { return programCounter; }
        }

        /// <summary>
        /// The current value of the Instruction register.
        /// </summary>
        public InstructionRegister Instruction
        {
            get { return instruction; }
        }

        /// <summary>
        /// ALU A input.
        /// </summary>
        public Register A
        {
            get { return a; }
        }

        /// <summary>
        /// ALU B input.
        /// </summary>
        public Register B
        {
            get { return b; }
        }

        /// <summary>
        /// ALU C output.
        /// </summary>
        public Register C
        {
            get { return c; }
        }

        /// <summary>
        /// The current value of the D register.
        /// </summary>
        public Register D
        {
            get { return d; }
        }

        /// <summary>
        /// The current value of the E register.
        /// </summary>
        public Register E
        {
            get { return e; }
        }

        /// <summary>
        /// The current value of the F register.
        /// </summary>
        public Register F
        {
            get { return f; }
        }

        /// <summary>
        /// The current value of the G register.
        /// </summary>
        public Register G
        {
            get { return g; }
        }

        /// <summary>
        /// The current value of the H register.
        /// </summary>
        public Register H
        {
            get { return h; }
        }

        /// <summary>
        /// The current value of the XL register.
        /// </summary>
        public Register XL
        {
            get { return xl; }
        }

        /// <summary>
        /// The current value of the XH register.
        /// </summary>
        public Register XH
        {
            get { return xh; }
        }

        /// <summary>
        /// The current value of the Flags register.
        /// </summary>
        public Register Flags
        {
            get { return flags; }
        }

        /// <summary>
        /// The current value of the FlagsSaved register.
        /// </summary>
        public Register FlagsSaved
        {
            get { return flagsSaved; }
        }

        public Register16 X
        {
            get
            {
                Register16 x = new Register16();

                // Upper Byte
                x.Value[15] = xh.Value[7];
                x.Value[14] = xh.Value[6];
                x.Value[13] = xh.Value[5];
                x.Value[12] = xh.Value[4];
                x.Value[11] = xh.Value[3];
                x.Value[10] = xh.Value[2];
                x.Value[9] = xh.Value[1];
                x.Value[8] = xh.Value[0];

                // Lower Byte
                x.Value[7] = xl.Value[7];
                x.Value[6] = xl.Value[6];
                x.Value[5] = xl.Value[5];
                x.Value[4] = xl.Value[4];
                x.Value[3] = xl.Value[3];
                x.Value[2] = xl.Value[2];
                x.Value[1] = xl.Value[1];
                x.Value[0] = xl.Value[0];

                return x;
            }
            set
            {
                xh.Value[7] = value.Value[15];
                xh.Value[6] = value.Value[14];
                xh.Value[5] = value.Value[13];
                xh.Value[4] = value.Value[12];
                xh.Value[3] = value.Value[11];
                xh.Value[2] = value.Value[10];
                xh.Value[1] = value.Value[9];
                xh.Value[0] = value.Value[8];

                xl.Value[7] = value.Value[7];
                xl.Value[6] = value.Value[6];
                xl.Value[5] = value.Value[5];
                xl.Value[4] = value.Value[4];
                xl.Value[3] = value.Value[3];
                xl.Value[2] = value.Value[2];
                xl.Value[1] = value.Value[1];
                xl.Value[0] = value.Value[0];
            }
        }

        public Register16 M
        {
            get { return m; }
        }

        public Register16 J
        {
            get { return j; }
        }

        public Register16 SP
        {
            get { return sp; }
        }

        public Register16 BP
        {
            get { return bp; }
        }

        public Register16 Y
        {
            get { return y; }
        }

        public Register16 Z
        {
            get { return z; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Processor()
        {
            // Initialize the RAM with 64K
            ram = new Memory(256 * 256);

            // Initialize the internal Registers
            instruction = new InstructionRegister();
            programCounter = new Register16();

            // Initialize the ALU Registers
            a = new Register();
            b = new Register();
            c = new Register();

            // Initialize the 8-bit General Purpose Registers
            d = new Register();
            e = new Register();
            f = new Register();
            g = new Register();
            h = new Register();
            xl = new Register();
            xh = new Register();

            // Initialize the 16-bit General Purpose Registers
            m = new Register16();
            j = new Register16();
            sp = new Register16();
            bp = new Register16();
            y = new Register16();
            z = new Register16();

            // Initialize the Flags Register
            flags = new Register();
            flagsSaved = new Register();

            // Initialize the breakpoint Array
            breakpointAddresses = new List<string>();

            // Initialize the individual Carry Flags
            carryADD = false;
            carrySUB = false;
            carrySHL = false;
            carrySHR = false;
        }

        /// <summary>
        /// Loads the given program into the memory of the CPU.
        /// </summary>
        /// <param name="Offset"></param>
        /// <param name="Program"></param>
        public void LoadProgram(int Offset, byte[] Program)
        {
            ram.LoadProgram(Offset, Program);
        }

        /// <summary>
        /// Writes a value into the SRAM.
        /// </summary>
        /// <param name="Address"></param>
        /// <param name="Data"></param>
        public void WriteSRAMValue(int Address, byte Data)
        {
            ram.WriteValue(Address, Data);
        }

        /// <summary>
        /// Loads a value from the SRAM.
        /// </summary>
        /// <param name="Address"></param>
        /// <returns></returns>
        public byte LoadSRAMValue(int Address)
        {
            return ram.ReadValue(Address);
        }

        public string[] DumpMemory(int StartMemoryAddress)
        {
            string[] result = new string[17];
            result[0] = "0x" + StartMemoryAddress.ToString("X4");

            for (int i = 0; i < 16; i++)
            {
                byte value = ram.ReadValue(StartMemoryAddress + i);
                string c = char.ConvertFromUtf32((int)value);

                if ((int)value == 0)
                    c = "??";

                result[i + 1] = "0x" + value.ToString("X2") + " (" + c + ")";
            }

            return result;
        }

        /// <summary>
        /// Starts with the CPU execution.
        /// </summary>
        public void Execute()
        {
            CPUExecution executionContext = CPUExecution.MORE_INSTRUCTIONS_AVAILABLE;
            string OutputPortC = string.Empty;
            string OutputPortD = string.Empty;

            while (executionContext == CPUExecution.MORE_INSTRUCTIONS_AVAILABLE)
            {
                executionContext = ExecuteNextInstruction(out OutputPortC, out OutputPortD);
            }
        }

        /// <summary>
        /// Executes the next CPU instruction.
        /// </summary>
        public CPUExecution SingleStep(out string OutputPortC, out string OutputPortD)
        {
            return ExecuteNextInstruction(out OutputPortC, out OutputPortD);
        }

        /// <summary>
        /// Returns a flag if the current operation is an ALU operation.
        /// </summary>
        /// <returns></returns>
        public bool IsALUOperation()
        {
            return instruction.Value[7] && !instruction.Value[6] && !instruction.Value[5] && !instruction.Value[4];
        }

        /// <summary>
        /// Adds a new breakpoint.
        /// </summary>
        /// <param name="BreakpointAddress"></param>
        public void SetBreakpoint(string BreakpointAddress)
        {
            breakpointAddresses.Add(BreakpointAddress);
        }

        /// <summary>
        /// Removes an existing breakpoint
        /// </summary>
        /// <param name="BreakpointAddress"></param>
        public void RemoveBreakpoint(string BreakpointAddress)
        {
            if (breakpointAddresses.Contains(BreakpointAddress))
                breakpointAddresses.Remove(BreakpointAddress);
        }

        /// <summary>
        /// Executes the next Instruction and increments the Program Counter.
        /// </summary>
        private CPUExecution ExecuteNextInstruction(out string OutputPortC, out string OutputPortD)
        {
            bool incrementProgramCounter = true;
            OutputPortC = string.Empty;
            OutputPortD = string.Empty;

            // Check if we are at a breakpoint
            if (!breakpointAddresses.Contains(programCounter.GetString()))
            {
                // Fetch the current instruction from the RAM
                instruction.SetBits(ram.ReadValue(programCounter.GetInt()));

                switch (instruction.GetOpCode())
                {
                    case OpCode.HLT:
                        {
                            // We have finished the end of the program execution
                            return CPUExecution.FINISHED;
                        }
                    case OpCode.INT:
                        {
                            // We have to raise an software based interrupt...
                            return CPUExecution.INTERRUPT;
                        } 
                    case OpCode.SET_A:
                        {
                            a = new Register();

                            // Extract the lower Nibble and store it in A
                            a.SetBit(3, Helper.IsBitSet(instruction.GetByte(), 3));
                            a.SetBit(2, Helper.IsBitSet(instruction.GetByte(), 2));
                            a.SetBit(1, Helper.IsBitSet(instruction.GetByte(), 1));
                            a.SetBit(0, Helper.IsBitSet(instruction.GetByte(), 0));
                            break;
                        }
                    case OpCode.SET_B:
                        {
                            b = new Register();

                            // Extract the lower Nibble and store it in B
                            b.SetBit(3, Helper.IsBitSet(instruction.GetByte(), 3));
                            b.SetBit(2, Helper.IsBitSet(instruction.GetByte(), 2));
                            b.SetBit(1, Helper.IsBitSet(instruction.GetByte(), 1));
                            b.SetBit(0, Helper.IsBitSet(instruction.GetByte(), 0));
                            break;
                        }
                    case OpCode.MOV8:
                        {
                            c = new Register();

                            // Upper Nibble
                            c.SetBit(7, b.Value[3]);
                            c.SetBit(6, b.Value[2]);
                            c.SetBit(5, b.Value[1]);
                            c.SetBit(4, b.Value[0]);

                            // Lower Nibble
                            c.SetBit(3, a.Value[3]);
                            c.SetBit(2, a.Value[2]);
                            c.SetBit(1, a.Value[1]);
                            c.SetBit(0, a.Value[0]);

                            // Calculate Flags
                            SetFlags();
                            break;
                        }
                    case OpCode.AND:
                        {
                            c = new Register();

                            // Upper Nibble
                            c.SetBit(7, a.Value[7] & b.Value[7]);
                            c.SetBit(6, a.Value[6] & b.Value[6]);
                            c.SetBit(5, a.Value[5] & b.Value[5]);
                            c.SetBit(4, a.Value[4] & b.Value[4]);

                            // Lower Nibble
                            c.SetBit(3, a.Value[3] & b.Value[3]);
                            c.SetBit(2, a.Value[2] & b.Value[2]);
                            c.SetBit(1, a.Value[1] & b.Value[1]);
                            c.SetBit(0, a.Value[0] & b.Value[0]);

                            // Calculate Flags
                            SetFlags();
                            break;
                        }
                    case OpCode.OR:
                        {
                            c = new Register();

                            // Upper Nibble
                            c.SetBit(7, a.Value[7] | b.Value[7]);
                            c.SetBit(6, a.Value[6] | b.Value[6]);
                            c.SetBit(5, a.Value[5] | b.Value[5]);
                            c.SetBit(4, a.Value[4] | b.Value[4]);

                            // Lower Nibble
                            c.SetBit(3, a.Value[3] | b.Value[3]);
                            c.SetBit(2, a.Value[2] | b.Value[2]);
                            c.SetBit(1, a.Value[1] | b.Value[1]);
                            c.SetBit(0, a.Value[0] | b.Value[0]);

                            // Calculate Flags
                            SetFlags();
                            break;
                        }
                    case OpCode.XOR:
                        {
                            c = new Register();

                            // Upper Nibble
                            c.SetBit(7, a.Value[7] ^ b.Value[7]);
                            c.SetBit(6, a.Value[6] ^ b.Value[6]);
                            c.SetBit(5, a.Value[5] ^ b.Value[5]);
                            c.SetBit(4, a.Value[4] ^ b.Value[4]);

                            // Lower Nibble
                            c.SetBit(3, a.Value[3] ^ b.Value[3]);
                            c.SetBit(2, a.Value[2] ^ b.Value[2]);
                            c.SetBit(1, a.Value[1] ^ b.Value[1]);
                            c.SetBit(0, a.Value[0] ^ b.Value[0]);

                            // Calculate Flags
                            SetFlags();
                            break;
                        }
                    case OpCode.SHL:
                        {
                            c = new Register();

                            c.SetBit(7, a.Value[6]);
                            c.SetBit(6, a.Value[5]);
                            c.SetBit(5, a.Value[4]);
                            c.SetBit(4, a.Value[3]);
                            c.SetBit(3, a.Value[2]);
                            c.SetBit(2, a.Value[1]);
                            c.SetBit(1, a.Value[0]);
                            c.SetBit(0, false);

                            carrySHL = a.Value.Get(7);

                            // Calculate Flags
                            SetFlags();
                            break;
                        }
                    case OpCode.SHR:
                        {
                            c = new Register();

                            c.SetBit(7, false);
                            c.SetBit(6, a.Value[7]);
                            c.SetBit(5, a.Value[6]);
                            c.SetBit(4, a.Value[5]);
                            c.SetBit(3, a.Value[4]);
                            c.SetBit(2, a.Value[3]);
                            c.SetBit(1, a.Value[2]);
                            c.SetBit(0, a.Value[1]);

                            carrySHR = a.Value.Get(0);

                            // Calculate Flags
                            SetFlags();
                            break;
                        }
                    case OpCode.ADD:
                        {
                            c = new Register();
                            int result = a.GetInt() + b.GetInt();
                            byte byteResult = (byte)result;

                            c.SetBit(7, Helper.IsBitSet(byteResult, 7));
                            c.SetBit(6, Helper.IsBitSet(byteResult, 6));
                            c.SetBit(5, Helper.IsBitSet(byteResult, 5));
                            c.SetBit(4, Helper.IsBitSet(byteResult, 4));
                            c.SetBit(3, Helper.IsBitSet(byteResult, 3));
                            c.SetBit(2, Helper.IsBitSet(byteResult, 2));
                            c.SetBit(1, Helper.IsBitSet(byteResult, 1));
                            c.SetBit(0, Helper.IsBitSet(byteResult, 0));

                            if (result > 256)
                                carryADD = true;

                            // Calculate Flags
                            SetFlags();
                            break;
                        }
                    case OpCode.SUB:
                        {
                            c = new Register();
                            int result = a.GetInt() - b.GetInt();
                            byte byteResult = (byte)result;

                            c.SetBit(7, Helper.IsBitSet(byteResult, 7));
                            c.SetBit(6, Helper.IsBitSet(byteResult, 6));
                            c.SetBit(5, Helper.IsBitSet(byteResult, 5));
                            c.SetBit(4, Helper.IsBitSet(byteResult, 4));
                            c.SetBit(3, Helper.IsBitSet(byteResult, 3));
                            c.SetBit(2, Helper.IsBitSet(byteResult, 2));
                            c.SetBit(1, Helper.IsBitSet(byteResult, 1));
                            c.SetBit(0, Helper.IsBitSet(byteResult, 0));

                            if (result < 0)
                                carrySUB = true;

                            // Calculate Flags
                            SetFlags();
                            break;
                        }
                    case OpCode.NOT:
                        {
                            c = new Register();
                            c.SetBit(7, !a.Value[7]);
                            c.SetBit(6, !a.Value[6]);
                            c.SetBit(5, !a.Value[5]);
                            c.SetBit(4, !a.Value[4]);
                            c.SetBit(3, !a.Value[3]);
                            c.SetBit(2, !a.Value[2]);
                            c.SetBit(1, !a.Value[1]);
                            c.SetBit(0, !a.Value[0]);

                            // Calculate Flags
                            SetFlags();
                            break;
                        }
                    case OpCode.MOV_ALU_IN_A_D:
                        {
                            a = d;
                            break;
                        }
                    case OpCode.MOV_ALU_IN_A_E:
                        {
                            a = e;
                            break;
                        }
                    case OpCode.MOV_ALU_IN_A_F:
                        {
                            a = f;
                            break;
                        }
                    case OpCode.MOV_ALU_IN_A_G:
                        {
                            a = g;
                            break;
                        }
                    case OpCode.MOV_ALU_IN_A_H:
                        {
                            a = h;
                            break;
                        }
                    case OpCode.MOV_ALU_IN_A_XL:
                        {
                            a = xl;
                            break;
                        }
                    case OpCode.MOV_ALU_IN_A_XH:
                        {
                            a = xh;
                            break;
                        }
                    case OpCode.MOV_ALU_IN_B_D:
                        {
                            b = d;
                            break;
                        }
                    case OpCode.MOV_ALU_IN_B_E:
                        {
                            b = e;
                            break;
                        }
                    case OpCode.MOV_ALU_IN_B_F:
                        {
                            b = f;
                            break;
                        }
                    case OpCode.MOV_ALU_IN_B_G:
                        {
                            b = g;
                            break;
                        }
                    case OpCode.MOV_ALU_IN_B_H:
                        {
                            b = h;
                            break;
                        }
                    case OpCode.MOV_ALU_IN_B_XL:
                        {
                            b = xl;
                            break;
                        }
                    case OpCode.MOV_ALU_IN_B_XH:
                        {
                            b = xh;
                            break;
                        }
                    case OpCode.MOV_ALU_OUT_D:
                        {
                            d = c;
                            break;
                        }
                    case OpCode.MOV_ALU_OUT_E:
                        {
                            e = c;
                            break;
                        }
                    case OpCode.MOV_ALU_OUT_F:
                        {
                            f = c;
                            break;
                        }
                    case OpCode.MOV_ALU_OUT_G:
                        {
                            g = c;
                            break;
                        }
                    case OpCode.MOV_ALU_OUT_H:
                        {
                            h = c;
                            break;
                        }
                    case OpCode.MOV_ALU_OUT_XL:
                        {
                            xl = c;
                            break;
                        }
                    case OpCode.MOV_ALU_OUT_XH:
                        {
                            xh = c;
                            break;
                        }
                    case OpCode.MOV_D_TO_E:
                        {
                            e = d;
                            break;
                        }
                    case OpCode.MOV_D_TO_F:
                        {
                            f = d;
                            break;
                        }
                    case OpCode.MOV_D_TO_G:
                        {
                            g = d;
                            break;
                        }
                    case OpCode.MOV_D_TO_H:
                        {
                            h = d;
                            break;
                        }
                    case OpCode.MOV_D_TO_XL:
                        {
                            xl = d;
                            break;
                        }
                    case OpCode.MOV_D_TO_XH:
                        {
                            xh = d;
                            break;
                        }
                    case OpCode.MOV_E_TO_D:
                        {
                            d = e;
                            break;
                        }
                    case OpCode.MOV_E_TO_F:
                        {
                            f = e;
                            break;
                        }
                    case OpCode.MOV_E_TO_G:
                        {
                            g = e;
                            break;
                        }
                    case OpCode.MOV_E_TO_H:
                        {
                            h = e;
                            break;
                        }
                    case OpCode.MOV_E_TO_XL:
                        {
                            xl = e;
                            break;
                        }
                    case OpCode.MOV_E_TO_XH:
                        {
                            xh = e;
                            break;
                        }
                    case OpCode.MOV_F_TO_D:
                        {
                            d = f;
                            break;
                        }
                    case OpCode.MOV_F_TO_E:
                        {
                            e = f;
                            break;
                        }
                    case OpCode.MOV_F_TO_G:
                        {
                            g = f;
                            break;
                        }
                    case OpCode.MOV_F_TO_H:
                        {
                            h = f;
                            break;
                        }
                    case OpCode.MOV_F_TO_XL:
                        {
                            xl = f;
                            break;
                        }
                    case OpCode.MOV_G_TO_D:
                        {
                            d = g;
                            break;
                        }
                    case OpCode.MOV_G_TO_E:
                        {
                            e = g;
                            break;
                        }
                    case OpCode.MOV_G_TO_F:
                        {
                            f = g;
                            break;
                        }
                    case OpCode.MOV_G_TO_H:
                        {
                            h = g;
                            break;
                        }
                    case OpCode.MOV_G_TO_XL:
                        {
                            xl = g;
                            break;
                        }
                    case OpCode.MOV_G_TO_XH:
                        {
                            xh = g;
                            break;
                        }
                    case OpCode.MOV_H_TO_D:
                        {
                            d = h;
                            break;
                        }
                    case OpCode.MOV_H_TO_E:
                        {
                            e = h;
                            break;
                        }
                    case OpCode.MOV_H_TO_F:
                        {
                            f = h;
                            break;
                        }
                    case OpCode.MOV_H_TO_G:
                        {
                            g = h;
                            break;
                        }
                    case OpCode.MOV_H_TO_XL:
                        {
                            xl = h;
                            break;
                        }
                    case OpCode.MOV_H_TO_XH:
                        {
                            xh = h;
                            break;
                        }
                    case OpCode.MOV_XL_TO_D:
                        {
                            d = xl;
                            break;
                        }
                    case OpCode.MOV_XL_TO_E:
                        {
                            e = xl;
                            break;
                        }
                    case OpCode.MOV_XL_TO_F:
                        {
                            f = xl;
                            break;
                        }
                    case OpCode.MOV_XL_TO_G:
                        {
                            g = xl;
                            break;
                        }
                    case OpCode.MOV_XL_TO_H:
                        {
                            h = xl;
                            break;
                        }
                    case OpCode.MOV_XL_TO_XH:
                        {
                            xh = xl;
                            break;
                        }
                    case OpCode.MOV_XH_TO_D:
                        {
                            d = xh;
                            break;
                        }
                    case OpCode.MOV_XH_TO_E:
                        {
                            e = xh;
                            break;
                        }
                    case OpCode.MOV_XH_TO_F:
                        {
                            f = xh;
                            break;
                        }
                    case OpCode.MOV_XH_TO_G:
                        {
                            g = xh;
                            break;
                        }
                    case OpCode.MOV_XH_TO_H:
                        {
                            h = xh;
                            break;
                        }
                    case OpCode.MOV_XH_TO_XL:
                        {
                            xl = xh;
                            break;
                        }
                    case OpCode.MOV_M_TO_X:
                        {
                            X = m;
                            break;
                        }
                    case OpCode.MOV_M_TO_J:
                        {
                            j = m;
                            break;
                        }
                    case OpCode.MOV_M_TO_SP:
                        {
                            sp = m;
                            break;
                        }
                    case OpCode.MOV_M_TO_BP:
                        {
                            bp = m;
                            break;
                        }
                    case OpCode.MOV_M_TO_Y:
                        {
                            y = m;
                            break;
                        }
                    case OpCode.MOV_M_TO_Z:
                        {
                            z = m;
                            break;
                        }
                    case OpCode.MOV_M_TO_PC:
                        {
                            programCounter = m;
                            break;
                        }
                    case OpCode.MOV_X_TO_M:
                        {
                            m = X;
                            break;
                        }
                    case OpCode.MOV_X_TO_J:
                        {
                            j = X;
                            break;
                        }
                    case OpCode.MOV_X_TO_SP:
                        {
                            sp = X;
                            break;
                        }
                    case OpCode.MOV_X_TO_BP:
                        {
                            bp = X;
                            break;
                        }
                    case OpCode.MOV_X_TO_Y:
                        {
                            y = X;
                            break;
                        }
                    case OpCode.MOV_X_TO_Z:
                        {
                            z = X;
                            break;
                        }
                    case OpCode.MOV_J_TO_M:
                        {
                            m = j;
                            break;
                        }
                    case OpCode.MOV_J_TO_X:
                        {
                            X = j;
                            break;
                        }
                    case OpCode.MOV_J_TO_SP:
                        {
                            sp = j;
                            break;
                        }
                    case OpCode.MOV_J_TO_BP:
                        {
                            bp = j;
                            break;
                        }
                    case OpCode.MOV_J_TO_Y:
                        {
                            y = j;
                            break;
                        }
                    case OpCode.MOV_J_TO_Z:
                        {
                            z = j;
                            break;
                        }
                    case OpCode.MOV_SP_TO_M:
                        {
                            m = sp;
                            break;
                        }
                    case OpCode.MOV_SP_TO_X:
                        {
                            X = sp;
                            break;
                        }
                    case OpCode.MOV_SP_TO_J:
                        {
                            j = sp;
                            break;
                        }
                    case OpCode.MOV_SP_TO_BP:
                        {
                            bp = sp;
                            break;
                        }
                    case OpCode.MOV_SP_TO_Y:
                        {
                            y = sp;
                            break;
                        }
                    case OpCode.MOV_SP_TO_Z:
                        {
                            z = sp;
                            break;
                        }
                    case OpCode.MOV_PC_TO_X:
                        {
                            X = programCounter;
                            break;
                        }
                    case OpCode.MOV_BP_TO_M:
                        {
                            m = bp;
                            break;
                        }
                    case OpCode.MOV_BP_TO_X:
                        {
                            X = bp;
                            break;
                        }
                    case OpCode.MOV_BP_TO_J:
                        {
                            j = bp;
                            break;
                        }
                    case OpCode.MOV_BP_TO_SP:
                        {
                            sp = bp;
                            break;
                        }
                    case OpCode.MOV_BP_TO_Y:
                        {
                            y = bp;
                            break;
                        }
                    case OpCode.MOV_BP_TO_Z:
                        {
                            z = bp;
                            break;
                        }
                    case OpCode.MOV_Y_TO_M:
                        {
                            m = y;
                            break;
                        }
                    case OpCode.MOV_Y_TO_X:
                        {
                            X = y;
                            break;
                        }
                    case OpCode.MOV_Y_TO_J:
                        {
                            j = y;
                            break;
                        }
                    case OpCode.MOV_Y_TO_SP:
                        {
                            sp = y;
                            break;
                        }
                    case OpCode.MOV_Y_TO_BP:
                        {
                            bp = y;
                            break;
                        }
                    case OpCode.MOV_Y_TO_Z:
                        {
                            z = y;
                            break;
                        }
                    case OpCode.MOV_Z_TO_M:
                        {
                            m = z;
                            break;
                        }
                    case OpCode.MOV_Z_TO_X:
                        {
                            X = z;
                            break;
                        }
                    case OpCode.MOV_Z_TO_J:
                        {
                            j = z;
                            break;
                        }
                    case OpCode.MOV_Z_TO_SP:
                        {
                            sp = z;
                            break;
                        }
                    case OpCode.MOV_Z_TO_BP:
                        {
                            bp = z;
                            break;
                        }
                    case OpCode.MOV_Z_TO_Y:
                        {
                            y = z;
                            break;
                        }
                    case OpCode.MOV_ALU_C_TO_A:
                        {
                            a = c;
                            break;
                        }
                    case OpCode.MOV_ALU_C_TO_B:
                        {
                            b = c;
                            break;
                        }
                    case OpCode.LOAD_D:
                        {
                            d.SetBits(ram.ReadValue(M.GetInt()));
                            break;
                        }
                    case OpCode.LOAD_E:
                        {
                            e.SetBits(ram.ReadValue(M.GetInt()));
                            break;
                        }
                    case OpCode.LOAD_F:
                        {
                            f.SetBits(ram.ReadValue(M.GetInt()));
                            break;
                        }
                    case OpCode.LOAD_G:
                        {
                            g.SetBits(ram.ReadValue(M.GetInt()));
                            break;
                        }
                    case OpCode.LOAD_H:
                        {
                            h.SetBits(ram.ReadValue(M.GetInt()));
                            break;
                        }
                    case OpCode.LOAD_XL:
                        {
                            xl.SetBits(ram.ReadValue(M.GetInt()));
                            break;
                        }
                    case OpCode.LOAD_XH:
                        {
                            xh.SetBits(ram.ReadValue(M.GetInt()));
                            break;
                        }
                    case OpCode.STORE_D:
                        {
                            ram.WriteValue(M.GetInt(), d.GetByte());
                            break;
                        }
                    case OpCode.STORE_E:
                        {
                            ram.WriteValue(M.GetInt(), e.GetByte());
                            break;
                        }
                    case OpCode.STORE_F:
                        {
                            ram.WriteValue(M.GetInt(), f.GetByte());
                            break;
                        }
                    case OpCode.STORE_G:
                        {
                            ram.WriteValue(M.GetInt(), g.GetByte());
                            break;
                        } 
                    case OpCode.STORE_H:
                        {
                            ram.WriteValue(M.GetInt(), h.GetByte());
                            break;
                        }
                    case OpCode.STORE_XL:
                        {
                            ram.WriteValue(M.GetInt(), xl.GetByte());
                            break;
                        }
                    case OpCode.STORE_XH:
                        {
                            ram.WriteValue(M.GetInt(), xh.GetByte());
                            break;
                        }
                    case OpCode.SAVE_FLAGS:
                        {
                            flagsSaved = flags;
                            break;
                        }
                    case OpCode.RESTORE_FLAGS:
                        {
                            flags = flagsSaved;
                            break;
                        }
                    case OpCode.JMP:
                        {
                            programCounter = j;
                            incrementProgramCounter = false;
                            break;
                        }
                    case OpCode.JZ:
                        {
                            // The Jump is only performed if the Zero Flag is set to 1
                            if (flags.Value.Get(1))
                            {
                                programCounter = j;
                                incrementProgramCounter = false;
                            }
                            else
                                incrementProgramCounter = true;

                            break;
                        }
                    case OpCode.JNZ:
                        {
                            // The Jump is only performed if the Zero Flag is set to 0
                            if (!flags.Value.Get(1))
                            {
                                programCounter = j;
                                incrementProgramCounter = false;
                            }
                            else
                                incrementProgramCounter = true;

                            break;
                        }
                    case OpCode.JNS:
                        {
                            // The Jump is only performed if the Sign Flag is set to 0
                            if (!flags.Value.Get(0))
                            {
                                programCounter = j;
                                incrementProgramCounter = false;
                            }
                            else
                                incrementProgramCounter = true;

                            break;
                        }
                    case OpCode.ADDER_16BIT:
                        {
                            int result = X.GetInt() + J.GetInt();

                            Register16 temp = new Register16();
                            temp.SetBits(result);
                            X = temp;
                           
                            break;
                        }
                    case OpCode.OUT_C:
                        {
                            OutputPortC = xl.GetString();
                            break;
                        }
                    case OpCode.OUT_D:
                        {
                            OutputPortD = xl.GetString();
                            break;
                        }
                    case OpCode.IN_A:
                        {
                            programCounter.Increment();
                            return CPUExecution.IN_A;
                        }
                    case OpCode.IN_B:
                        {
                            programCounter.Increment();
                            return CPUExecution.IN_B;
                        }
                }
            }
            else
            {
                // We hit a breakpoint!
                return CPUExecution.BREAKPOINT_HIT;
            }

            // Increment the Program Counter, if necessary
            if (incrementProgramCounter)
                programCounter.Increment();
            
            // There are more CPU instructions available for execution...
            return CPUExecution.MORE_INSTRUCTIONS_AVAILABLE;
        }

        /// <summary>
        /// Returns the current content of the RAM.
        /// </summary>
        /// <returns></returns>
        public byte[] DumpMemory()
        {
            return ram.DumpMemory();
        }

        /// <summary>
        /// Sets the Flags accordingly.
        /// </summary>
        private void SetFlags()
        {
            flags = new Register();

            // Sign Flag
            flags.SetBit(0, c.Value.Get(7));

            // Zero Flag
            flags.SetBit(1, c.GetInt() == 0);

            // Carry Flag
            flags.SetBit(2, carryADD || carrySUB || carrySHL || carrySHR);
        }

        /// <summary>
        /// Displays the current state of the processor.
        /// </summary>
        public void DumpState()
        {
            Console.WriteLine("State:");
            Console.WriteLine("\tProgram Counter: " + ProgramCounter.GetString());
            Console.WriteLine("\tInstruction: " + Instruction.GetString());
            Console.WriteLine("\tOpcode: " + Instruction.GetOpCode().ToString());
            Console.WriteLine("\tA:  " + a.GetString());
            Console.WriteLine("\tB:  " + b.GetString());
            Console.WriteLine("\tC:  " + c.GetString());
            Console.WriteLine("\tD:  " + D.GetString());
            Console.WriteLine("\tE:  " + E.GetString());
            Console.WriteLine("\tF:  " + F.GetString());
            Console.WriteLine("\tG:  " + G.GetString());
            Console.WriteLine("\tH:  " + H.GetString());
            Console.WriteLine("\tXL: " + XL.GetString());
            Console.WriteLine("\tXH: " + XH.GetString());
            Console.WriteLine("");
        }
    }
}
