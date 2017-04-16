using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using KPU.Emulation;

namespace KPU.Emulator
{
    public partial class cmdInputPortB : Form
    {
        private Processor cpu;
        private int indexForNextInstruction;
        private bool highlightInstruction;
        private long instructionsExecuted;
        private MicroTimer microTimer;
        private Memory memoryMapDialog;

        public cmdInputPortB()
        {
            InitializeComponent();

            cpu = new Processor();
            indexForNextInstruction = 0;
            highlightInstruction = false;
            instructionsExecuted = 0;

            SetupTimer();

            // Show the Memory Map Dialog
            memoryMapDialog = new Memory();
            memoryMapDialog.Show();
        }

        private void SetupTimer()
        {
            microTimer = new MicroTimer();
            microTimer.MicroTimerElapsed += new MicroTimer.MicroTimerElapsedEventHandler(OnTimedEvent);

            // microTimer.Interval = 10;
            microTimer.Interval = 1;
        }

        private void OnTimedEvent(object sender, MicroTimerEventArgs timerEventArgs)
        {
            ExecuteNextAssemblyInstruction();
        }

        /// <summary>
        /// Loads a KPU program for execution.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdLoadProgram_Click(object sender, EventArgs e)
        {
            LoadBinaryCode();
            memoryMapDialog.CPU = cpu;
            memoryMapDialog.InitializeMemory();

            txtOutput.Clear();
            cmdExecute.Enabled = cmdSingleStep.Enabled = true;
            txtProgramCounter.Text = "0000 0000 0000 0000 (0x0)";

            txtRegisterD.Text =  "0000 0000 (0x0)";
            txtRegisterE.Text = " 0000 0000 (0x0)";
            txtRegisterF.Text = " 0000 0000 (0x0)";
            txtRegisterG.Text = " 0000 0000 (0x0)";
            txtRegisterH.Text = " 0000 0000 (0x0)";
            txtRegisterXL.Text = "0000 0000 (0x0)";
            txtRegisterXH.Text = "0000 0000 (0x0)";

            txtRegisterM.Text =  "0000 0000 0000 0000 (0x0)";
            txtRegisterX.Text =  "0000 0000 0000 0000 (0x0)";
            txtRegisterJ.Text =  "0000 0000 0000 0000 (0x0)";
            txtRegisterSP.Text = "0000 0000 0000 0000 (0x0)";
            txtRegisterBP.Text = "0000 0000 0000 0000 (0x0)";
            txtRegisterY.Text =  "0000 0000 0000 0000 (0x0)";
            txtRegisterZ.Text =  "0000 0000 0000 0000 (0x0)";

            txtInputA.Text = "0000 0000 (0x0)";
            txtInputB.Text = "0000 0000 (0x0)";
            txtResult.Text =   "0000 0000 (0x0)";

            txtFlags.Text = "0000 0000 (0x0)";
            txtFlagsSaved.Text = "0000 0000 (0x0)";
            txtFlagsInBuffer.Text = "0000 0000 (0x0)";
            txtFlagsOutBuffer.Text = "0000 0000 (0x0)";

            txtInputPortA.Text = string.Empty;
            txtInputPortB.Text = string.Empty;
            txtOutputPortC.Text = string.Empty;
            txtOutputPortD.Text = string.Empty;
        }

        private void LoadBinaryCode()
        {
            StreamReader reader = new StreamReader(@"Z:\Klaus\OneDrive\KPU\BinaryCode.bin");
            List<byte> opcodes = new List<byte>();
            lstAssembly.Items.Clear();
            cpu = new Processor();
            indexForNextInstruction = 0;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                // Bypass comments...
                if (!line.StartsWith(";;") && !line.Contains("; DATA"))
                {
                    opcodes.Add(Helper.GetByte(line.Substring(17, 8)));

                    lstAssembly.Items.Add(new ListViewItem(new string[] { 
                        FormatRegister16(line.Substring(0, 16)), 
                        line.Substring(28), 
                        FormatRegister8(line.Substring(17, 8)) }));
                }
                else if (line.Contains("; DATA"))
                    InitializeSRAM(line);
            }

            reader.Close();
            cpu.LoadProgram(0, opcodes.ToArray<byte>());
        }

        private void InitializeSRAM(string Line)
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

        /// <summary>
        /// Executes the next instruction in the loaded program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSingleStep_Click(object sender, EventArgs e)
        {
            ExecuteNextAssemblyInstruction();
        }

        private string FormatRegister8(string Register)
        {
            return Register.Substring(0, 4) + " " + Register.Substring(4) + " (0x" + HexConverted(Register) + ")";
        }

        private string FormatRegister16(string Register)
        {
            return Register.Substring(0, 4) + " " + Register.Substring(4, 4) + " " + Register.Substring(8, 4) + " " + Register.Substring(12, 4) + 
                " (0x" + HexConverted(Register) + ")";
        }

