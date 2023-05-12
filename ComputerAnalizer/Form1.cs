using Microsoft.VisualBasic;
using Microsoft.Win32;
using System.Data;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Windows.Forms;

namespace ComputerAnalyzer
{
    public partial class Form1 : Form
    {
        private PerformanceCounter cpucounter;
        private PerformanceCounter memcounter;

        public Form1()
        {
            cpucounter = new PerformanceCounter();
            memcounter = new PerformanceCounter();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hardwareComboBox.Items.Add("CPU");
            hardwareComboBox.Items.Add("GPU");
            hardwareComboBox.Items.Add("Motherboard");
            hardwareComboBox.Items.Add("RAM");
            hardwareComboBox.Items.Add("External Devices");
            hardwareComboBox.SelectedIndex = 0;

            hardwareGridView.AllowUserToAddRows = false;
            hardwareGridView.AllowUserToDeleteRows = false;
            hardwareGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cpucounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            memcounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
            timer1.Interval = 1000;
            timer1.Start();

            showProcesses_Click(null, null);
            showConnectedDevices();
        }

        private void hardwareComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Value", typeof(string));

            if (hardwareComboBox.SelectedIndex == 0)
            {
                foreach (var mo in new ManagementObjectSearcher("root\\cimv2", "select * from win32_processor").Get())
                {
                    table.Rows.Add("Name", (string)mo["name"]);
                    table.Rows.Add("Caption", (string)mo["caption"]);

                    string numberOfCores = mo["NumberOfCores"].ToString();
                    table.Rows.Add("NumberOfCors", numberOfCores);

                    string numberOfEnabledCore = mo["NumberOfEnabledCore"].ToString();
                    table.Rows.Add("NumberOfEnabledCore", numberOfEnabledCore);

                    string numberOfLogicalProcessors = mo["NumberOfLogicalProcessors"].ToString();
                    table.Rows.Add("NumberOfLogicalProcessors", numberOfLogicalProcessors);

                    string maxClockSpeed = mo["MaxClockSpeed"].ToString();
                    table.Rows.Add("MaxClockSpeed", maxClockSpeed);

                    string threadCount = mo["ThreadCount"].ToString();
                    table.Rows.Add("ThreadCount", threadCount);
                }
              
            }
            else if (hardwareComboBox.SelectedIndex == 1)
            {
                foreach (var mo in new ManagementObjectSearcher("root\\cimv2", "select * from win32_videocontroller").Get())
                {
                    table.Rows.Add("Name", (string)mo["name"]);
                    table.Rows.Add("AdapterCompatibility", (string)mo["AdapterCompatibility"]);
                    table.Rows.Add("DeviceID", (string)mo["DeviceID"]);

                    string availability = mo["Availability"].ToString();
                    table.Rows.Add("Availability", availability);

                    table.Rows.Add("", "");
                }
            }
            else if (hardwareComboBox.SelectedIndex == 2)
            {
                foreach (var mo in new ManagementObjectSearcher("root\\cimv2", "select * from win32_baseboard").Get())
                {
                    table.Rows.Add("Product", (string)mo["Product"]);
                    table.Rows.Add("Caption", (string)mo["caption"]);

                    string poweredOn = mo["PoweredOn"].ToString();
                    table.Rows.Add("PoweredOn", poweredOn);

                    table.Rows.Add("Manufacturer", (string)mo["Manufacturer"]);

                    string removable = mo["removable"].ToString();
                    table.Rows.Add("Removable", removable);

                    string replaceable = mo["replaceable"].ToString();
                    table.Rows.Add("Replaceable", replaceable);
                }
                  
            }
            else if (hardwareComboBox.SelectedIndex == 3)
            {
                //Win32_PhysicalMemory
                foreach (var mo in new ManagementObjectSearcher("root\\cimv2", "select * from win32_PhysicalMemory").Get())
                {
                    table.Rows.Add("Name", (string)mo["name"]);
                    table.Rows.Add("Caption", (string)mo["caption"]);
                    table.Rows.Add("Speed", (uint)mo["speed"]);
                    table.Rows.Add("Capacity", Convert.ToDouble(mo["capacity"]) / 1073741824 + "GB");
                }
            }
            else if (hardwareComboBox.SelectedIndex == 4)
            {
                //Win32_USBHub
                foreach (var mo in new ManagementObjectSearcher("root\\cimv2", "select * from Win32_USBHub").Get())
                {
                    table.Rows.Add("Name", (string)mo["Name"]);
                    table.Rows.Add("DeviceID", (string)mo["DeviceID"]);
                    table.Rows.Add("PNPDeviceID", (string)mo["PNPDeviceID"]);
                    table.Rows.Add("Status", (string)mo["status"]);

                    table.Rows.Add("", "");
                }
            }

            hardwareGridView.DataSource = table;
        }

        Dictionary<string, List<Process>> processes = new Dictionary<string, List<Process>>();

        private void showProcesses_Click(object sender, EventArgs e)
        {
            var procList = new List<string>();
            processes.Clear();
            procList.Clear();
            listBox2.Items.Clear();
            listBox1.Items.Clear();

            foreach (var winProc in Process.GetProcesses())
            {
                if (!processes.ContainsKey(winProc.ProcessName))
                {
                    processes.Add(winProc.ProcessName, new List<Process>());
                    processes[winProc.ProcessName].Add(winProc);
                }
                else
                {
                    processes[winProc.ProcessName].Add(winProc);
                }
            }

            foreach (var processname in processes.Keys)
            {
                procList.Add(processname);
            }

            foreach (var item in procList)
            {
                listBox1.Items.Add(item);
            }
        }

