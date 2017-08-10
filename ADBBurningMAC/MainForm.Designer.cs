namespace ADBBurningMAC
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lable14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.eepromVersion = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.displayResolution = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.currentMAC = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.deleteAllMac = new System.Windows.Forms.Button();
            this.deleteMac = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.macB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addMAC = new System.Windows.Forms.Button();
            this.macE = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.macLV = new System.Windows.Forms.ListView();
            this.adbCmd = new System.Windows.Forms.Button();
            this.cleanOutputMessage = new System.Windows.Forms.Button();
            this.adbcmdShow = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BurningStatue = new System.Windows.Forms.Button();
            this.BurningProgressBar = new System.Windows.Forms.ProgressBar();
            this.tablepage = new System.Windows.Forms.TabControl();
            this.softwarePartNumber = new System.Windows.Forms.TabPage();
            this.eepVersion = new System.Windows.Forms.TabPage();
            this.logoID = new System.Windows.Forms.TabPage();
            this.displayArgs = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.colorDepth = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tablepage.SuspendLayout();
            this.softwarePartNumber.SuspendLayout();
            this.eepVersion.SuspendLayout();
            this.logoID.SuspendLayout();
            this.displayArgs.SuspendLayout();
            this.SuspendLayout();
            // 
            // lable14
            // 
            this.lable14.AutoSize = true;
            this.lable14.Location = new System.Drawing.Point(23, 14);
            this.lable14.Name = "lable14";
            this.lable14.Size = new System.Drawing.Size(84, 14);
            this.lable14.TabIndex = 1;
            this.lable14.Text = "Resolution:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "Version: ";
            // 
            // eepromVersion
            // 
            this.eepromVersion.FormattingEnabled = true;
            this.eepromVersion.Location = new System.Drawing.Point(186, 22);
            this.eepromVersion.Name = "eepromVersion";
            this.eepromVersion.Size = new System.Drawing.Size(71, 22);
            this.eepromVersion.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tablepage);
            this.groupBox5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(9, 261);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(631, 129);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Select Argument";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Software Part Number:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(211, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(69, 22);
            this.comboBox1.TabIndex = 0;
            // 
            // displayResolution
            // 
            this.displayResolution.FormattingEnabled = true;
            this.displayResolution.Location = new System.Drawing.Point(112, 11);
            this.displayResolution.Name = "displayResolution";
            this.displayResolution.Size = new System.Drawing.Size(69, 22);
            this.displayResolution.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(142, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 14);
            this.label7.TabIndex = 1;
            this.label7.Text = "Logo:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(289, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 23);
            this.textBox1.TabIndex = 3;
            // 
            // currentMAC
            // 
            this.currentMAC.AutoSize = true;
            this.currentMAC.Location = new System.Drawing.Point(99, 23);
            this.currentMAC.Name = "currentMAC";
            this.currentMAC.Size = new System.Drawing.Size(126, 14);
            this.currentMAC.TabIndex = 19;
            this.currentMAC.Text = "00:00:00:00:00:00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 14);
            this.label5.TabIndex = 18;
            this.label5.Text = "Selected MAC: ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.macLV);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(9, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(631, 240);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Database";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.currentMAC);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.deleteAllMac);
            this.groupBox3.Controls.Add(this.deleteMac);
            this.groupBox3.Location = new System.Drawing.Point(400, 139);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 95);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Delete MAC";
            // 
            // deleteAllMac
            // 
            this.deleteAllMac.Location = new System.Drawing.Point(115, 51);
            this.deleteAllMac.Name = "deleteAllMac";
            this.deleteAllMac.Size = new System.Drawing.Size(101, 33);
            this.deleteAllMac.TabIndex = 20;
            this.deleteAllMac.Text = "Delete All";
            this.deleteAllMac.UseVisualStyleBackColor = true;
            // 
            // deleteMac
            // 
            this.deleteMac.Location = new System.Drawing.Point(10, 51);
            this.deleteMac.Name = "deleteMac";
            this.deleteMac.Size = new System.Drawing.Size(102, 33);
            this.deleteMac.TabIndex = 16;
            this.deleteMac.Text = "Delete";
            this.deleteMac.UseVisualStyleBackColor = true;
            this.deleteMac.Click += new System.EventHandler(this.deleteDB);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.macB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.addMAC);
            this.groupBox1.Controls.Add(this.macE);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(400, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 111);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add MAC";
            // 
            // macB
            // 
            this.macB.Location = new System.Drawing.Point(82, 18);
            this.macB.Name = "macB";
            this.macB.Size = new System.Drawing.Size(134, 23);
            this.macB.TabIndex = 1;
            this.macB.Text = "00:00:00:00:00:00";
            this.macB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "MAC Begin:";
            // 
            // addMAC
            // 
            this.addMAC.Location = new System.Drawing.Point(37, 76);
            this.addMAC.Name = "addMAC";
            this.addMAC.Size = new System.Drawing.Size(146, 28);
            this.addMAC.TabIndex = 0;
            this.addMAC.Text = "Add MAC";
            this.addMAC.UseVisualStyleBackColor = true;
            this.addMAC.Click += new System.EventHandler(this.addMACClick);
            // 
            // macE
            // 
            this.macE.Location = new System.Drawing.Point(82, 47);
            this.macE.Name = "macE";
            this.macE.Size = new System.Drawing.Size(134, 23);
            this.macE.TabIndex = 4;
            this.macE.Text = "00:00:00:00:00:00";
            this.macE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "MAC End:";
            // 
            // macLV
            // 
            this.macLV.GridLines = true;
            this.macLV.Location = new System.Drawing.Point(13, 22);
            this.macLV.Name = "macLV";
            this.macLV.Size = new System.Drawing.Size(378, 212);
            this.macLV.TabIndex = 14;
            this.macLV.UseCompatibleStateImageBehavior = false;
            this.macLV.View = System.Windows.Forms.View.Details;
            this.macLV.SelectedIndexChanged += new System.EventHandler(this.macLV_SelectedIndexChanged);
            // 
            // adbCmd
            // 
            this.adbCmd.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.adbCmd.Location = new System.Drawing.Point(550, 20);
            this.adbCmd.Name = "adbCmd";
            this.adbCmd.Size = new System.Drawing.Size(75, 80);
            this.adbCmd.TabIndex = 7;
            this.adbCmd.Text = "ADB Write";
            this.adbCmd.UseVisualStyleBackColor = true;
            this.adbCmd.Click += new System.EventHandler(this.adbCmdClick);
            // 
            // cleanOutputMessage
            // 
            this.cleanOutputMessage.Location = new System.Drawing.Point(550, 113);
            this.cleanOutputMessage.Name = "cleanOutputMessage";
            this.cleanOutputMessage.Size = new System.Drawing.Size(75, 49);
            this.cleanOutputMessage.TabIndex = 12;
            this.cleanOutputMessage.Text = "Clean";
            this.cleanOutputMessage.UseVisualStyleBackColor = true;
            this.cleanOutputMessage.Click += new System.EventHandler(this.cleanAdbCmdShowClick);
            // 
            // adbcmdShow
            // 
            this.adbcmdShow.Location = new System.Drawing.Point(13, 20);
            this.adbcmdShow.Multiline = true;
            this.adbcmdShow.Name = "adbcmdShow";
            this.adbcmdShow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.adbcmdShow.Size = new System.Drawing.Size(531, 142);
            this.adbcmdShow.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BurningStatue);
            this.groupBox2.Controls.Add(this.cleanOutputMessage);
            this.groupBox2.Controls.Add(this.adbcmdShow);
            this.groupBox2.Controls.Add(this.adbCmd);
            this.groupBox2.Controls.Add(this.BurningProgressBar);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(9, 396);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(631, 197);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ADB To EEPROM Output Message";
            // 
            // BurningStatue
            // 
            this.BurningStatue.Location = new System.Drawing.Point(562, 170);
            this.BurningStatue.Name = "BurningStatue";
            this.BurningStatue.Size = new System.Drawing.Size(52, 23);
            this.BurningStatue.TabIndex = 14;
            this.BurningStatue.UseVisualStyleBackColor = true;
            // 
            // BurningProgressBar
            // 
            this.BurningProgressBar.Location = new System.Drawing.Point(10, 169);
            this.BurningProgressBar.Name = "BurningProgressBar";
            this.BurningProgressBar.Size = new System.Drawing.Size(534, 23);
            this.BurningProgressBar.TabIndex = 13;
            // 
            // tablepage
            // 
            this.tablepage.Controls.Add(this.softwarePartNumber);
            this.tablepage.Controls.Add(this.eepVersion);
            this.tablepage.Controls.Add(this.logoID);
            this.tablepage.Controls.Add(this.displayArgs);
            this.tablepage.Location = new System.Drawing.Point(13, 23);
            this.tablepage.Name = "tablepage";
            this.tablepage.SelectedIndex = 0;
            this.tablepage.Size = new System.Drawing.Size(612, 100);
            this.tablepage.TabIndex = 15;
            // 
            // softwarePartNumber
            // 
            this.softwarePartNumber.Controls.Add(this.label3);
            this.softwarePartNumber.Controls.Add(this.textBox1);
            this.softwarePartNumber.Location = new System.Drawing.Point(4, 24);
            this.softwarePartNumber.Name = "softwarePartNumber";
            this.softwarePartNumber.Padding = new System.Windows.Forms.Padding(3);
            this.softwarePartNumber.Size = new System.Drawing.Size(604, 72);
            this.softwarePartNumber.TabIndex = 0;
            this.softwarePartNumber.Text = "Part Number";
            this.softwarePartNumber.UseVisualStyleBackColor = true;
            // 
            // eepVersion
            // 
            this.eepVersion.Controls.Add(this.label4);
            this.eepVersion.Controls.Add(this.eepromVersion);
            this.eepVersion.Location = new System.Drawing.Point(4, 24);
            this.eepVersion.Name = "eepVersion";
            this.eepVersion.Padding = new System.Windows.Forms.Padding(3);
            this.eepVersion.Size = new System.Drawing.Size(604, 72);
            this.eepVersion.TabIndex = 1;
            this.eepVersion.Text = "EEPROM Version";
            this.eepVersion.UseVisualStyleBackColor = true;
            // 
            // logoID
            // 
            this.logoID.Controls.Add(this.comboBox1);
            this.logoID.Controls.Add(this.label7);
            this.logoID.Location = new System.Drawing.Point(4, 24);
            this.logoID.Name = "logoID";
            this.logoID.Padding = new System.Windows.Forms.Padding(3);
            this.logoID.Size = new System.Drawing.Size(604, 72);
            this.logoID.TabIndex = 2;
            this.logoID.Text = "Logo ID";
            this.logoID.UseVisualStyleBackColor = true;
            // 
            // displayArgs
            // 
            this.displayArgs.Controls.Add(this.textBox2);
            this.displayArgs.Controls.Add(this.label9);
            this.displayArgs.Controls.Add(this.label8);
            this.displayArgs.Controls.Add(this.colorDepth);
            this.displayArgs.Controls.Add(this.label6);
            this.displayArgs.Controls.Add(this.displayResolution);
            this.displayArgs.Controls.Add(this.lable14);
            this.displayArgs.Location = new System.Drawing.Point(4, 24);
            this.displayArgs.Name = "displayArgs";
            this.displayArgs.Padding = new System.Windows.Forms.Padding(3);
            this.displayArgs.Size = new System.Drawing.Size(604, 72);
            this.displayArgs.TabIndex = 3;
            this.displayArgs.Text = "Display";
            this.displayArgs.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(203, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 14);
            this.label6.TabIndex = 1;
            this.label6.Text = "Color Depth:";
            // 
            // colorDepth
            // 
            this.colorDepth.FormattingEnabled = true;
            this.colorDepth.Location = new System.Drawing.Point(292, 11);
            this.colorDepth.Name = "colorDepth";
            this.colorDepth.Size = new System.Drawing.Size(69, 22);
            this.colorDepth.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(420, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 1;
            this.label8.Text = "Frame:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(475, 10);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(61, 23);
            this.textBox2.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(542, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 14);
            this.label9.TabIndex = 1;
            this.label9.Text = "FPS";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 601);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Name = "MainForm";
            this.Text = "ADBBurningMAC";
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tablepage.ResumeLayout(false);
            this.softwarePartNumber.ResumeLayout(false);
            this.softwarePartNumber.PerformLayout();
            this.eepVersion.ResumeLayout(false);
            this.eepVersion.PerformLayout();
            this.logoID.ResumeLayout(false);
            this.logoID.PerformLayout();
            this.displayArgs.ResumeLayout(false);
            this.displayArgs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lable14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox eepromVersion;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox displayResolution;
        private System.Windows.Forms.Label currentMAC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView macLV;
        private System.Windows.Forms.Button deleteMac;
        private System.Windows.Forms.Button cleanOutputMessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addMAC;
        private System.Windows.Forms.TextBox macB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox macE;
        private System.Windows.Forms.TextBox adbcmdShow;
        private System.Windows.Forms.Button adbCmd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button deleteAllMac;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar BurningProgressBar;
        private System.Windows.Forms.Button BurningStatue;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tablepage;
        private System.Windows.Forms.TabPage softwarePartNumber;
        private System.Windows.Forms.TabPage eepVersion;
        private System.Windows.Forms.TabPage logoID;
        private System.Windows.Forms.TabPage displayArgs;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox colorDepth;
        private System.Windows.Forms.Label label6;
    }
}