        private string HexConverted(string strBinary)
        {
            return Convert.ToInt32(strBinary, 2).ToString("X");
        }

        private void UpdateUI(string OutputPortC, string OutputPortD)
        {
            if (highlightInstruction)
            {
                txtProgramCounter.Text = FormatRegister16(cpu.ProgramCounter.GetString());
                txtInstruction.Text = cpu.Instruction.GetOpCode().ToString();
                txtInputA.Text = FormatRegister8(cpu.A.GetString());
                txtInputB.Text = FormatRegister8(cpu.B.GetString());
                txtResult.Text = FormatRegister8(cpu.C.GetString());

                // 8-bit Registers
                txtRegisterD.Text = FormatRegister8(cpu.D.GetString());
                txtRegisterE.Text = FormatRegister8(cpu.E.GetString());
                txtRegisterF.Text = FormatRegister8(cpu.F.GetString());
                txtRegisterG.Text = FormatRegister8(cpu.G.GetString());
                txtRegisterH.Text = FormatRegister8(cpu.H.GetString());
                txtRegisterXL.Text = FormatRegister8(cpu.XL.GetString());
                txtRegisterXH.Text = FormatRegister8(cpu.XH.GetString());

                // 16-bit Registers
                txtRegisterX.Text = FormatRegister16(cpu.X.GetString());
                txtRegisterM.Text = FormatRegister16(cpu.M.GetString());
                txtRegisterJ.Text = FormatRegister16(cpu.J.GetString());
                txtRegisterSP.Text = FormatRegister16(cpu.SP.GetString());
                txtRegisterBP.Text = FormatRegister16(cpu.BP.GetString());
                txtRegisterY.Text = FormatRegister16(cpu.Y.GetString());
                txtRegisterZ.Text = FormatRegister16(cpu.Z.GetString());

                if (cpu.IsALUOperation())
                    txtOperation.Text = cpu.Instruction.GetOpCode().ToString();
                else
                    txtOperation.Text = string.Empty;

                // Flags Register
                txtFlags.Text = FormatRegister8(cpu.Flags.GetString());
                txtFlagsSaved.Text = FormatRegister8(cpu.FlagsSaved.GetString());

                lblInstructionsExecuted.Text = "Instructions: " + instructionsExecuted.ToString();
            }

            // IO Port
            if (OutputPortC != string.Empty)
            {
                txtOutputPortC.Text = FormatRegister8(OutputPortC);
                txtOutput.Text += Convert.ToChar(Helper.GetByte(OutputPortC));
            }

            if (OutputPortD != string.Empty)
                txtOutputPortD.Text = FormatRegister8(OutputPortD);
        }

