namespace ComputerAnalyzer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ShowProcessesBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.killProcess = new System.Windows.Forms.Button();
            this.killSingleProcess = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.sortBtn = new System.Windows.Forms.Button();
            this.hardwareComboBox = new System.Windows.Forms.ComboBox();
            this.hardwareGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.DisableDeviceBtn = new System.Windows.Forms.Button();
            this.UpdateDevicesList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.hardwareGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ShowProcessesBtn
            // 
            this.ShowProcessesBtn.BackColor = System.Drawing.Color.AliceBlue;
            this.ShowProcessesBtn.Location = new System.Drawing.Point(12, 12);
            this.ShowProcessesBtn.Name = "ShowProcessesBtn";
            this.ShowProcessesBtn.Size = new System.Drawing.Size(218, 29);
            this.ShowProcessesBtn.TabIndex = 0;
            this.ShowProcessesBtn.Text = "Update Processes List";
            this.ShowProcessesBtn.UseVisualStyleBackColor = false;
            this.ShowProcessesBtn.Click += new System.EventHandler(this.showProcesses_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1094, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 27);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1094, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(138, 27);
            this.textBox2.TabIndex = 6;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(12, 59);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(218, 344);
            this.listBox1.TabIndex = 7;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(257, 59);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(625, 284);
            this.listBox2.TabIndex = 8;
            // 
            // killProcess
            // 
            this.killProcess.Location = new System.Drawing.Point(257, 368);
            this.killProcess.Name = "killProcess";
            this.killProcess.Size = new System.Drawing.Size(187, 35);
            this.killProcess.TabIndex = 9;
            this.killProcess.Text = "Kill Parent Process";
            this.killProcess.UseVisualStyleBackColor = true;
            this.killProcess.Visible = false;
            this.killProcess.Click += new System.EventHandler(this.killProcess_Click);
            // 
            // killSingleProcess
            // 
            this.killSingleProcess.Location = new System.Drawing.Point(450, 368);
            this.killSingleProcess.Name = "killSingleProcess";
            this.killSingleProcess.Size = new System.Drawing.Size(187, 35);
            this.killSingleProcess.TabIndex = 10;
            this.killSingleProcess.Text = "Kill Selected Process";
            this.killSingleProcess.UseVisualStyleBackColor = true;
            this.killSingleProcess.Visible = false;
            this.killSingleProcess.Click += new System.EventHandler(this.killSingleProcess_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Name",
            "Memory"});
            this.comboBox1.Location = new System.Drawing.Point(12, 430);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(218, 28);
            this.comboBox1.TabIndex = 11;
            // 
            // sortBtn
            // 
            this.sortBtn.Location = new System.Drawing.Point(12, 464);
            this.sortBtn.Name = "sortBtn";
            this.sortBtn.Size = new System.Drawing.Size(218, 35);
            this.sortBtn.TabIndex = 12;
            this.sortBtn.Text = "Sort";
            this.sortBtn.UseVisualStyleBackColor = true;
            this.sortBtn.Click += new System.EventHandler(this.sortBtn_Click);
            // 
            // hardwareComboBox
            // 
            this.hardwareComboBox.FormattingEnabled = true;
            this.hardwareComboBox.Location = new System.Drawing.Point(908, 106);
            this.hardwareComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hardwareComboBox.Name = "hardwareComboBox";
            this.hardwareComboBox.Size = new System.Drawing.Size(138, 28);
            this.hardwareComboBox.TabIndex = 2;
            this.hardwareComboBox.SelectedIndexChanged += new System.EventHandler(this.hardwareComboBox_SelectedIndexChanged);
            // 
            // hardwareGridView
            // 
            this.hardwareGridView.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.hardwareGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hardwareGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hardwareGridView.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.hardwareGridView.Location = new System.Drawing.Point(908, 155);
            this.hardwareGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hardwareGridView.Name = "hardwareGridView";
            this.hardwareGridView.RowHeadersWidth = 51;
            this.hardwareGridView.RowTemplate.Height = 25;
            this.hardwareGridView.Size = new System.Drawing.Size(693, 344);
            this.hardwareGridView.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(908, 12);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(119, 30);
            this.label1.TabIndex = 13;
            this.label1.Text = "Memory Usage";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label3.Location = new System.Drawing.Point(908, 59);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5);
            this.label3.Size = new System.Drawing.Size(91, 30);
            this.label3.TabIndex = 15;
            this.label3.Text = "CPU Usage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(257, 12);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.label2.Size = new System.Drawing.Size(91, 33);
            this.label2.TabIndex = 16;
            this.label2.Text = "Processes";
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 20;
            this.listBox3.Location = new System.Drawing.Point(257, 446);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(1344, 284);
            this.listBox3.TabIndex = 17;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // DisableDeviceBtn
            // 
            this.DisableDeviceBtn.Location = new System.Drawing.Point(450, 774);
            this.DisableDeviceBtn.Name = "DisableDeviceBtn";
            this.DisableDeviceBtn.Size = new System.Drawing.Size(187, 29);
            this.DisableDeviceBtn.TabIndex = 18;
            this.DisableDeviceBtn.Text = "Disable Selected Device";
            this.DisableDeviceBtn.UseVisualStyleBackColor = true;
            this.DisableDeviceBtn.Click += new System.EventHandler(this.DisableDevice_Click);
            // 
            // UpdateDevicesList
            // 
            this.UpdateDevicesList.Location = new System.Drawing.Point(257, 774);
            this.UpdateDevicesList.Name = "UpdateDevicesList";
            this.UpdateDevicesList.Size = new System.Drawing.Size(174, 29);
            this.UpdateDevicesList.TabIndex = 19;
            this.UpdateDevicesList.Text = "Update Devices List";
            this.UpdateDevicesList.UseVisualStyleBackColor = true;
            this.UpdateDevicesList.Click += new System.EventHandler(this.UpdateDevicesList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1613, 1045);
            this.Controls.Add(this.UpdateDevicesList);
            this.Controls.Add(this.DisableDeviceBtn);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hardwareGridView);
            this.Controls.Add(this.hardwareComboBox);
            this.Controls.Add(this.sortBtn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.killSingleProcess);
            this.Controls.Add(this.killProcess);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ShowProcessesBtn);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "ComputerAnalyzer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hardwareGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComboBox hardwareComboBox;
        private DataGridView hardwareGridView;
        private Button ShowProcessesBtn;
        private Button ShowMemoryUsageBtn;
        private Button ShowCPUUsageBtn;
        private TextBox textBox1;
        private TextBox textBox2;
        private ListBox listBox1;
        private ListBox listBox2;
        private Button killProcess;
        private Button killSingleProcess;
        private System.Windows.Forms.Timer timer1;
        private ComboBox comboBox1;
        private Button sortBtn;
        private Label label1;
        private Label label3;
        private Label label2;
        private ListBox listBox3;
        private Button DisableDeviceBtn;
        private Button UpdateDevicesList;
    }
}