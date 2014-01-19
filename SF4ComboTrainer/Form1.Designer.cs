using SF4ComboTrainerModel;

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
                TimeLineItem.DisposeRoadie();                
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkSendInputs = new System.Windows.Forms.CheckBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnAppend = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoop = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.grpInputs = new System.Windows.Forms.GroupBox();
            this.optDL = new System.Windows.Forms.RadioButton();
            this.optUL = new System.Windows.Forms.RadioButton();
            this.optUR = new System.Windows.Forms.RadioButton();
            this.optDR = new System.Windows.Forms.RadioButton();
            this.optNeutral = new System.Windows.Forms.RadioButton();
            this.btnRelease = new System.Windows.Forms.Button();
            this.btnHold = new System.Windows.Forms.Button();
            this.btnPress = new System.Windows.Forms.Button();
            this.optForward = new System.Windows.Forms.RadioButton();
            this.optBack = new System.Windows.Forms.RadioButton();
            this.optDown = new System.Windows.Forms.RadioButton();
            this.chkLK = new System.Windows.Forms.CheckBox();
            this.chkHP = new System.Windows.Forms.CheckBox();
            this.chkHK = new System.Windows.Forms.CheckBox();
            this.chkMK = new System.Windows.Forms.CheckBox();
            this.chkMP = new System.Windows.Forms.CheckBox();
            this.chkLP = new System.Windows.Forms.CheckBox();
            this.optUP = new System.Windows.Forms.RadioButton();
            this.grpWait = new System.Windows.Forms.GroupBox();
            this.numFrames = new System.Windows.Forms.NumericUpDown();
            this.btnWait = new System.Windows.Forms.Button();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.chkAutoSwitch = new System.Windows.Forms.CheckBox();
            this.chkSteamVersion = new System.Windows.Forms.CheckBox();
            this.btnRecordStop = new System.Windows.Forms.Button();
            this.grpQuickInputs = new System.Windows.Forms.GroupBox();
            this.btnDHCF = new System.Windows.Forms.Button();
            this.btnPPP = new System.Windows.Forms.Button();
            this.btnKKK = new System.Windows.Forms.Button();
            this.btn360 = new System.Windows.Forms.Button();
            this.btnHCB = new System.Windows.Forms.Button();
            this.btnHCF = new System.Windows.Forms.Button();
            this.btnDPB = new System.Windows.Forms.Button();
            this.btnQCB = new System.Windows.Forms.Button();
            this.btnDPF = new System.Windows.Forms.Button();
            this.btnQCF = new System.Windows.Forms.Button();
            this.btnDelta = new System.Windows.Forms.Button();

            this.grpItemDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChgWaitFrames)).BeginInit();
            this.grpTimeLine.SuspendLayout();
            this.grpInputs.SuspendLayout();
            this.grpWait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrames)).BeginInit();
            this.grpOptions.SuspendLayout();
            this.grpQuickInputs.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimeLine
            // 
            this.TimeLine.AllowDrop = true;
            this.TimeLine.FormattingEnabled = true;
            this.TimeLine.Location = new System.Drawing.Point(94, 26);
            this.TimeLine.Name = "TimeLine";
            this.TimeLine.Size = new System.Drawing.Size(170, 394);
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
            this.grpTimeLine.Controls.Add(this.btnLoad);
            this.grpTimeLine.Controls.Add(this.btnClear);
            this.grpTimeLine.Controls.Add(this.chkSendInputs);
            this.grpTimeLine.Controls.Add(this.btnRecordStop);
            this.grpTimeLine.Controls.Add(this.btnRecord);
            this.grpTimeLine.Controls.Add(this.btnStop);
            this.grpTimeLine.Controls.Add(this.btnAppend);
            this.grpTimeLine.Controls.Add(this.btnSave);
            this.grpTimeLine.Controls.Add(this.btnLoop);
            this.grpTimeLine.Controls.Add(this.btnPlay);
            this.grpTimeLine.Controls.Add(this.TimeLine);
            this.grpTimeLine.Location = new System.Drawing.Point(12, 12);
            this.grpTimeLine.Name = "grpTimeLine";
            this.grpTimeLine.Size = new System.Drawing.Size(270, 437);
            this.grpTimeLine.TabIndex = 2;
            this.grpTimeLine.TabStop = false;
            this.grpTimeLine.Text = "TimeLine";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(7, 362);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(82, 23);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(7, 398);
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
            // btnAppend
            // 
            this.btnAppend.Location = new System.Drawing.Point(7, 336);
            this.btnAppend.Name = "btnAppend";
            this.btnAppend.Size = new System.Drawing.Size(82, 23);
            this.btnAppend.TabIndex = 1;
            this.btnAppend.Text = "Append";
            this.btnAppend.UseVisualStyleBackColor = true;
            this.btnAppend.Click += new System.EventHandler(this.btnAppend_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(7, 310);
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
            this.grpInputs.Controls.Add(this.optDL);
            this.grpInputs.Controls.Add(this.optUL);
            this.grpInputs.Controls.Add(this.optUR);
            this.grpInputs.Controls.Add(this.optDR);
            this.grpInputs.Controls.Add(this.optNeutral);
            this.grpInputs.Controls.Add(this.btnRelease);
            this.grpInputs.Controls.Add(this.btnHold);
            this.grpInputs.Controls.Add(this.btnPress);
            this.grpInputs.Controls.Add(this.optForward);
            this.grpInputs.Controls.Add(this.optBack);
            this.grpInputs.Controls.Add(this.optDown);
            this.grpInputs.Controls.Add(this.chkLK);
            this.grpInputs.Controls.Add(this.chkHP);
            this.grpInputs.Controls.Add(this.chkHK);
            this.grpInputs.Controls.Add(this.chkMK);
            this.grpInputs.Controls.Add(this.chkMP);
            this.grpInputs.Controls.Add(this.chkLP);
            this.grpInputs.Controls.Add(this.optUP);
            this.grpInputs.Location = new System.Drawing.Point(294, 191);
            this.grpInputs.Name = "grpInputs";
            this.grpInputs.Size = new System.Drawing.Size(362, 135);
            this.grpInputs.TabIndex = 3;
            this.grpInputs.TabStop = false;
            this.grpInputs.Text = "Add Inputs";
            // 
            // optDL
            // 
            this.optDL.Appearance = System.Windows.Forms.Appearance.Button;
            this.optDL.Image = ((System.Drawing.Image)(resources.GetObject("optDL.Image")));
            this.optDL.Location = new System.Drawing.Point(9, 97);
            this.optDL.Name = "optDL";
            this.optDL.Size = new System.Drawing.Size(30, 30);
            this.optDL.TabIndex = 10;
            // 
            // optUL
            // 
            this.optUL.Appearance = System.Windows.Forms.Appearance.Button;
            this.optUL.Image = ((System.Drawing.Image)(resources.GetObject("optUL.Image")));
            this.optUL.Location = new System.Drawing.Point(9, 25);
            this.optUL.Name = "optUL";
            this.optUL.Size = new System.Drawing.Size(30, 30);
            this.optUL.TabIndex = 9;
            // 
            // optUR
            // 
            this.optUR.Appearance = System.Windows.Forms.Appearance.Button;
            this.optUR.Image = ((System.Drawing.Image)(resources.GetObject("optUR.Image")));
            this.optUR.Location = new System.Drawing.Point(81, 25);
            this.optUR.Name = "optUR";
            this.optUR.Size = new System.Drawing.Size(30, 30);
            this.optUR.TabIndex = 8;
            // 
            // optDR
            // 
            this.optDR.Appearance = System.Windows.Forms.Appearance.Button;
            this.optDR.Image = ((System.Drawing.Image)(resources.GetObject("optDR.Image")));
            this.optDR.Location = new System.Drawing.Point(81, 97);
            this.optDR.Name = "optDR";
            this.optDR.Size = new System.Drawing.Size(30, 30);
            this.optDR.TabIndex = 7;
            // 
            // optNeutral
            // 
            this.optNeutral.Appearance = System.Windows.Forms.Appearance.Button;
            this.optNeutral.Checked = true;
            this.optNeutral.Image = ((System.Drawing.Image)(resources.GetObject("optNeutral.Image")));
            this.optNeutral.Location = new System.Drawing.Point(45, 61);
            this.optNeutral.Name = "optNeutral";
            this.optNeutral.Size = new System.Drawing.Size(30, 30);
            this.optNeutral.TabIndex = 2;
            this.optNeutral.TabStop = true;
            this.optNeutral.UseVisualStyleBackColor = true;
            // 
            // btnRelease
            // 
            this.btnRelease.Location = new System.Drawing.Point(255, 97);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(98, 27);
            this.btnRelease.TabIndex = 1;
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // btnHold
            // 
            this.btnHold.Location = new System.Drawing.Point(255, 69);
            this.btnHold.Name = "btnHold";
            this.btnHold.Size = new System.Drawing.Size(98, 27);
            this.btnHold.TabIndex = 1;
            this.btnHold.Text = "Hold";
            this.btnHold.UseVisualStyleBackColor = true;
            this.btnHold.Click += new System.EventHandler(this.btnHold_Click);
            // 
            // btnPress
            // 
            this.btnPress.Location = new System.Drawing.Point(255, 19);
            this.btnPress.Name = "btnPress";
            this.btnPress.Size = new System.Drawing.Size(98, 45);
            this.btnPress.TabIndex = 1;
            this.btnPress.Text = "Press";
            this.btnPress.UseVisualStyleBackColor = true;
            this.btnPress.Click += new System.EventHandler(this.btnPress_Click);
            // 
            // optForward
            // 
            this.optForward.Appearance = System.Windows.Forms.Appearance.Button;
            this.optForward.Image = ((System.Drawing.Image)(resources.GetObject("optForward.Image")));
            this.optForward.Location = new System.Drawing.Point(81, 61);
            this.optForward.Name = "optForward";
            this.optForward.Size = new System.Drawing.Size(30, 30);
            this.optForward.TabIndex = 3;
            // 
            // optBack
            // 
            this.optBack.Appearance = System.Windows.Forms.Appearance.Button;
            this.optBack.Image = ((System.Drawing.Image)(resources.GetObject("optBack.Image")));
            this.optBack.Location = new System.Drawing.Point(9, 61);
            this.optBack.Name = "optBack";
            this.optBack.Size = new System.Drawing.Size(30, 30);
            this.optBack.TabIndex = 4;
            // 
            // optDown
            // 
            this.optDown.Appearance = System.Windows.Forms.Appearance.Button;
            this.optDown.Image = ((System.Drawing.Image)(resources.GetObject("optDown.Image")));
            this.optDown.Location = new System.Drawing.Point(45, 97);
            this.optDown.Name = "optDown";
            this.optDown.Size = new System.Drawing.Size(30, 30);
            this.optDown.TabIndex = 5;
            // 
            // chkLK
            // 
            this.chkLK.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkLK.Image = ((System.Drawing.Image)(resources.GetObject("chkLK.Image")));
            this.chkLK.Location = new System.Drawing.Point(123, 80);
            this.chkLK.Name = "chkLK";
            this.chkLK.Size = new System.Drawing.Size(34, 34);
            this.chkLK.TabIndex = 0;
            this.chkLK.UseVisualStyleBackColor = true;
            // 
            // chkHP
            // 
            this.chkHP.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkHP.Image = ((System.Drawing.Image)(resources.GetObject("chkHP.Image")));
            this.chkHP.Location = new System.Drawing.Point(203, 40);
            this.chkHP.Name = "chkHP";
            this.chkHP.Size = new System.Drawing.Size(34, 34);
            this.chkHP.TabIndex = 0;
            this.chkHP.UseVisualStyleBackColor = true;
            // 
            // chkHK
            // 
            this.chkHK.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkHK.Image = ((System.Drawing.Image)(resources.GetObject("chkHK.Image")));
            this.chkHK.Location = new System.Drawing.Point(203, 80);
            this.chkHK.Name = "chkHK";
            this.chkHK.Size = new System.Drawing.Size(34, 34);
            this.chkHK.TabIndex = 0;
            this.chkHK.UseVisualStyleBackColor = true;
            // 
            // chkMK
            // 
            this.chkMK.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMK.Image = ((System.Drawing.Image)(resources.GetObject("chkMK.Image")));
            this.chkMK.Location = new System.Drawing.Point(163, 80);
            this.chkMK.Name = "chkMK";
            this.chkMK.Size = new System.Drawing.Size(34, 34);
            this.chkMK.TabIndex = 0;
            this.chkMK.UseVisualStyleBackColor = true;
            // 
            // chkMP
            // 
            this.chkMP.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMP.Image = ((System.Drawing.Image)(resources.GetObject("chkMP.Image")));
            this.chkMP.Location = new System.Drawing.Point(163, 40);
            this.chkMP.Name = "chkMP";
            this.chkMP.Size = new System.Drawing.Size(34, 34);
            this.chkMP.TabIndex = 0;
            this.chkMP.UseVisualStyleBackColor = true;
            // 
            // chkLP
            // 
            this.chkLP.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkLP.Image = ((System.Drawing.Image)(resources.GetObject("chkLP.Image")));
            this.chkLP.Location = new System.Drawing.Point(123, 40);
            this.chkLP.Name = "chkLP";
            this.chkLP.Size = new System.Drawing.Size(34, 34);
            this.chkLP.TabIndex = 0;
            this.chkLP.UseVisualStyleBackColor = true;
            // 
            // optUP
            // 
            this.optUP.Appearance = System.Windows.Forms.Appearance.Button;
            this.optUP.Image = ((System.Drawing.Image)(resources.GetObject("optUP.Image")));
            this.optUP.Location = new System.Drawing.Point(45, 25);
            this.optUP.Name = "optUP";
            this.optUP.Size = new System.Drawing.Size(30, 30);
            this.optUP.TabIndex = 6;
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
            // grpQuickInputs
            // 
            this.grpQuickInputs.Controls.Add(this.btnDelta);
            this.grpQuickInputs.Controls.Add(this.btnDHCF);
            this.grpQuickInputs.Controls.Add(this.btnPPP);
            this.grpQuickInputs.Controls.Add(this.btnKKK);
            this.grpQuickInputs.Controls.Add(this.btn360);
            this.grpQuickInputs.Controls.Add(this.btnHCB);
            this.grpQuickInputs.Controls.Add(this.btnHCF);
            this.grpQuickInputs.Controls.Add(this.btnDPB);
            this.grpQuickInputs.Controls.Add(this.btnQCB);
            this.grpQuickInputs.Controls.Add(this.btnDPF);
            this.grpQuickInputs.Controls.Add(this.btnQCF);
            this.grpQuickInputs.Location = new System.Drawing.Point(294, 332);
            this.grpQuickInputs.Name = "grpQuickInputs";
            this.grpQuickInputs.Size = new System.Drawing.Size(362, 101);
            this.grpQuickInputs.TabIndex = 6;
            this.grpQuickInputs.TabStop = false;
            this.grpQuickInputs.Text = "Quick Inputs";
            // 
            // btnDHCF
            // 
            this.btnDHCF.Image = ((System.Drawing.Image)(resources.GetObject("btnDHCF.Image")));
            this.btnDHCF.Location = new System.Drawing.Point(146, 59);
            this.btnDHCF.Name = "btnDHCF";
            this.btnDHCF.Size = new System.Drawing.Size(34, 34);
            this.btnDHCF.TabIndex = 9;
            this.btnDHCF.UseVisualStyleBackColor = true;
            this.btnDHCF.Click += new System.EventHandler(this.btnDHCF_Click);
            // 
            // btnPPP
            // 
            this.btnPPP.Image = ((System.Drawing.Image)(resources.GetObject("btnPPP.Image")));
            this.btnPPP.Location = new System.Drawing.Point(291, 20);
            this.btnPPP.Name = "btnPPP";
            this.btnPPP.Size = new System.Drawing.Size(62, 34);
            this.btnPPP.TabIndex = 8;
            this.btnPPP.UseVisualStyleBackColor = true;
            this.btnPPP.Click += new System.EventHandler(this.btnPPP_Click);
            // 
            // btnKKK
            // 
            this.btnKKK.Image = ((System.Drawing.Image)(resources.GetObject("btnKKK.Image")));
            this.btnKKK.Location = new System.Drawing.Point(291, 59);
            this.btnKKK.Name = "btnKKK";
            this.btnKKK.Size = new System.Drawing.Size(62, 34);
            this.btnKKK.TabIndex = 7;
            this.btnKKK.UseVisualStyleBackColor = true;
            this.btnKKK.Click += new System.EventHandler(this.btnKKK_Click);
            // 
            // btn360
            // 
            this.btn360.Image = ((System.Drawing.Image)(resources.GetObject("btn360.Image")));
            this.btn360.Location = new System.Drawing.Point(146, 20);
            this.btn360.Name = "btn360";
            this.btn360.Size = new System.Drawing.Size(34, 34);
            this.btn360.TabIndex = 6;
            this.btn360.UseVisualStyleBackColor = true;
            this.btn360.Click += new System.EventHandler(this.btn360_Click);
            // 
            // btnHCB
            // 
            this.btnHCB.Image = ((System.Drawing.Image)(resources.GetObject("btnHCB.Image")));
            this.btnHCB.Location = new System.Drawing.Point(89, 60);
            this.btnHCB.Name = "btnHCB";
            this.btnHCB.Size = new System.Drawing.Size(34, 34);
            this.btnHCB.TabIndex = 5;
            this.btnHCB.UseVisualStyleBackColor = true;
            this.btnHCB.Click += new System.EventHandler(this.btnHCB_Click);
            // 
            // btnHCF
            // 
            this.btnHCF.Image = ((System.Drawing.Image)(resources.GetObject("btnHCF.Image")));
            this.btnHCF.Location = new System.Drawing.Point(89, 20);
            this.btnHCF.Name = "btnHCF";
            this.btnHCF.Size = new System.Drawing.Size(34, 34);
            this.btnHCF.TabIndex = 4;
            this.btnHCF.UseVisualStyleBackColor = true;
            this.btnHCF.Click += new System.EventHandler(this.btnHCF_Click);
            // 
            // btnDPB
            // 
            this.btnDPB.Image = ((System.Drawing.Image)(resources.GetObject("btnDPB.Image")));
            this.btnDPB.Location = new System.Drawing.Point(49, 59);
            this.btnDPB.Name = "btnDPB";
            this.btnDPB.Size = new System.Drawing.Size(34, 34);
            this.btnDPB.TabIndex = 3;
            this.btnDPB.UseVisualStyleBackColor = true;
            this.btnDPB.Click += new System.EventHandler(this.btnDPB_Click);
            // 
            // btnQCB
            // 
            this.btnQCB.Image = ((System.Drawing.Image)(resources.GetObject("btnQCB.Image")));
            this.btnQCB.Location = new System.Drawing.Point(9, 59);
            this.btnQCB.Name = "btnQCB";
            this.btnQCB.Size = new System.Drawing.Size(34, 34);
            this.btnQCB.TabIndex = 2;
            this.btnQCB.UseVisualStyleBackColor = true;
            this.btnQCB.Click += new System.EventHandler(this.btnQCB_Click);
            // 
            // btnDPF
            // 
            this.btnDPF.Image = ((System.Drawing.Image)(resources.GetObject("btnDPF.Image")));
            this.btnDPF.Location = new System.Drawing.Point(49, 20);
            this.btnDPF.Name = "btnDPF";
            this.btnDPF.Size = new System.Drawing.Size(34, 34);
            this.btnDPF.TabIndex = 1;
            this.btnDPF.UseVisualStyleBackColor = true;
            this.btnDPF.Click += new System.EventHandler(this.btnDPF_Click);
            // 
            // btnQCF
            // 
            this.btnQCF.Image = ((System.Drawing.Image)(resources.GetObject("btnQCF.Image")));
            this.btnQCF.Location = new System.Drawing.Point(9, 20);
            this.btnQCF.Name = "btnQCF";
            this.btnQCF.Size = new System.Drawing.Size(34, 34);
            this.btnQCF.TabIndex = 0;
            this.btnQCF.UseVisualStyleBackColor = true;
            this.btnQCF.Click += new System.EventHandler(this.btnQCF_Click);
            // 
            // btnDelta
            // 
            this.btnDelta.Image = ((System.Drawing.Image)(resources.GetObject("btnDelta.Image")));
            this.btnDelta.Location = new System.Drawing.Point(186, 20);
            this.btnDelta.Name = "btnDelta";
            this.btnDelta.Size = new System.Drawing.Size(34, 34);
            this.btnDelta.TabIndex = 10;
            this.btnDelta.UseVisualStyleBackColor = true;
            this.btnDelta.Click += new System.EventHandler(this.btnDelta_Click);

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 453);
            this.Controls.Add(this.grpQuickInputs);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.grpWait);
            this.Controls.Add(this.grpInputs);
            this.Controls.Add(this.grpTimeLine);
            this.Controls.Add(this.grpItemDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "SF4ComboTrainer";
            this.grpItemDetails.ResumeLayout(false);
            this.grpItemDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numChgWaitFrames)).EndInit();
            this.grpTimeLine.ResumeLayout(false);
            this.grpTimeLine.PerformLayout();
            this.grpInputs.ResumeLayout(false);
            this.grpWait.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numFrames)).EndInit();
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.grpQuickInputs.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnAppend;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoop;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.GroupBox grpInputs;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Button btnHold;
        private System.Windows.Forms.Button btnPress;
        private System.Windows.Forms.RadioButton optForward;
        private System.Windows.Forms.RadioButton optBack;
        private System.Windows.Forms.RadioButton optDown;
        private System.Windows.Forms.CheckBox chkLK;
        private System.Windows.Forms.CheckBox chkHP;
        private System.Windows.Forms.CheckBox chkHK;
        private System.Windows.Forms.CheckBox chkMK;
        private System.Windows.Forms.CheckBox chkMP;
        private System.Windows.Forms.CheckBox chkLP;
        private System.Windows.Forms.RadioButton optUP;
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

        private System.Windows.Forms.GroupBox grpQuickInputs;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btn360;
        private System.Windows.Forms.Button btnHCB;
        private System.Windows.Forms.Button btnHCF;
        private System.Windows.Forms.Button btnDPB;
        private System.Windows.Forms.Button btnQCB;
        private System.Windows.Forms.Button btnDPF;
        private System.Windows.Forms.Button btnQCF;
        private System.Windows.Forms.RadioButton optNeutral;
        private System.Windows.Forms.RadioButton optDL;
        private System.Windows.Forms.RadioButton optUL;
        private System.Windows.Forms.RadioButton optUR;
        private System.Windows.Forms.RadioButton optDR;
        private System.Windows.Forms.Button btnPPP;
        private System.Windows.Forms.Button btnKKK;
        private System.Windows.Forms.Button btnDHCF;
        private System.Windows.Forms.Button btnDelta;


    }
}