        private void cmdExecute_Click(object sender, EventArgs e)
        {
            // executionTimer.Enabled = true;
            // executionTimer.Start();

            microTimer.Enabled = true;
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string memoryAddress = lstAssembly.Items[e.Index].SubItems[0].Text;
            string breakpointAddress = memoryAddress.Substring(0, 4) +
                memoryAddress.Substring(5, 4) + memoryAddress.Substring(10, 4) + memoryAddress.Substring(15, 4);

            if (e.CurrentValue == CheckState.Unchecked)
            {
                // Set a breakpoint
                if (MessageBox.Show("Do you want to set at the position " + breakpointAddress + " a breakpoint?", "Set Breakpoint", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    e.NewValue = CheckState.Checked;

                    // Set the breakpoint within the CPU
                    cpu.SetBreakpoint(breakpointAddress);
                }
                else
                    e.NewValue = CheckState.Unchecked;
            }
            else
            {
                // Remove a breakpoint
                if (MessageBox.Show("Do you want to remove at the position " + breakpointAddress + " the breakpoint?", "Set Breakpoint", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    e.NewValue = CheckState.Unchecked;
                    
                    // Remove the breakpoint
                    cpu.RemoveBreakpoint(breakpointAddress);
                }
                else
                    e.NewValue = CheckState.Checked;
            }
        }

        private void ExecuteNextAssemblyInstruction()
        {
            string OutputPortC = string.Empty;
            string OutputPortD = string.Empty;
            bool incrementIndex = true;
            instructionsExecuted++;

            if (lstAssembly.SelectedItems.Count == 0)
            {
                cpu.SingleStep(out OutputPortC, out OutputPortD);
                UpdateUI(OutputPortC, OutputPortD);
                lblCPUState.Text = "RUNNING...";
                lblCPUState.ForeColor = Color.Green;

                // Highlight the first assembly instruction in the ListView.
                lstAssembly.FocusedItem = lstAssembly.Items[0];
                lstAssembly.Items[0].Selected = true;
                lstAssembly.Select();
                lstAssembly.EnsureVisible(0);

                lstAssembly.Items[lstAssembly.SelectedItems[0].Index].EnsureVisible();
            }
            else
            {
                CPUExecution executionContext = cpu.SingleStep(out OutputPortC, out OutputPortD);
                UpdateUI(OutputPortC, OutputPortD);

                if (executionContext == CPUExecution.MORE_INSTRUCTIONS_AVAILABLE)
                {
                    if (txtInstruction.Text == "JMP" || txtInstruction.Text == "JZ" || txtInstruction.Text == "JNZ")
                        incrementIndex = false;

                    // Highlight the next assembly instruction in the ListView
                    if (highlightInstruction)
                    {
                        lstAssembly.Items[indexForNextInstruction].Selected = true;
                        lstAssembly.Select();
                        lstAssembly.EnsureVisible(0);
                        lstAssembly.Items[lstAssembly.SelectedItems[0].Index].EnsureVisible();
                    }

                    lblCPUState.Text = "RUNNING...";
                    lblCPUState.ForeColor = Color.Green;
                }
                else if (executionContext == CPUExecution.BREAKPOINT_HIT)
                {
                    // Highlight the current assembly instruction in the ListView
                    if (highlightInstruction)
                    {
                        lstAssembly.Items[indexForNextInstruction].Selected = true;
                        lstAssembly.Select();
                        lstAssembly.EnsureVisible(0);
                        lstAssembly.Items[lstAssembly.SelectedItems[0].Index].EnsureVisible();
                    }

                    lblCPUState.Text = "BREAKPOINT HIT!";
                    lblCPUState.ForeColor = Color.Red;

                    // Disable automatic CPU execution
                    // if (executionTimer.Enabled)
                       // executionTimer.Enabled = false;

                    if (microTimer.Enabled)
                        microTimer.Enabled = false;
                }
                else if (executionContext == CPUExecution.IN_A)
                {
                    // Highlight the current assembly instruction in the ListView
                    if (highlightInstruction)
                    {
                        lstAssembly.Items[indexForNextInstruction].Selected = true;
                        lstAssembly.Select();
                        lstAssembly.EnsureVisible(0);
                        lstAssembly.Items[lstAssembly.SelectedItems[0].Index].EnsureVisible();
                    }

                    lblCPUState.Text = "IN A!";
                    lblCPUState.ForeColor = Color.Red;

                    // Disable automatic CPU execution
                    // if (executionTimer.Enabled)
                       //  executionTimer.Enabled = false;

                    if (microTimer.Enabled)
                        microTimer.Enabled = false;
                }
                else if (executionContext == CPUExecution.IN_B)
                {
                    // Highlight the current assembly instruction in the ListView
                    if (highlightInstruction)
                    {
                        lstAssembly.Items[indexForNextInstruction].Selected = true;
                        lstAssembly.Select();
                        lstAssembly.EnsureVisible(0);
                        lstAssembly.Items[lstAssembly.SelectedItems[0].Index].EnsureVisible();
                    }

                    lblCPUState.Text = "IN B!";
                    lblCPUState.ForeColor = Color.Red;

                    // Disable automatic CPU execution
                    // if (executionTimer.Enabled)
                       //  executionTimer.Enabled = false;

                    if (microTimer.Enabled)
                        microTimer.Enabled = false;
                }
                else if (executionContext == CPUExecution.FINISHED)
                {
                    // Highlight the current assembly instruction in the ListView
                    if (highlightInstruction)
                    {
                        lstAssembly.Items[indexForNextInstruction].Selected = true;
                        lstAssembly.Select();
                        lstAssembly.EnsureVisible(0);
                        lstAssembly.Items[lstAssembly.SelectedItems[0].Index].EnsureVisible();
                    }

                    lblCPUState.Text = "FINISHED!";
                    lblCPUState.ForeColor = Color.Green;

                    cmdExecute.Enabled = cmdSingleStep.Enabled = false;

                    // Disable automatic CPU execution
                    // if (executionTimer.Enabled)
                       //  executionTimer.Enabled = false;

                    if (microTimer.Enabled)
                        microTimer.Enabled = false;
                }
            }

            if (incrementIndex)
                indexForNextInstruction++;
            else
            {
                // Find the correct line for highlighting based on the new Program Counter value.
                // Used during jumps (conditional, unconditional).
                indexForNextInstruction = 0;

                foreach (ListViewItem item in lstAssembly.Items)
                {
                    indexForNextInstruction++;

                    if (item.SubItems[0].Text == txtProgramCounter.Text)
                        break;
                }

                // Correct the index by 1
                indexForNextInstruction--;
            }
        }

        /// <summary>
        /// Every time when the timer elapses, we execute another CPU instruction.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void executionTimer_Tick(object sender, EventArgs e)
        {
            // ExecuteNextAssemblyInstruction();
        }

        private void cmdInputPortA_Click(object sender, EventArgs e)
        {
            cpu.XL.SetBits(Helper.GetByte(txtInputPortA.Text));
        }

        private void cmdInputPort_B_Click(object sender, EventArgs e)
        {
            cpu.XL.SetBits(Helper.GetByte(txtInputPortB.Text));
        }
    }
}
