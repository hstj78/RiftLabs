namespace RiftLabs.Kick.UI
{
  partial class Form1
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
      this.txtLog = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btnConnect = new System.Windows.Forms.Button();
      this.btnHello = new System.Windows.Forms.Button();
      this.btnVersion = new System.Windows.Forms.Button();
      this.btnCustom = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.txtHex = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.btnStatus = new System.Windows.Forms.Button();
      this.btnEV2 = new System.Windows.Forms.Button();
      this.EV2Slider = new System.Windows.Forms.TrackBar();
      this.btnRGB = new System.Windows.Forms.Button();
      this.pnlRGB = new System.Windows.Forms.Panel();
      this.colorDialogRGB = new System.Windows.Forms.ColorDialog();
      this.grpKickInfo = new System.Windows.Forms.GroupBox();
      this.lblTemperature = new System.Windows.Forms.Label();
      this.pnlRGBId = new System.Windows.Forms.Panel();
      this.lblRGB = new System.Windows.Forms.Label();
      this.lblSerialNumber = new System.Windows.Forms.Label();
      this.lblEV2Level = new System.Windows.Forms.Label();
      this.lblHWVersion = new System.Windows.Forms.Label();
      this.lblFWVersion = new System.Windows.Forms.Label();
      this.lblPower = new System.Windows.Forms.Label();
      this.lblName = new System.Windows.Forms.Label();
      this.lblAddress = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.responseDelay = new System.Windows.Forms.NumericUpDown();
      this.label5 = new System.Windows.Forms.Label();
      this.cboDevices = new System.Windows.Forms.ComboBox();
      ((System.ComponentModel.ISupportInitialize)(this.EV2Slider)).BeginInit();
      this.grpKickInfo.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.responseDelay)).BeginInit();
      this.SuspendLayout();
      // 
      // txtLog
      // 
      this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtLog.BackColor = System.Drawing.Color.Black;
      this.txtLog.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
      this.txtLog.Location = new System.Drawing.Point(104, 157);
      this.txtLog.MaxLength = 327670;
      this.txtLog.Multiline = true;
      this.txtLog.Name = "txtLog";
      this.txtLog.ReadOnly = true;
      this.txtLog.Size = new System.Drawing.Size(680, 295);
      this.txtLog.TabIndex = 0;
      this.txtLog.TabStop = false;
      this.txtLog.Text = "IN > 0001110000 00112233FF\r\nOUT> 0001110000 00112233FF";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(101, 141);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(45, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Console";
      // 
      // btnConnect
      // 
      this.btnConnect.Location = new System.Drawing.Point(12, 12);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(83, 23);
      this.btnConnect.TabIndex = 1;
      this.btnConnect.Text = "Connect";
      this.btnConnect.UseVisualStyleBackColor = true;
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // btnHello
      // 
      this.btnHello.Enabled = false;
      this.btnHello.Location = new System.Drawing.Point(12, 41);
      this.btnHello.Name = "btnHello";
      this.btnHello.Size = new System.Drawing.Size(83, 23);
      this.btnHello.TabIndex = 2;
      this.btnHello.Text = "Hello";
      this.btnHello.UseVisualStyleBackColor = true;
      this.btnHello.Click += new System.EventHandler(this.btnHello_Click);
      // 
      // btnVersion
      // 
      this.btnVersion.Location = new System.Drawing.Point(12, 70);
      this.btnVersion.Name = "btnVersion";
      this.btnVersion.Size = new System.Drawing.Size(83, 23);
      this.btnVersion.TabIndex = 3;
      this.btnVersion.Text = "Version";
      this.btnVersion.UseVisualStyleBackColor = true;
      this.btnVersion.Click += new System.EventHandler(this.btnVersion_Click);
      // 
      // btnCustom
      // 
      this.btnCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCustom.Location = new System.Drawing.Point(701, 458);
      this.btnCustom.Name = "btnCustom";
      this.btnCustom.Size = new System.Drawing.Size(83, 23);
      this.btnCustom.TabIndex = 10;
      this.btnCustom.Text = "Send Custom";
      this.btnCustom.UseVisualStyleBackColor = true;
      this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(247, 463);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(32, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "HEX:";
      // 
      // txtHex
      // 
      this.txtHex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtHex.Font = new System.Drawing.Font("Courier New", 8F);
      this.txtHex.Location = new System.Drawing.Point(285, 460);
      this.txtHex.Name = "txtHex";
      this.txtHex.Size = new System.Drawing.Size(410, 20);
      this.txtHex.TabIndex = 9;
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label3.AutoSize = true;
      this.label3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
      this.label3.Location = new System.Drawing.Point(282, 483);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(261, 13);
      this.label3.TabIndex = 8;
      this.label3.Text = "Only CMD + DATA, no header. Spaces are truncated.";
      // 
      // btnStatus
      // 
      this.btnStatus.Location = new System.Drawing.Point(12, 99);
      this.btnStatus.Name = "btnStatus";
      this.btnStatus.Size = new System.Drawing.Size(83, 23);
      this.btnStatus.TabIndex = 4;
      this.btnStatus.Text = "Status";
      this.btnStatus.UseVisualStyleBackColor = true;
      this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
      // 
      // btnEV2
      // 
      this.btnEV2.Location = new System.Drawing.Point(12, 128);
      this.btnEV2.Name = "btnEV2";
      this.btnEV2.Size = new System.Drawing.Size(83, 23);
      this.btnEV2.TabIndex = 5;
      this.btnEV2.Text = "EV2: 0";
      this.btnEV2.UseVisualStyleBackColor = true;
      this.btnEV2.Click += new System.EventHandler(this.btnEV2_Click);
      // 
      // EV2Slider
      // 
      this.EV2Slider.Location = new System.Drawing.Point(12, 157);
      this.EV2Slider.Maximum = 255;
      this.EV2Slider.Name = "EV2Slider";
      this.EV2Slider.Size = new System.Drawing.Size(83, 45);
      this.EV2Slider.TabIndex = 6;
      this.EV2Slider.TickStyle = System.Windows.Forms.TickStyle.None;
      this.EV2Slider.Scroll += new System.EventHandler(this.EV2Slider_Scroll);
      // 
      // btnRGB
      // 
      this.btnRGB.Location = new System.Drawing.Point(12, 208);
      this.btnRGB.Name = "btnRGB";
      this.btnRGB.Size = new System.Drawing.Size(83, 23);
      this.btnRGB.TabIndex = 7;
      this.btnRGB.Text = "RGB";
      this.btnRGB.UseVisualStyleBackColor = true;
      this.btnRGB.Click += new System.EventHandler(this.btnRGB_Click);
      // 
      // pnlRGB
      // 
      this.pnlRGB.BackColor = System.Drawing.Color.White;
      this.pnlRGB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.pnlRGB.Location = new System.Drawing.Point(12, 237);
      this.pnlRGB.Name = "pnlRGB";
      this.pnlRGB.Size = new System.Drawing.Size(83, 45);
      this.pnlRGB.TabIndex = 8;
      this.pnlRGB.TabStop = true;
      this.pnlRGB.Click += new System.EventHandler(this.pnlRGB_Click);
      // 
      // colorDialogRGB
      // 
      this.colorDialogRGB.Color = System.Drawing.Color.White;
      // 
      // grpKickInfo
      // 
      this.grpKickInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grpKickInfo.Controls.Add(this.lblTemperature);
      this.grpKickInfo.Controls.Add(this.pnlRGBId);
      this.grpKickInfo.Controls.Add(this.lblRGB);
      this.grpKickInfo.Controls.Add(this.lblSerialNumber);
      this.grpKickInfo.Controls.Add(this.lblEV2Level);
      this.grpKickInfo.Controls.Add(this.lblHWVersion);
      this.grpKickInfo.Controls.Add(this.lblFWVersion);
      this.grpKickInfo.Controls.Add(this.lblPower);
      this.grpKickInfo.Controls.Add(this.lblName);
      this.grpKickInfo.Controls.Add(this.lblAddress);
      this.grpKickInfo.Location = new System.Drawing.Point(104, 41);
      this.grpKickInfo.Name = "grpKickInfo";
      this.grpKickInfo.Size = new System.Drawing.Size(680, 81);
      this.grpKickInfo.TabIndex = 15;
      this.grpKickInfo.TabStop = false;
      this.grpKickInfo.Text = "Kick Device Info";
      // 
      // lblTemperature
      // 
      this.lblTemperature.AutoSize = true;
      this.lblTemperature.Location = new System.Drawing.Point(359, 52);
      this.lblTemperature.Name = "lblTemperature";
      this.lblTemperature.Size = new System.Drawing.Size(93, 13);
      this.lblTemperature.TabIndex = 19;
      this.lblTemperature.Text = "Temperature °C: ?";
      // 
      // pnlRGBId
      // 
      this.pnlRGBId.BackColor = System.Drawing.Color.Transparent;
      this.pnlRGBId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlRGBId.Location = new System.Drawing.Point(46, 52);
      this.pnlRGBId.Name = "pnlRGBId";
      this.pnlRGBId.Size = new System.Drawing.Size(13, 13);
      this.pnlRGBId.TabIndex = 18;
      this.pnlRGBId.TabStop = true;
      // 
      // lblRGB
      // 
      this.lblRGB.AutoSize = true;
      this.lblRGB.Location = new System.Drawing.Point(7, 52);
      this.lblRGB.Name = "lblRGB";
      this.lblRGB.Size = new System.Drawing.Size(33, 13);
      this.lblRGB.TabIndex = 7;
      this.lblRGB.Text = "RGB:";
      // 
      // lblSerialNumber
      // 
      this.lblSerialNumber.AutoSize = true;
      this.lblSerialNumber.Location = new System.Drawing.Point(359, 16);
      this.lblSerialNumber.Name = "lblSerialNumber";
      this.lblSerialNumber.Size = new System.Drawing.Size(83, 13);
      this.lblSerialNumber.TabIndex = 6;
      this.lblSerialNumber.Text = "Serial number: ?";
      // 
      // lblEV2Level
      // 
      this.lblEV2Level.AutoSize = true;
      this.lblEV2Level.Location = new System.Drawing.Point(168, 52);
      this.lblEV2Level.Name = "lblEV2Level";
      this.lblEV2Level.Size = new System.Drawing.Size(64, 13);
      this.lblEV2Level.TabIndex = 5;
      this.lblEV2Level.Text = "EV2 level: ?";
      // 
      // lblHWVersion
      // 
      this.lblHWVersion.AutoSize = true;
      this.lblHWVersion.Location = new System.Drawing.Point(168, 34);
      this.lblHWVersion.Name = "lblHWVersion";
      this.lblHWVersion.Size = new System.Drawing.Size(102, 13);
      this.lblHWVersion.TabIndex = 4;
      this.lblHWVersion.Text = "Hardware version: ?";
      // 
      // lblFWVersion
      // 
      this.lblFWVersion.AutoSize = true;
      this.lblFWVersion.Location = new System.Drawing.Point(168, 16);
      this.lblFWVersion.Name = "lblFWVersion";
      this.lblFWVersion.Size = new System.Drawing.Size(98, 13);
      this.lblFWVersion.TabIndex = 3;
      this.lblFWVersion.Text = "Firmware version: ?";
      // 
      // lblPower
      // 
      this.lblPower.AutoSize = true;
      this.lblPower.Location = new System.Drawing.Point(359, 34);
      this.lblPower.Name = "lblPower";
      this.lblPower.Size = new System.Drawing.Size(49, 13);
      this.lblPower.TabIndex = 2;
      this.lblPower.Text = "Power: ?";
      // 
      // lblName
      // 
      this.lblName.AutoSize = true;
      this.lblName.Location = new System.Drawing.Point(7, 34);
      this.lblName.Name = "lblName";
      this.lblName.Size = new System.Drawing.Size(47, 13);
      this.lblName.TabIndex = 1;
      this.lblName.Text = "Name: ?";
      // 
      // lblAddress
      // 
      this.lblAddress.AutoSize = true;
      this.lblAddress.Location = new System.Drawing.Point(7, 16);
      this.lblAddress.Name = "lblAddress";
      this.lblAddress.Size = new System.Drawing.Size(57, 13);
      this.lblAddress.TabIndex = 0;
      this.lblAddress.Text = "Address: ?";
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(101, 463);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(86, 13);
      this.label4.TabIndex = 16;
      this.label4.Text = "Response delay:";
      // 
      // responseDelay
      // 
      this.responseDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.responseDelay.Location = new System.Drawing.Point(193, 461);
      this.responseDelay.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
      this.responseDelay.Name = "responseDelay";
      this.responseDelay.Size = new System.Drawing.Size(39, 20);
      this.responseDelay.TabIndex = 17;
      this.responseDelay.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(101, 17);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(77, 13);
      this.label5.TabIndex = 18;
      this.label5.Text = "Active Device:";
      // 
      // cboDevices
      // 
      this.cboDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboDevices.FormattingEnabled = true;
      this.cboDevices.Location = new System.Drawing.Point(184, 14);
      this.cboDevices.Name = "cboDevices";
      this.cboDevices.Size = new System.Drawing.Size(190, 21);
      this.cboDevices.TabIndex = 19;
      this.cboDevices.SelectedValueChanged += new System.EventHandler(this.cboDevices_SelectedValueChanged);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(796, 505);
      this.Controls.Add(this.cboDevices);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.responseDelay);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.grpKickInfo);
      this.Controls.Add(this.pnlRGB);
      this.Controls.Add(this.btnRGB);
      this.Controls.Add(this.EV2Slider);
      this.Controls.Add(this.btnEV2);
      this.Controls.Add(this.btnStatus);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtHex);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnCustom);
      this.Controls.Add(this.btnVersion);
      this.Controls.Add(this.btnHello);
      this.Controls.Add(this.btnConnect);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtLog);
      this.Name = "Form1";
      this.Text = "Kick Master Simulator";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.Shown += new System.EventHandler(this.Form1_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.EV2Slider)).EndInit();
      this.grpKickInfo.ResumeLayout(false);
      this.grpKickInfo.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.responseDelay)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtLog;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnConnect;
    private System.Windows.Forms.Button btnHello;
    private System.Windows.Forms.Button btnVersion;
    private System.Windows.Forms.Button btnCustom;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtHex;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnStatus;
    private System.Windows.Forms.Button btnEV2;
    private System.Windows.Forms.TrackBar EV2Slider;
    private System.Windows.Forms.Button btnRGB;
    private System.Windows.Forms.Panel pnlRGB;
    private System.Windows.Forms.ColorDialog colorDialogRGB;
    private System.Windows.Forms.GroupBox grpKickInfo;
    private System.Windows.Forms.Label lblPower;
    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.Label lblAddress;
    private System.Windows.Forms.Label lblEV2Level;
    private System.Windows.Forms.Label lblHWVersion;
    private System.Windows.Forms.Label lblFWVersion;
    private System.Windows.Forms.Label lblSerialNumber;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.NumericUpDown responseDelay;
    private System.Windows.Forms.Panel pnlRGBId;
    private System.Windows.Forms.Label lblRGB;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox cboDevices;
    private System.Windows.Forms.Label lblTemperature;
  }
}

