namespace SF4ComboTrainer
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            if (disposing)
            {
                TimeLineItem.roadie.Dispose();                
            }

            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TimeLine = new System.Windows.Forms.ListBox();
            this.grpItemDetails = new System.Windows.Forms.GroupBox();
            this.numChgWaitFrames = new System.Windows.Forms.NumericUpDown();
            this.lblCurrentFrame = new System.Windows.Forms.Label();
            this.lblIndex = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.chkPlaySound = new System.Windows.Forms.CheckBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.grpTimeLine = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkSendInputs = new System.Windows.Forms.CheckBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoop = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.grpInputs = new System.Windows.Forms.GroupBox();
            this.btnRelease = new System.Windows.Forms.Button();
            this.btnHold = new System.Windows.Forms.Button();
            this.btnPress = new System.Windows.Forms.Button();
            this.chkForward = new System.Windows.Forms.CheckBox();
            this.chkBack = new System.Windows.Forms.CheckBox();
            this.chkDown = new System.Windows.Forms.CheckBox();
            this.chkLK = new System.Windows.Forms.CheckBox();
            this.chkHP = new System.Windows.Forms.CheckBox();
            this.chkHK = new System.Windows.Forms.CheckBox();
            this.chkMK = new System.Windows.Forms.CheckBox();
            this.chkMP = new System.Windows.Forms.CheckBox();
            this.chkLP = new System.Windows.Forms.CheckBox();
            this.chkUP = new System.Windows.Forms.CheckBox();
            this.grpWait = new System.Windows.Forms.GroupBox();
            this.numFrames = new System.Windows.Forms.NumericUpDown();
            this.btnWait = new System.Windows.Forms.Button();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.chkAutoSwitch = new System.Windows.Forms.CheckBox();
            this.chkSteamVersion = new System.Windows.Forms.CheckBox();
            this.btnRecordStop = new System.Windows.Forms.Button();
            this.grpItemDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChgWaitFrames)).BeginInit();
            this.grpTimeLine.SuspendLayout();
            this.grpInputs.SuspendLayout();
            this.grpWait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrames)).BeginInit();
            this.grpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimeLine
            // 
            this.TimeLine.AllowDrop = true;
            this.TimeLine.FormattingEnabled = true;
            this.TimeLine.Location = new System.Drawing.Point(94, 26);
            this.TimeLine.Name = "TimeLine";
            this.TimeLine.Size = new System.Drawing.Size(170, 277);
            this.TimeLine.TabIndex = 0;
            this.TimeLine.SelectedIndexChanged += new System.EventHandler(this.TimeLine_SelectedIndexChanged);
            // 
            // grpItemDetails
            // 
            this.grpItemDetails.Controls.Add(this.numChgWaitFrames);
            this.grpItemDetails.Controls.Add(this.lblCurrentFrame);
            this.grpItemDetails.Controls.Add(this.lblIndex);
            this.grpItemDetails.Controls.Add(this.btnDelete);
            this.grpItemDetails.Controls.Add(this.btnMoveDown);
            this.grpItemDetails.Controls.Add(this.btnMoveUp);
            this.grpItemDetails.Controls.Add(this.chkPlaySound);
            this.grpItemDetails.Controls.Add(this.lblDescription);
            this.grpItemDetails.Location = new System.Drawing.Point(294, 12);
            this.grpItemDetails.Name = "grpItemDetails";
            this.grpItemDetails.Size = new System.Drawing.Size(186, 173);
            this.grpItemDetails.TabIndex = 1;
            this.grpItemDetails.TabStop = false;
            this.grpItemDetails.Text = "Item Details";
            // 
            // numChgWaitFrames
            // 
            this.numChgWaitFrames.Enabled = false;
            this.numChgWaitFrames.Location = new System.Drawing.Point(105, 76);
            this.numChgWaitFrames.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numChgWaitFrames.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChgWaitFrames.Name = "numChgWaitFrames";
            this.numChgWaitFrames.Size = new System.Drawing.Size(75, 20);
            this.numChgWaitFrames.TabIndex = 5;
            this.numChgWaitFrames.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numChgWaitFrames.ValueChanged += new System.EventHandler(this.numChgWaitFrames_ValueChanged);
            // 
            // lblCurrentFrame
            // 
            this.lblCurrentFrame.AutoSize = true;
            this.lblCurrentFrame.Location = new System.Drawing.Point(6, 49);
            this.lblCurrentFrame.Name = "lblCurrentFrame";
            this.lblCurrentFrame.Size = new System.Drawing.Size(73, 13);
            this.lblCurrentFrame.TabIndex = 4;
            this.lblCurrentFrame.Text = "Current Frame";
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Location = new System.Drawing.Point(6, 26);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(13, 13);
            this.lblIndex.TabIndex = 3;
            this.lblIndex.Text = "0";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(9, 129);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(171, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(105, 100);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(75, 23);
            this.btnMoveDown.TabIndex = 2;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(9, 100);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(89, 23);
            this.btnMoveUp.TabIndex = 2;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // chkPlaySound
            // 
            this.chkPlaySound.AutoSize = true;
            this.chkPlaySound.Location = new System.Drawing.Point(9, 77);
            this.chkPlaySound.Name = "chkPlaySound";
            this.chkPlaySound.Size = new System.Drawing.Size(89, 17);
            this.chkPlaySound.TabIndex = 1;
            this.chkPlaySound.Text = "Play Sound ?";
            this.chkPlaySound.UseVisualStyleBackColor = true;
            this.chkPlaySound.CheckedChanged += new System.EventHandler(this.chkPlaySound_CheckedChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(24, 26);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description";
            // 
            // grpTimeLine
            // 
            this.grpTimeLine.Controls.Add(this.btnClear);
            this.grpTimeLine.Controls.Add(this.chkSendInputs);
            this.grpTimeLine.Controls.Add(this.btnRecordStop);
            this.grpTimeLine.Controls.Add(this.btnRecord);
            this.grpTimeLine.Controls.Add(this.btnStop);
            this.grpTimeLine.Controls.Add(this.btnLoad);
            this.grpTimeLine.Controls.Add(this.btnSave);
            this.grpTimeLine.Controls.Add(this.btnLoop);
            this.grpTimeLine.Controls.Add(this.btnPlay);
            this.grpTimeLine.Controls.Add(this.TimeLine);
            this.grpTimeLine.Location = new System.Drawing.Point(12, 12);
            this.grpTimeLine.Name = "grpTimeLine";
            this.grpTimeLine.Size = new System.Drawing.Size(270, 309);
            this.grpTimeLine.TabIndex = 2;
            this.grpTimeLine.TabStop = false;
            this.grpTimeLine.Text = "TimeLine";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(7, 279);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(82, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkSendInputs
            // 
            this.chkSendInputs.AutoSize = true;
            this.chkSendInputs.Checked = true;
            this.chkSendInputs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSendInputs.Location = new System.Drawing.Point(6, 114);
            this.chkSendInputs.Name = "chkSendInputs";
            this.chkSendInputs.Size = new System.Drawing.Size(83, 17);
            this.chkSendInputs.TabIndex = 3;
            this.chkSendInputs.Text = "Send Inputs";
            this.chkSendInputs.UseVisualStyleBackColor = true;
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(7, 150);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(82, 23);
            this.btnRecord.TabIndex = 2;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(6, 84);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(82, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(6, 244);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(82, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 218);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoop
            // 
            this.btnLoop.Location = new System.Drawing.Point(6, 55);
            this.btnLoop.Name = "btnLoop";
            this.btnLoop.Size = new System.Drawing.Size(82, 23);
            this.btnLoop.TabIndex = 1;
            this.btnLoop.Text = "Loop";
            this.btnLoop.UseVisualStyleBackColor = true;
            this.btnLoop.Click += new System.EventHandler(this.btnLoop_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(6, 26);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(82, 23);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // grpInputs
            // 
            this.grpInputs.Controls.Add(this.btnRelease);
            this.grpInputs.Controls.Add(this.btnHold);
            this.grpInputs.Controls.Add(this.btnPress);
            this.grpInputs.Controls.Add(this.chkForward);
            this.grpInputs.Controls.Add(this.chkBack);
            this.grpInputs.Controls.Add(this.chkDown);
            this.grpInputs.Controls.Add(this.chkLK);
            this.grpInputs.Controls.Add(this.chkHP);
            this.grpInputs.Controls.Add(this.chkHK);
            this.grpInputs.Controls.Add(this.chkMK);
            this.grpInputs.Controls.Add(this.chkMP);
            this.grpInputs.Controls.Add(this.chkLP);
            this.grpInputs.Controls.Add(this.chkUP);
            this.grpInputs.Location = new System.Drawing.Point(294, 191);
            this.grpInputs.Name = "grpInputs";
            this.grpInputs.Size = new System.Drawing.Size(362, 130);
            this.grpInputs.TabIndex = 3;
            this.grpInputs.TabStop = false;
            this.grpInputs.Text = "Add Inputs";
            // 
            // btnRelease
            // 
            this.btnRelease.Location = new System.Drawing.Point(242, 100);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(114, 23);
            this.btnRelease.TabIndex = 1;
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // btnHold
            // 
            this.btnHold.Location = new System.Drawing.Point(126, 100);
            this.btnHold.Name = "btnHold";
            this.btnHold.Size = new System.Drawing.Size(114, 23);
            this.btnHold.TabIndex = 1;
            this.btnHold.Text = "Hold";
            this.btnHold.UseVisualStyleBackColor = true;
            this.btnHold.Click += new System.EventHandler(this.btnHold_Click);
            // 
            // btnPress
            // 
            this.btnPress.Location = new System.Drawing.Point(6, 100);
            this.btnPress.Name = "btnPress";
            this.btnPress.Size = new System.Drawing.Size(114, 23);
            this.btnPress.TabIndex = 1;
            this.btnPress.Text = "Press";
            this.btnPress.UseVisualStyleBackColor = true;
            this.btnPress.Click += new System.EventHandler(this.btnPress_Click);
            // 
            // chkForward
            // 
            this.chkForward.AutoSize = true;
            this.chkForward.Location = new System.Drawing.Point(101, 52);
            this.chkForward.Name = "chkForward";
            this.chkForward.Size = new System.Drawing.Size(64, 17);
            this.chkForward.TabIndex = 0;
            this.chkForward.Text = "Forward";
            this.chkForward.UseVisualStyleBackColor = true;
            // 
            // chkBack
            // 
            this.chkBack.AutoSize = true;
            this.chkBack.Location = new System.Drawing.Point(54, 52);
            this.chkBack.Name = "chkBack";
            this.chkBack.Size = new System.Drawing.Size(51, 17);
            this.chkBack.TabIndex = 0;
            this.chkBack.Text = "Back";
            this.chkBack.UseVisualStyleBackColor = true;
            // 
            // chkDown
            // 
            this.chkDown.AutoSize = true;
            this.chkDown.Location = new System.Drawing.Point(80, 75);
            this.chkDown.Name = "chkDown";
            this.chkDown.Size = new System.Drawing.Size(54, 17);
            this.chkDown.TabIndex = 0;
            this.chkDown.Text = "Down";
            this.chkDown.UseVisualStyleBackColor = true;
            // 
            // chkLK
            // 
            this.chkLK.AutoSize = true;
            this.chkLK.Location = new System.Drawing.Point(184, 65);
            this.chkLK.Name = "chkLK";
            this.chkLK.Size = new System.Drawing.Size(39, 17);
            this.chkLK.TabIndex = 0;
            this.chkLK.Text = "LK";
            this.chkLK.UseVisualStyleBackColor = true;
            // 
            // chkHP
            // 
            this.chkHP.AutoSize = true;
            this.chkHP.Location = new System.Drawing.Point(277, 29);
            this.chkHP.Name = "chkHP";
            this.chkHP.Size = new System.Drawing.Size(41, 17);
            this.chkHP.TabIndex = 0;
            this.chkHP.Text = "HP";
            this.chkHP.UseVisualStyleBackColor = true;
            // 
            // chkHK
            // 
            this.chkHK.AutoSize = true;
            this.chkHK.Location = new System.Drawing.Point(277, 52);
            this.chkHK.Name = "chkHK";
            this.chkHK.Size = new System.Drawing.Size(41, 17);
            this.chkHK.TabIndex = 0;
            this.chkHK.Text = "HK";
            this.chkHK.UseVisualStyleBackColor = true;
            // 
            // chkMK
            // 
            this.chkMK.AutoSize = true;
            this.chkMK.Location = new System.Drawing.Point(229, 52);
            this.chkMK.Name = "chkMK";
            this.chkMK.Size = new System.Drawing.Size(42, 17);
            this.chkMK.TabIndex = 0;
            this.chkMK.Text = "MK";
            this.chkMK.UseVisualStyleBackColor = true;
            // 
            // chkMP
            // 
            this.chkMP.AutoSize = true;
            this.chkMP.Location = new System.Drawing.Point(229, 29);
            this.chkMP.Name = "chkMP";
            this.chkMP.Size = new System.Drawing.Size(42, 17);
            this.chkMP.TabIndex = 0;
            this.chkMP.Text = "MP";
            this.chkMP.UseVisualStyleBackColor = true;
            // 
            // chkLP
            // 
            this.chkLP.AutoSize = true;
            this.chkLP.Location = new System.Drawing.Point(184, 45);
            this.chkLP.Name = "chkLP";
            this.chkLP.Size = new System.Drawing.Size(39, 17);
            this.chkLP.TabIndex = 0;
            this.chkLP.Text = "LP";
            this.chkLP.UseVisualStyleBackColor = true;
            // 
            // chkUP
            // 
            this.chkUP.AutoSize = true;
            this.chkUP.Location = new System.Drawing.Point(80, 29);
            this.chkUP.Name = "chkUP";
            this.chkUP.Size = new System.Drawing.Size(40, 17);
            this.chkUP.TabIndex = 0;
            this.chkUP.Text = "Up";
            this.chkUP.UseVisualStyleBackColor = true;
            // 
            // grpWait
            // 
            this.grpWait.Controls.Add(this.numFrames);
            this.grpWait.Controls.Add(this.btnWait);
            this.grpWait.Location = new System.Drawing.Point(492, 117);
            this.grpWait.Name = "grpWait";
            this.grpWait.Size = new System.Drawing.Size(164, 68);
            this.grpWait.TabIndex = 4;
            this.grpWait.TabStop = false;
            this.grpWait.Text = "Add Wait Frames";
            // 
            // numFrames
            // 
            this.numFrames.Location = new System.Drawing.Point(72, 27);
            this.numFrames.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numFrames.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFrames.Name = "numFrames";
            this.numFrames.Size = new System.Drawing.Size(83, 20);
            this.numFrames.TabIndex = 0;
            this.numFrames.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnWait
            // 
            this.btnWait.Location = new System.Drawing.Point(6, 27);
            this.btnWait.Name = "btnWait";
            this.btnWait.Size = new System.Drawing.Size(60, 20);
            this.btnWait.TabIndex = 1;
            this.btnWait.Text = "Wait";
            this.btnWait.UseVisualStyleBackColor = true;
            this.btnWait.Click += new System.EventHandler(this.btnWait_Click);
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.chkAutoSwitch);
            this.grpOptions.Controls.Add(this.chkSteamVersion);
            this.grpOptions.Location = new System.Drawing.Point(492, 12);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(164, 99);
            this.grpOptions.TabIndex = 5;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // chkAutoSwitch
            // 
            this.chkAutoSwitch.AutoSize = true;
            this.chkAutoSwitch.Checked = true;
            this.chkAutoSwitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoSwitch.Location = new System.Drawing.Point(17, 49);
            this.chkAutoSwitch.Name = "chkAutoSwitch";
            this.chkAutoSwitch.Size = new System.Drawing.Size(112, 17);
            this.chkAutoSwitch.TabIndex = 1;
            this.chkAutoSwitch.Text = "Autoswitch to SF4";
            this.chkAutoSwitch.UseVisualStyleBackColor = true;
            // 
            // chkSteamVersion
            // 
            this.chkSteamVersion.AutoSize = true;
            this.chkSteamVersion.Checked = true;
            this.chkSteamVersion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSteamVersion.Location = new System.Drawing.Point(17, 21);
            this.chkSteamVersion.Name = "chkSteamVersion";
            this.chkSteamVersion.Size = new System.Drawing.Size(116, 17);
            this.chkSteamVersion.TabIndex = 0;
            this.chkSteamVersion.Text = "SF4 Steam Version";
            this.chkSteamVersion.UseVisualStyleBackColor = true;
            this.chkSteamVersion.CheckedChanged += new System.EventHandler(this.chkSteamVersion_CheckedChanged);
            // 
            // btnRecordStop
            // 
            this.btnRecordStop.Location = new System.Drawing.Point(7, 179);
            this.btnRecordStop.Name = "btnRecordStop";
            this.btnRecordStop.Size = new System.Drawing.Size(82, 23);
            this.btnRecordStop.TabIndex = 2;
            this.btnRecordStop.Text = "Stop";
            this.btnRecordStop.UseVisualStyleBackColor = true;
            this.btnRecordStop.Click += new System.EventHandler(this.btnRecordStop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 331);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.grpWait);
            this.Controls.Add(this.grpInputs);
            this.Controls.Add(this.grpTimeLine);
            this.Controls.Add(this.grpItemDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "SF4ComboTrainer";
            this.grpItemDetails.ResumeLayout(false);
            this.grpItemDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChgWaitFrames)).EndInit();
            this.grpTimeLine.ResumeLayout(false);
            this.grpTimeLine.PerformLayout();
            this.grpInputs.ResumeLayout(false);
            this.grpInputs.PerformLayout();
            this.grpWait.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numFrames)).EndInit();
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox TimeLine;
        private System.Windows.Forms.GroupBox grpItemDetails;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.CheckBox chkPlaySound;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.Label lblCurrentFrame;
        private System.Windows.Forms.GroupBox grpTimeLine;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoop;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.GroupBox grpInputs;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Button btnHold;
        private System.Windows.Forms.Button btnPress;
        private System.Windows.Forms.CheckBox chkForward;
        private System.Windows.Forms.CheckBox chkBack;
        private System.Windows.Forms.CheckBox chkDown;
        private System.Windows.Forms.CheckBox chkLK;
        private System.Windows.Forms.CheckBox chkHP;
        private System.Windows.Forms.CheckBox chkHK;
        private System.Windows.Forms.CheckBox chkMK;
        private System.Windows.Forms.CheckBox chkMP;
        private System.Windows.Forms.CheckBox chkLP;
        private System.Windows.Forms.CheckBox chkUP;
        private System.Windows.Forms.GroupBox grpWait;
        private System.Windows.Forms.NumericUpDown numFrames;
        private System.Windows.Forms.Button btnWait;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.CheckBox chkSteamVersion;
        private System.Windows.Forms.CheckBox chkAutoSwitch;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.NumericUpDown numChgWaitFrames;
        private System.Windows.Forms.CheckBox chkSendInputs;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnRecordStop;

    }
}

