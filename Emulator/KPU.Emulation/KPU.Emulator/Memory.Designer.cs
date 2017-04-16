namespace KPU.Emulator
{
    partial class Memory
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
            this.lstMemory = new System.Windows.Forms.ListView();
            this.headerAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstMemory
            // 
            this.lstMemory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerAddress,
            this.header1,
            this.header2,
            this.header3,
            this.header4,
            this.header5,
            this.header6,
            this.header7,
            this.header8,
            this.header9,
            this.header10,
            this.header11,
            this.header12,
            this.header13,
            this.header14,
            this.header15,
            this.header16});
            this.lstMemory.FullRowSelect = true;
            this.lstMemory.GridLines = true;
            this.lstMemory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstMemory.Location = new System.Drawing.Point(12, 54);
            this.lstMemory.Name = "lstMemory";
            this.lstMemory.Size = new System.Drawing.Size(1047, 518);
            this.lstMemory.TabIndex = 0;
            this.lstMemory.UseCompatibleStateImageBehavior = false;
            this.lstMemory.View = System.Windows.Forms.View.Details;
            // 
            // headerAddress
            // 
            this.headerAddress.Text = "Address";
            // 
            // header1
            // 
            this.header1.Text = "0";
            // 
            // header2
            // 
            this.header2.Text = "1";
            // 
            // header3
            // 
            this.header3.Text = "2";
            // 
            // header4
            // 
            this.header4.Text = "3";
            // 
            // header5
            // 
            this.header5.Text = "4";
            // 
            // header6
            // 
            this.header6.Text = "5";
            // 
            // header7
            // 
            this.header7.Text = "6";
            // 
            // header8
            // 
            this.header8.Text = "7";
            // 
            // header9
            // 
            this.header9.Text = "8";
            // 
            // header10
            // 
            this.header10.Text = "9";
            // 
            // header11
            // 
            this.header11.Text = "A";
            // 
            // header12
            // 
            this.header12.Text = "B";
            // 
            // header13
            // 
            this.header13.Text = "C";
            // 
            // header14
            // 
            this.header14.Text = "D";
            // 
            // header15
            // 
            this.header15.Text = "E";
            // 
            // header16
            // 
            this.header16.Text = "F";
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(12, 12);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(75, 23);
            this.cmdRefresh.TabIndex = 1;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // Memory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 584);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.lstMemory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Memory";
            this.Text = "Memory";
            this.Load += new System.EventHandler(this.Memory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstMemory;
        private System.Windows.Forms.ColumnHeader headerAddress;
        private System.Windows.Forms.ColumnHeader header1;
        private System.Windows.Forms.ColumnHeader header2;
        private System.Windows.Forms.ColumnHeader header3;
        private System.Windows.Forms.ColumnHeader header4;
        private System.Windows.Forms.ColumnHeader header5;
        private System.Windows.Forms.ColumnHeader header6;
        private System.Windows.Forms.ColumnHeader header7;
        private System.Windows.Forms.ColumnHeader header8;
        private System.Windows.Forms.ColumnHeader header9;
        private System.Windows.Forms.ColumnHeader header10;
        private System.Windows.Forms.ColumnHeader header11;
        private System.Windows.Forms.ColumnHeader header12;
        private System.Windows.Forms.ColumnHeader header13;
        private System.Windows.Forms.ColumnHeader header14;
        private System.Windows.Forms.ColumnHeader header15;
        private System.Windows.Forms.ColumnHeader header16;
        private System.Windows.Forms.Button cmdRefresh;
    }
}