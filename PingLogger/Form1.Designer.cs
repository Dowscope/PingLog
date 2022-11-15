namespace PingLogger
{
    partial class frmMain
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
            this.btnStart = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblIPError = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblConnection = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtIPCInfo = new System.Windows.Forms.TextBox();
            this.lblPingDisplay = new System.Windows.Forms.Label();
            this.lblIPCDisplay = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.LightGreen;
            this.btnStart.Location = new System.Drawing.Point(260, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(121, 40);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(76, 20);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 20);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "10.240.0.1";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(12, 23);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(58, 13);
            this.lblIP.TabIndex = 2;
            this.lblIP.Text = "IP Address";
            // 
            // lblIPError
            // 
            this.lblIPError.AutoSize = true;
            this.lblIPError.ForeColor = System.Drawing.Color.Red;
            this.lblIPError.Location = new System.Drawing.Point(76, 47);
            this.lblIPError.Name = "lblIPError";
            this.lblIPError.Size = new System.Drawing.Size(84, 13);
            this.lblIPError.TabIndex = 3;
            this.lblIPError.Text = "This IP is Invalid";
            this.lblIPError.Visible = false;
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(15, 105);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfo.Size = new System.Drawing.Size(504, 293);
            this.txtInfo.TabIndex = 4;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.LightGray;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(387, 20);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(132, 40);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.ForeColor = System.Drawing.Color.Red;
            this.lblConnection.Location = new System.Drawing.Point(15, 405);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(247, 13);
            this.lblConnection.TabIndex = 6;
            this.lblConnection.Text = "No Connection Available / Connection was broken";
            this.lblConnection.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(759, 405);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 28);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save Logs";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtIPCInfo
            // 
            this.txtIPCInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIPCInfo.Location = new System.Drawing.Point(525, 105);
            this.txtIPCInfo.Multiline = true;
            this.txtIPCInfo.Name = "txtIPCInfo";
            this.txtIPCInfo.ReadOnly = true;
            this.txtIPCInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIPCInfo.Size = new System.Drawing.Size(504, 293);
            this.txtIPCInfo.TabIndex = 8;
            // 
            // lblPingDisplay
            // 
            this.lblPingDisplay.AutoSize = true;
            this.lblPingDisplay.Location = new System.Drawing.Point(18, 86);
            this.lblPingDisplay.Name = "lblPingDisplay";
            this.lblPingDisplay.Size = new System.Drawing.Size(65, 13);
            this.lblPingDisplay.TabIndex = 9;
            this.lblPingDisplay.Text = "Ping Display";
            // 
            // lblIPCDisplay
            // 
            this.lblIPCDisplay.AutoSize = true;
            this.lblIPCDisplay.Location = new System.Drawing.Point(522, 86);
            this.lblIPCDisplay.Name = "lblIPCDisplay";
            this.lblIPCDisplay.Size = new System.Drawing.Size(84, 13);
            this.lblIPCDisplay.TabIndex = 10;
            this.lblIPCDisplay.Text = "IPConfig Display";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightGray;
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(897, 405);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(132, 28);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear Displays";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 441);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblIPCDisplay);
            this.Controls.Add(this.lblPingDisplay);
            this.Controls.Add(this.txtIPCInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.lblIPError);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnStart);
            this.Name = "frmMain";
            this.Text = "Ping Logger v1.0.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblIPError;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtIPCInfo;
        private System.Windows.Forms.Label lblPingDisplay;
        private System.Windows.Forms.Label lblIPCDisplay;
        private System.Windows.Forms.Button btnClear;
    }
}

