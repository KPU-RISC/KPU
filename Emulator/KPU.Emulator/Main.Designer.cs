namespace KPU.Emulator
{
    partial class cmdInputPortB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmdLoadProgram = new System.Windows.Forms.Button();
            this.txtProgramCounter = new System.Windows.Forms.TextBox();
            this.cmdSingleStep = new System.Windows.Forms.Button();
            this.cmdExecute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInstruction = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInputA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOperation = new System.Windows.Forms.TextBox();
            this.txtInputB = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtRegisterXH = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRegisterXL = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRegisterH = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRegisterG = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRegisterF = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRegisterE = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRegisterD = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtRegisterZ = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtRegisterY = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtRegisterJ = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtRegisterBP = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtRegisterSP = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtRegisterM = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtRegisterX = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lstAssembly = new System.Windows.Forms.ListView();
            this.headerMemoryLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerAssembly = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerOpcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label7 = new System.Windows.Forms.Label();
            this.lblCPUState = new System.Windows.Forms.Label();
            this.executionTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFlagsOutBuffer = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFlagsInBuffer = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtFlagsSaved = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtFlags = new System.Windows.Forms.TextBox();
            this.lblInstructionsExecuted = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cmdInputPort_B = new System.Windows.Forms.Button();
            this.cmdInputPortA = new System.Windows.Forms.Button();
            this.txtOutputPortD = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtInputPortA = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtOutputPortC = new System.Windows.Forms.TextBox();
            this.txtInputPortB = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdLoadProgram
            // 
            this.cmdLoadProgram.Location = new System.Drawing.Point(585, 38);
            this.cmdLoadProgram.Name = "cmdLoadProgram";
            this.cmdLoadProgram.Size = new System.Drawing.Size(114, 23);
            this.cmdLoadProgram.TabIndex = 2;
            this.cmdLoadProgram.Text = "Load Program...";
            this.cmdLoadProgram.UseVisualStyleBackColor = true;
            this.cmdLoadProgram.Click += new System.EventHandler(this.cmdLoadProgram_Click);
            // 
            // txtProgramCounter
            // 
            this.txtProgramCounter.Location = new System.Drawing.Point(583, 155);
            this.txtProgramCounter.Name = "txtProgramCounter";
            this.txtProgramCounter.Size = new System.Drawing.Size(170, 20);
            this.txtProgramCounter.TabIndex = 4;
            // 
            // cmdSingleStep
            // 
            this.cmdSingleStep.Enabled = false;
            this.cmdSingleStep.Location = new System.Drawing.Point(585, 67);
            this.cmdSingleStep.Name = "cmdSingleStep";
            this.cmdSingleStep.Size = new System.Drawing.Size(113, 23);
            this.cmdSingleStep.TabIndex = 5;
            this.cmdSingleStep.Text = "Single Step";
            this.cmdSingleStep.UseVisualStyleBackColor = true;
            this.cmdSingleStep.Click += new System.EventHandler(this.cmdSingleStep_Click);
            // 
            // cmdExecute
            // 
            this.cmdExecute.Enabled = false;
            this.cmdExecute.Location = new System.Drawing.Point(585, 96);
            this.cmdExecute.Name = "cmdExecute";
            this.cmdExecute.Size = new System.Drawing.Size(113, 23);
            this.cmdExecute.TabIndex = 6;
            this.cmdExecute.Text = "Run";
            this.cmdExecute.UseVisualStyleBackColor = true;
            this.cmdExecute.Click += new System.EventHandler(this.cmdExecute_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(582, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Program Counter:";
            // 
            // txtInstruction
            // 
            this.txtInstruction.Location = new System.Drawing.Point(583, 196);
            this.txtInstruction.Name = "txtInstruction";
            this.txtInstruction.Size = new System.Drawing.Size(170, 20);
            this.txtInstruction.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(580, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Instruction:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtResult);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtInputA);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtOperation);
            this.groupBox1.Controls.Add(this.txtInputB);
            this.groupBox1.Location = new System.Drawing.Point(592, 230);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 200);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ALU:";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(7, 169);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(100, 20);
            this.txtResult.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Result:";
            // 
            // txtInputA
            // 
            this.txtInputA.Location = new System.Drawing.Point(6, 33);
            this.txtInputA.Name = "txtInputA";
            this.txtInputA.Size = new System.Drawing.Size(100, 20);
            this.txtInputA.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Input A:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Operation:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Input B:";
            // 
            // txtOperation
            // 
            this.txtOperation.Location = new System.Drawing.Point(6, 121);
            this.txtOperation.Name = "txtOperation";
            this.txtOperation.Size = new System.Drawing.Size(100, 20);
            this.txtOperation.TabIndex = 14;
            // 
            // txtInputB
            // 
            this.txtInputB.Location = new System.Drawing.Point(6, 75);
            this.txtInputB.Name = "txtInputB";
            this.txtInputB.Size = new System.Drawing.Size(100, 20);
            this.txtInputB.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtRegisterXH);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtRegisterXL);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtRegisterH);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtRegisterG);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtRegisterF);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtRegisterE);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtRegisterD);
            this.groupBox2.Location = new System.Drawing.Point(760, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 186);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "8-Bit Registers";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(138, 101);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(25, 13);
            this.label16.TabIndex = 40;
            this.label16.Text = "XH:";
            // 
            // txtRegisterXH
            // 
            this.txtRegisterXH.Location = new System.Drawing.Point(139, 117);
            this.txtRegisterXH.Name = "txtRegisterXH";
            this.txtRegisterXH.Size = new System.Drawing.Size(100, 20);
            this.txtRegisterXH.TabIndex = 39;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(138, 58);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 13);
            this.label15.TabIndex = 38;
            this.label15.Text = "XL:";
            // 
            // txtRegisterXL
            // 
            this.txtRegisterXL.Location = new System.Drawing.Point(139, 74);
            this.txtRegisterXL.Name = "txtRegisterXL";
            this.txtRegisterXL.Size = new System.Drawing.Size(100, 20);
            this.txtRegisterXL.TabIndex = 37;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(138, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "H:";
            // 
            // txtRegisterH
            // 
            this.txtRegisterH.Location = new System.Drawing.Point(139, 32);
            this.txtRegisterH.Name = "txtRegisterH";
            this.txtRegisterH.Size = new System.Drawing.Size(100, 20);
            this.txtRegisterH.TabIndex = 35;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 142);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "G:";
            // 
            // txtRegisterG
            // 
            this.txtRegisterG.Location = new System.Drawing.Point(7, 158);
            this.txtRegisterG.Name = "txtRegisterG";
            this.txtRegisterG.Size = new System.Drawing.Size(100, 20);
            this.txtRegisterG.TabIndex = 33;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 101);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "F:";
            // 
            // txtRegisterF
            // 
            this.txtRegisterF.Location = new System.Drawing.Point(7, 117);
            this.txtRegisterF.Name = "txtRegisterF";
            this.txtRegisterF.Size = new System.Drawing.Size(100, 20);
            this.txtRegisterF.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "E:";
            // 
            // txtRegisterE
            // 
            this.txtRegisterE.Location = new System.Drawing.Point(7, 74);
            this.txtRegisterE.Name = "txtRegisterE";
            this.txtRegisterE.Size = new System.Drawing.Size(100, 20);
            this.txtRegisterE.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "D:";
            // 
            // txtRegisterD
            // 
            this.txtRegisterD.Location = new System.Drawing.Point(7, 32);
            this.txtRegisterD.Name = "txtRegisterD";
            this.txtRegisterD.Size = new System.Drawing.Size(100, 20);
            this.txtRegisterD.TabIndex = 27;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.txtRegisterZ);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.txtRegisterY);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.txtRegisterJ);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.txtRegisterBP);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.txtRegisterSP);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.txtRegisterM);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.txtRegisterX);
            this.groupBox3.Location = new System.Drawing.Point(1020, 38);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(382, 186);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "16-Bit Registers";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(199, 100);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 13);
            this.label17.TabIndex = 40;
            this.label17.Text = "Z:";
            // 
            // txtRegisterZ
            // 
            this.txtRegisterZ.Location = new System.Drawing.Point(200, 116);
            this.txtRegisterZ.Name = "txtRegisterZ";
            this.txtRegisterZ.Size = new System.Drawing.Size(170, 20);
            this.txtRegisterZ.TabIndex = 39;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(199, 57);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 13);
            this.label18.TabIndex = 38;
            this.label18.Text = "Y:";
            // 
            // txtRegisterY
            // 
            this.txtRegisterY.Location = new System.Drawing.Point(200, 73);
            this.txtRegisterY.Name = "txtRegisterY";
            this.txtRegisterY.Size = new System.Drawing.Size(170, 20);
            this.txtRegisterY.TabIndex = 37;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(199, 15);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(15, 13);
            this.label19.TabIndex = 36;
            this.label19.Text = "J:";
            // 
            // txtRegisterJ
            // 
            this.txtRegisterJ.Location = new System.Drawing.Point(200, 31);
            this.txtRegisterJ.Name = "txtRegisterJ";
            this.txtRegisterJ.Size = new System.Drawing.Size(170, 20);
            this.txtRegisterJ.TabIndex = 35;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 142);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(24, 13);
            this.label20.TabIndex = 34;
            this.label20.Text = "BP:";
            // 
            // txtRegisterBP
            // 
            this.txtRegisterBP.Location = new System.Drawing.Point(7, 158);
            this.txtRegisterBP.Name = "txtRegisterBP";
            this.txtRegisterBP.Size = new System.Drawing.Size(170, 20);
            this.txtRegisterBP.TabIndex = 33;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 101);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(24, 13);
            this.label21.TabIndex = 32;
            this.label21.Text = "SP:";
            // 
            // txtRegisterSP
            // 
            this.txtRegisterSP.Location = new System.Drawing.Point(7, 117);
            this.txtRegisterSP.Name = "txtRegisterSP";
            this.txtRegisterSP.Size = new System.Drawing.Size(170, 20);
            this.txtRegisterSP.TabIndex = 31;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 58);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(19, 13);
            this.label22.TabIndex = 30;
            this.label22.Text = "M:";
            // 
            // txtRegisterM
            // 
            this.txtRegisterM.Location = new System.Drawing.Point(7, 74);
            this.txtRegisterM.Name = "txtRegisterM";
            this.txtRegisterM.Size = new System.Drawing.Size(170, 20);
            this.txtRegisterM.TabIndex = 29;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 13);
            this.label23.TabIndex = 28;
            this.label23.Text = "X:";
            // 
            // txtRegisterX
            // 
            this.txtRegisterX.Location = new System.Drawing.Point(7, 32);
            this.txtRegisterX.Name = "txtRegisterX";
            this.txtRegisterX.Size = new System.Drawing.Size(170, 20);
            this.txtRegisterX.TabIndex = 27;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtOutput);
            this.groupBox5.Location = new System.Drawing.Point(760, 305);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(642, 444);
            this.groupBox5.TabIndex = 43;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Output:";
            // 
            // lstAssembly
            // 
            this.lstAssembly.CheckBoxes = true;
            this.lstAssembly.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerMemoryLocation,
            this.headerAssembly,
            this.headerOpcode});
            this.lstAssembly.FullRowSelect = true;
            this.lstAssembly.GridLines = true;
            this.lstAssembly.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstAssembly.Location = new System.Drawing.Point(12, 38);
            this.lstAssembly.MultiSelect = false;
            this.lstAssembly.Name = "lstAssembly";
            this.lstAssembly.Size = new System.Drawing.Size(567, 711);
            this.lstAssembly.TabIndex = 0;
            this.lstAssembly.UseCompatibleStateImageBehavior = false;
            this.lstAssembly.View = System.Windows.Forms.View.Details;
            this.lstAssembly.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView1_ItemCheck);
            // 
            // headerMemoryLocation
            // 
            this.headerMemoryLocation.Text = "Memory Location";
            this.headerMemoryLocation.Width = 190;
            // 
            // headerAssembly
            // 
            this.headerAssembly.Text = "Assembly";
            this.headerAssembly.Width = 206;
            // 
            // headerOpcode
            // 
            this.headerOpcode.Text = "Opcode";
            this.headerOpcode.Width = 140;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "CPU State:";
            // 
            // lblCPUState
            // 
            this.lblCPUState.AutoSize = true;
            this.lblCPUState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPUState.ForeColor = System.Drawing.Color.Green;
            this.lblCPUState.Location = new System.Drawing.Point(78, 12);
            this.lblCPUState.Name = "lblCPUState";
            this.lblCPUState.Size = new System.Drawing.Size(47, 13);
            this.lblCPUState.TabIndex = 45;
            this.lblCPUState.Text = "IDLE...";
            // 
            // executionTimer
            // 
            this.executionTimer.Interval = 1;
            this.executionTimer.Tick += new System.EventHandler(this.executionTimer_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtFlagsOutBuffer);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtFlagsInBuffer);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.txtFlagsSaved);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.txtFlags);
            this.groupBox4.Location = new System.Drawing.Point(760, 230);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(642, 69);
            this.groupBox4.TabIndex = 41;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Flags";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(463, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "Flags OutBuffer:";
            // 
            // txtFlagsOutBuffer
            // 
            this.txtFlagsOutBuffer.Location = new System.Drawing.Point(464, 33);
            this.txtFlagsOutBuffer.Name = "txtFlagsOutBuffer";
            this.txtFlagsOutBuffer.Size = new System.Drawing.Size(100, 20);
            this.txtFlagsOutBuffer.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(270, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Flags InBuffer:";
            // 
            // txtFlagsInBuffer
            // 
            this.txtFlagsInBuffer.Location = new System.Drawing.Point(273, 33);
            this.txtFlagsInBuffer.Name = "txtFlagsInBuffer";
            this.txtFlagsInBuffer.Size = new System.Drawing.Size(100, 20);
            this.txtFlagsInBuffer.TabIndex = 37;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(138, 17);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(69, 13);
            this.label24.TabIndex = 36;
            this.label24.Text = "Flags Saved:";
            // 
            // txtFlagsSaved
            // 
            this.txtFlagsSaved.Location = new System.Drawing.Point(139, 33);
            this.txtFlagsSaved.Name = "txtFlagsSaved";
            this.txtFlagsSaved.Size = new System.Drawing.Size(100, 20);
            this.txtFlagsSaved.TabIndex = 35;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 17);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(35, 13);
            this.label28.TabIndex = 28;
            this.label28.Text = "Flags:";
            // 
            // txtFlags
            // 
            this.txtFlags.Location = new System.Drawing.Point(7, 33);
            this.txtFlags.Name = "txtFlags";
            this.txtFlags.Size = new System.Drawing.Size(100, 20);
            this.txtFlags.TabIndex = 27;
            // 
            // lblInstructionsExecuted
            // 
            this.lblInstructionsExecuted.AutoSize = true;
            this.lblInstructionsExecuted.Location = new System.Drawing.Point(585, 736);
            this.lblInstructionsExecuted.Name = "lblInstructionsExecuted";
            this.lblInstructionsExecuted.Size = new System.Drawing.Size(64, 13);
            this.lblInstructionsExecuted.TabIndex = 46;
            this.lblInstructionsExecuted.Text = "Instructions:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cmdInputPort_B);
            this.groupBox6.Controls.Add(this.cmdInputPortA);
            this.groupBox6.Controls.Add(this.txtOutputPortD);
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Controls.Add(this.txtInputPortA);
            this.groupBox6.Controls.Add(this.label26);
            this.groupBox6.Controls.Add(this.label27);
            this.groupBox6.Controls.Add(this.label29);
            this.groupBox6.Controls.Add(this.txtOutputPortC);
            this.groupBox6.Controls.Add(this.txtInputPortB);
            this.groupBox6.Location = new System.Drawing.Point(592, 436);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(169, 200);
            this.groupBox6.TabIndex = 26;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "I/O:";
            // 
            // cmdInputPort_B
            // 
            this.cmdInputPort_B.Location = new System.Drawing.Point(122, 73);
            this.cmdInputPort_B.Name = "cmdInputPort_B";
            this.cmdInputPort_B.Size = new System.Drawing.Size(29, 23);
            this.cmdInputPort_B.TabIndex = 48;
            this.cmdInputPort_B.Text = ">";
            this.cmdInputPort_B.UseVisualStyleBackColor = true;
            this.cmdInputPort_B.Click += new System.EventHandler(this.cmdInputPort_B_Click);
            // 
            // cmdInputPortA
            // 
            this.cmdInputPortA.Location = new System.Drawing.Point(122, 31);
            this.cmdInputPortA.Name = "cmdInputPortA";
            this.cmdInputPortA.Size = new System.Drawing.Size(29, 23);
            this.cmdInputPortA.TabIndex = 47;
            this.cmdInputPortA.Text = ">";
            this.cmdInputPortA.UseVisualStyleBackColor = true;
            this.cmdInputPortA.Click += new System.EventHandler(this.cmdInputPortA_Click);
            // 
            // txtOutputPortD
            // 
            this.txtOutputPortD.Location = new System.Drawing.Point(7, 169);
            this.txtOutputPortD.Name = "txtOutputPortD";
            this.txtOutputPortD.Size = new System.Drawing.Size(100, 20);
            this.txtOutputPortD.TabIndex = 16;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(8, 153);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(75, 13);
            this.label25.TabIndex = 17;
            this.label25.Text = "Output Port D:";
            // 
            // txtInputPortA
            // 
            this.txtInputPortA.Location = new System.Drawing.Point(6, 33);
            this.txtInputPortA.Name = "txtInputPortA";
            this.txtInputPortA.Size = new System.Drawing.Size(100, 20);
            this.txtInputPortA.TabIndex = 10;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 17);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(66, 13);
            this.label26.TabIndex = 12;
            this.label26.Text = "Input Port A:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 105);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(74, 13);
            this.label27.TabIndex = 15;
            this.label27.Text = "Output Port C:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 59);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(66, 13);
            this.label29.TabIndex = 13;
            this.label29.Text = "Input Port B:";
            // 
            // txtOutputPortC
            // 
            this.txtOutputPortC.Location = new System.Drawing.Point(6, 121);
            this.txtOutputPortC.Name = "txtOutputPortC";
            this.txtOutputPortC.Size = new System.Drawing.Size(100, 20);
            this.txtOutputPortC.TabIndex = 14;
            // 
            // txtInputPortB
            // 
            this.txtInputPortB.Location = new System.Drawing.Point(6, 75);
            this.txtInputPortB.Name = "txtInputPortB";
            this.txtInputPortB.Size = new System.Drawing.Size(100, 20);
            this.txtInputPortB.TabIndex = 11;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(9, 19);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(621, 411);
            this.txtOutput.TabIndex = 1;
            // 
            // cmdInputPortB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 761);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.lblInstructionsExecuted);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lblCPUState);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lstAssembly);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInstruction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdExecute);
            this.Controls.Add(this.cmdSingleStep);
            this.Controls.Add(this.txtProgramCounter);
            this.Controls.Add(this.cmdLoadProgram);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "cmdInputPortB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KPU Emulator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdLoadProgram;
        private System.Windows.Forms.TextBox txtProgramCounter;
        private System.Windows.Forms.Button cmdSingleStep;
        private System.Windows.Forms.Button cmdExecute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInstruction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInputA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOperation;
        private System.Windows.Forms.TextBox txtInputB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRegisterE;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRegisterD;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRegisterF;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRegisterG;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtRegisterXH;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRegisterXL;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRegisterH;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtRegisterZ;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtRegisterY;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtRegisterJ;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtRegisterBP;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtRegisterSP;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtRegisterM;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtRegisterX;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView lstAssembly;
        private System.Windows.Forms.ColumnHeader headerMemoryLocation;
        private System.Windows.Forms.ColumnHeader headerAssembly;
        private System.Windows.Forms.ColumnHeader headerOpcode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCPUState;
        private System.Windows.Forms.Timer executionTimer;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtFlagsSaved;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtFlags;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFlagsOutBuffer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFlagsInBuffer;
        private System.Windows.Forms.Label lblInstructionsExecuted;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtOutputPortD;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtInputPortA;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtOutputPortC;
        private System.Windows.Forms.TextBox txtInputPortB;
        private System.Windows.Forms.Button cmdInputPortA;
        private System.Windows.Forms.Button cmdInputPort_B;
        private System.Windows.Forms.TextBox txtOutput;
    }
}

