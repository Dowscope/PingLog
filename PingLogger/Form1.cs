/*
 * Ping Logger
 * Version: 1.1.0
 * Author: Timothy Dowling
 * Created On: Nov 14, 2022
 * Modified On: Nov 15, 2022
 * Github: https://github.com/Dowscope/PingLog
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace PingLogger
{
    public partial class frmMain : Form
    {
        DateTime startTime;
        DateTime endTime;

        List<string> pingConsole = new List<string>();
        List<string> ipcConsole = new List<string>();

        bool isConnected = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void RunPing()
        {
            // Vefore starting, grab the first IPConfig.
            getIPConfig("Initial IP before the pinging " + txtIP.Text + " starts", "N/A");

            Process p = new Process();
            p.StartInfo.FileName = "ping";
            p.StartInfo.Arguments = "-t " + txtIP.Text;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.OutputDataReceived += new DataReceivedEventHandler(OnOutput);

            p.Start();
            p.BeginOutputReadLine();
        }
        private void getIPConfig(string pingLog, string lastPing)
        {
            if (pingLog.Contains("Initial"))
            {
                btnStop.Invoke(new Action(() =>
                {
                    txtIPCInfo.Text = "";
                }));
            }

            Process p = new Process();
            p.StartInfo.FileName = "ipconfig";
            p.StartInfo.Arguments = "/all";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            OnIPCOutput(p.StandardOutput.ReadToEndAsync().Result, lastPing, pingLog);
            p.WaitForExit();

            Process p2 = new Process();
            p2.StartInfo.FileName = "netsh";
            p2.StartInfo.Arguments = "wlan show interfaces";
            p2.StartInfo.CreateNoWindow = true;
            p2.StartInfo.UseShellExecute = false;
            p2.StartInfo.RedirectStandardOutput = true;
            p2.Start();
            OnNetOutput(p2.StandardOutput.ReadToEndAsync().Result);
            p2.WaitForExit();
        }

        // Callbacks
        private void OnOutput(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                bool madeConnection = true;
                if (e.Data.Contains("Request timed out"))
                {
                    madeConnection = false;
                }

                // Check if we made a successful connection
                if (!isConnected && e.Data.Contains("Reply from"))
                {
                    isConnected = true;
                }

                // Check if the line is the same as the last line.
                if (isConnected && 
                    !pingConsole.Last().Contains(e.Data) &&
                    !pingConsole.Last().Contains("Pinging") &&
                    !pingConsole.Last().Contains("Starting"))
                {
                    getIPConfig(e.Data, pingConsole.Last());
                }

                // Log String
                string logString = "[" + DateTime.Now + "] " + e.Data + Environment.NewLine;

                // Add the line to the array for saving later.
                pingConsole.Add(logString);

                btnStop.Invoke(new Action(() =>
                {
                    txtInfo.Text += logString;
                
                    if (!madeConnection)
                    {
                        lblConnection.Visible = true;
                    }
                }));
            }
        }
        private void OnIPCOutput(string data, string lastPing, string pingLog)
        {
            if (!string.IsNullOrEmpty(data))
            {
                string s1 = "*****************************************" + Environment.NewLine;
                string s2 = "*****************************************" + Environment.NewLine;
                string s3 = "IPCONFIG Capture at " + DateTime.Now + Environment.NewLine;
                string s4 = "Last Ping Line:  " + lastPing + Environment.NewLine;
                string s5 = "Current Ping Line:  " + pingLog + Environment.NewLine;

                ipcConsole.Add(s1);
                ipcConsole.Add(s2);
                ipcConsole.Add(s3);
                ipcConsole.Add(s4);
                ipcConsole.Add(s5);

                // Add the line to the array for saving later.
                string s = data + Environment.NewLine;
                ipcConsole.Add(s);

                btnStart.Invoke(new Action(() =>
                {
                    txtIPCInfo.Text += s1;
                    txtIPCInfo.Text += s2;
                    txtIPCInfo.Text += s3;
                    txtIPCInfo.Text += s4;
                    txtIPCInfo.Text += s5;
                    txtIPCInfo.Text += s;
                }));
                
            }
        }
        private void OnNetOutput(string e)
        {
            if (!string.IsNullOrEmpty(e))
            {
                string s1 = "*****************************************" + Environment.NewLine;
                string s2 = "NETSH Capture at " + DateTime.Now + Environment.NewLine;

                ipcConsole.Add(s1);
                ipcConsole.Add(s2);

                // Add the line to the array for saving later.
                string s = e + Environment.NewLine;
                ipcConsole.Add(s);

                btnStart.Invoke(new Action(() =>
                {
                    txtIPCInfo.Text += s1;
                    txtIPCInfo.Text += s2;
                    txtIPCInfo.Text += s;
                }));

            }
        }

        // UI Button Clicks
        private void button1_Click(object sender, EventArgs e)
        {
            // Check if IP Address has enough characters
            // x.x.x.x = 7 characters
            // xxx.xxx.xxx.xxx = 15 characters
            if (txtIP.Text.Length < 7 || txtIP.Text.Length > 15)
            {
                lblIPError.Visible = true;
                return;
            }

            // Check if a valid IP address
            IPAddress address;
            if (!IPAddress.TryParse(txtIP.Text, out address))
            {
                lblIPError.Visible = true;
                return;
            }

            // Clear the log variables
            pingConsole.Clear();
            ipcConsole.Clear();

            // If the error is visible switch off
            lblIPError.Visible = false;

            // Disable the start btn to prevent it being pressed twice
            btnStart.Enabled = false;
            btnStart.BackColor = Color.LightGray;

            // Enable the STOP button
            btnStop.Enabled = true;
            btnStop.BackColor = Color.Tomato;

            // Disable the SAVE button if enabled
            btnSave.Enabled = false;
            btnSave.BackColor = Color.LightGray;

            // Disable the SAVE button if enabled
            btnClear.Enabled = false;
            btnClear.BackColor = Color.LightGray;

            // Get start time
            startTime = DateTime.Now;

            // Start Pinging
            string logString = "Starting Ping..." + Environment.NewLine;
            txtInfo.Text = logString;
            pingConsole.Add(logString);
            RunPing();
        }        
        private void btnStop_Click(object sender, EventArgs e)
        {
            // Get end tim and calculate total time running.
            endTime = DateTime.Now;
            TimeSpan elapsed = endTime.Subtract(startTime);

            string logString = "Stoping Ping... Total Run Time: " + elapsed.TotalMinutes + " minutes" + Environment.NewLine;
            txtInfo.Text += logString;
            pingConsole.Add(logString);

            // Disable / Enable buttons 
            btnStop.Enabled = false;
            btnStop.BackColor = Color.LightGray;
            btnStart.Enabled = true;
            btnStart.BackColor = Color.LightGreen;
            lblConnection.Visible = false;
            btnSave.Enabled = true;
            btnSave.BackColor = Color.LightGreen;
            btnClear.Enabled = true;
            btnClear.BackColor = Color.LightGoldenrodYellow;

            // Bug Fix?
            txtIPCInfo.Select(0, 0);

            // Stop the PING process from running.
            Process[] processes = Process.GetProcessesByName("ping");
            foreach (Process p in processes)
            {
                p.Kill();
                p.WaitForExit();
                p.Dispose();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            txtInfo.Text += "Saving log files to the DESKTOP in PINGLOGS folder... ";

            string desktopDIR = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Create the folder if it doesn't exist
            string saveFolder = "PingLogs";
            string saveFolderPath = System.IO.Path.Combine(desktopDIR, saveFolder);
            if (!System.IO.Directory.Exists(saveFolderPath))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(saveFolderPath);
                }
                catch (IOException ioe)
                {
                    MessageBox.Show("IO Error: " + ioe.Message);
                }
            }

            string currentTime = DateTime.Now.ToString("yyyyMMdd'T'HHmmss");
            string pingFilename = saveFolderPath + "\\PingLog-" + currentTime + ".txt";
            string ipcFilename = saveFolderPath + "\\IPCLog-" + currentTime + ".txt";

            // Write the IPCONFIG log file.
            using (TextWriter tw = new StreamWriter(ipcFilename))
            {
                foreach (String s in ipcConsole)
                {
                    tw.WriteLine(s);
                }
            }

            // Write the PING Log File
            using (TextWriter tw = new StreamWriter(pingFilename))
            {
                foreach (String s in pingConsole)
                {
                    tw.WriteLine(s);
                }
            }
            txtInfo.Text += "SUCCESSFUL" + Environment.NewLine;

            // Zip the folder 
            txtInfo.Text += "Zipping Files to PINGLOGS.ZIP... ";
            ZipFile.CreateFromDirectory(saveFolderPath, desktopDIR + "\\PingLogs-" + currentTime + ".zip");
            txtInfo.Text += "SUCCESSFUL" + Environment.NewLine;

            // Remove the old logs
            txtInfo.Text += "Cleaning up old log files... ";
            Directory.Delete(saveFolderPath, true);
            txtInfo.Text += "SUCCESSFUL" + Environment.NewLine;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInfo.Text = "";
            txtIPCInfo.Text = "";
        }
    }
}