        private void showMemoryUsage_Click(object sender, EventArgs e)
        {
            isMemClicked = true;
            if (!timer1.Enabled)
            {
                timer1.Start();
            }
            textBox1.Text = memcounter.NextValue().ToString() + " %";
        }

        private void showCPUUsage_Click(object sender, EventArgs e)
        {
            isProcClicked = true;
            if (!timer1.Enabled)
            {
                timer1.Start();
            }
            textBox2.Text = cpucounter.NextValue().ToString() + " %";
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            listBox2.Items.Clear();

            var myproc = processes[listBox1.SelectedItem.ToString()];

            foreach (var proc in myproc)
            {
                listBox2.Items.Add(string.Format("Process: {0}, Memory: {1}", proc.Id, proc.PagedMemorySize64));
            }

            killProcess.Visible = true;
            killSingleProcess.Visible = true;
        }

        private void killProcess_Click(object sender, EventArgs e)
        {
            var myproc = processes[listBox1.SelectedItem.ToString()];

            foreach (var proc in myproc)
            {
                try { proc.Kill(); }
                catch
                {
                    MessageBox.Show("Process can't be killed!");
                }

            }

            showProcesses_Click(null, null);
        }

        private void killSingleProcess_Click(object sender, EventArgs e)
        {
            var myproc = processes[listBox1.SelectedItem.ToString()];

            if (listBox2.SelectedIndex != -1)
            {
                try { myproc[listBox2.SelectedIndex].Kill(); }
                catch
                {
                    MessageBox.Show("Process can't be killed!");
                }
                showProcesses_Click(null, null);
            }
            else
            {
                MessageBox.Show("Pick Process!");
            }

        }

        private bool isMemClicked = true;
        private bool isProcClicked = true;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isMemClicked)
            {
                textBox1.Text = memcounter.NextValue().ToString() + " %";
            }
            if (isProcClicked)
            {
                textBox2.Text = cpucounter.NextValue().ToString() + " %";
            }
        }

        private void sortBtn_Click(object sender, EventArgs e)
        {
            var procList = new List<string>();
            processes.Clear();
            procList.Clear();
            listBox2.Items.Clear();
            listBox1.Items.Clear();
            foreach (var winProc in Process.GetProcesses())
            {
                if (!processes.ContainsKey(winProc.ProcessName))
                {
                    processes.Add(winProc.ProcessName, new List<Process>());
                    processes[winProc.ProcessName].Add(winProc);
                }
                else
                {
                    processes[winProc.ProcessName].Add(winProc);
                }
            }
            foreach (var processname in processes.Keys)
            {
                procList.Add(processname);
            }
            procList.Sort();
            var orderedProcess = from proc in procList orderby processes[proc].Sum(x => x.PagedMemorySize64) select proc;
            var orderedlist = orderedProcess.ToList();
            orderedlist.Reverse();

            switch (comboBox1.SelectedIndex)
            {
                case -1:
                    MessageBox.Show("Select sorting type!");
                    break;
                case 0:
                    foreach (var item in procList)
                    {
                        listBox1.Items.Add(item);
                    }
                    break;
                case 1:
                    foreach (var item in orderedlist)
                    {
                        listBox1.Items.Add(item);
                    }
                    break;
            }
        }

        private void showConnectedDevices()
        {
            listBox3.Items.Clear();
               
            foreach (var mo in new ManagementObjectSearcher("root\\cimv2", "select * from Win32_USBHub").Get())
            {
                listBox3.Items.Add(string.Format("Name: {0}, DeviceId: {1}", (string)mo["name"], (string)mo["deviceid"]));
            }  
        }

        private void DisableDevice_Click(object sender, EventArgs e)
        { 
            [DllImport("shell32")] static extern bool IsUserAnAdmin();
            
            if (IsUserAnAdmin() == false)
            {
                MessageBox.Show("You are not admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (listBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Select device!");
                return;
            }

            string selectedDevice = listBox3.SelectedItem.ToString().Split(' ').AsQueryable().Last();
            string objectPath = string.Format("Win32_PnPEntity.DeviceID='{0}'", selectedDevice);

            ManagementObject device = new ManagementObject(objectPath);
            try
            {
                MessageBox.Show("Device disabled!");
                device.InvokeMethod("Disable", null);
            } catch {  }
        }

        private void UpdateDevicesList_Click(object sender, EventArgs e)
        {
            showConnectedDevices();
        }

        private void EnableDeviceBtn_Click(object sender, EventArgs e)
        {
            [DllImport("shell32")] static extern bool IsUserAnAdmin();

            if (IsUserAnAdmin() == false)
            {
                MessageBox.Show("You are not admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Select device!");
                return;
            }

            string selectedDevice = listBox3.SelectedItem.ToString().Split(' ').AsQueryable().Last();
            string objectPath = string.Format("Win32_PnPEntity.DeviceID='{0}'", selectedDevice);

            ManagementObject device = new ManagementObject(objectPath);

            try
            {
                MessageBox.Show("Device Enabled!");
                device.InvokeMethod("Enable", null);
            }
            catch { }
        }
    }
}