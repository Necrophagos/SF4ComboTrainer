using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SF4ComboTrainer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            sf4memory = new SF4Memory(chkSteamVersion.Checked);
            sf4control = new SF4Control(sf4memory);

        }

        private SF4Memory sf4memory;
        private SF4Control sf4control;


        //update item detail box when timeline item is clicked
        private int selectedTimeLineIndex;
        private void TimeLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!TimeLine.Focused) { return; }
            TimeLineItem curItem = (TimeLineItem)TimeLine.SelectedItem;
            if (curItem == null)
            {
                lblIndex.Text = "0:";
                lblDescription.Text = "";
                lblCurrentFrame.Text = "Current Frame: ";
                numChgWaitFrames.Enabled = false;
                numChgWaitFrames.Value = 1;
                chkPlaySound.Checked = false;
                selectedTimeLineIndex = -1;
                return;
            }
            selectedTimeLineIndex = TimeLine.SelectedIndex;
            int index = selectedTimeLineIndex;

            lblIndex.Text = (index + 1) + ":";
            lblDescription.Text = curItem.ToString();

            int currentFrame = 0;
            for (int i = 0; i < index; i++)
            {
                currentFrame += ((TimeLineItem)TimeLine.Items[i]).getFrameDuration();
            }
            lblCurrentFrame.Text = "Current Frame: " + currentFrame;
            chkPlaySound.Checked = curItem.playSound;

            if (curItem.GetType() == typeof(WaitFrameItem))
            {
                numChgWaitFrames.Enabled = true;
                numChgWaitFrames.Value = ((WaitFrameItem)curItem).getFrameDuration();
            }
            else
            {
                numChgWaitFrames.Enabled = false;
                numChgWaitFrames.Value = 1;
            }

        }

        private void chkPlaySound_CheckedChanged(object sender, EventArgs e)
        {
            TimeLineItem tlItem = ((TimeLineItem)TimeLine.SelectedItem);
            if (null != tlItem)
            {
                tlItem.playSound = chkPlaySound.Checked;
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {

            int index = TimeLine.SelectedIndex;
            if (0 >= index) { return; }
            TimeLineItem tmp = (TimeLineItem)TimeLine.Items[index];
            TimeLine.Items[index] = TimeLine.Items[index - 1];
            TimeLine.Items[index - 1] = tmp;
            TimeLine.SetSelected(index - 1, true);

        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            int index = TimeLine.SelectedIndex;
            if (TimeLine.Items.Count - 1 == index || 0 > index) { return; }
            TimeLineItem tmp = (TimeLineItem)TimeLine.Items[index];
            TimeLine.Items[index] = TimeLine.Items[index + 1];
            TimeLine.Items[index + 1] = tmp;
            TimeLine.SetSelected(index + 1, true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (TimeLine.SelectedItem == null) { return; }
            TimeLine.Items.Remove(TimeLine.SelectedItem);
        }


        private void btnWait_Click(object sender, EventArgs e)
        {
            TimeLine.Items.Add(new WaitFrameItem((int)numFrames.Value));
            numFrames.Value = 1;
        }

        private void btnPress_Click(object sender, EventArgs e)
        {
            Input[] inputs = getInputs();
            if (inputs.Count() == 0) { return; }
            TimeLine.Items.Add(new PressItem(inputs));
            resetInputBoxes();
        }

        private void btnHold_Click(object sender, EventArgs e)
        {
            Input[] inputs = getInputs();
            if (inputs.Count() == 0) { return; }
            TimeLine.Items.Add(new HoldItem(inputs));
            resetInputBoxes();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            Input[] inputs = getInputs();
            if (inputs.Count() == 0) { return; }
            TimeLine.Items.Add(new ReleaseItem(inputs));
            resetInputBoxes();
        }

        private Input[] getInputs()
        {

            List<Input> inputList = new List<Input>();

            if (chkUP.Checked) { inputList.Add(Input.P1_UP); }
            if (chkDown.Checked) { inputList.Add(Input.P1_DN); }
            if (chkBack.Checked) { inputList.Add(Input.P1_BK); }
            if (chkForward.Checked) { inputList.Add(Input.P1_FW); }
            if (chkLP.Checked) { inputList.Add(Input.P1_LP); }
            if (chkMP.Checked) { inputList.Add(Input.P1_MP); }
            if (chkHP.Checked) { inputList.Add(Input.P1_HP); }
            if (chkLK.Checked) { inputList.Add(Input.P1_LK); }
            if (chkMK.Checked) { inputList.Add(Input.P1_MK); }
            if (chkHK.Checked) { inputList.Add(Input.P1_HK); }

            return inputList.ToArray();
        }

        private void resetInputBoxes()
        {
            chkUP.Checked = false;
            chkDown.Checked = false;
            chkBack.Checked = false;
            chkForward.Checked = false;
            chkLP.Checked = false;
            chkMP.Checked = false;
            chkHP.Checked = false;
            chkLK.Checked = false;
            chkMK.Checked = false;
            chkHK.Checked = false;
        }

        //the steam version of street fighter has different memory adressed that the retail version
        //sf4memory class must be notified
        private void chkSteamVersion_CheckedChanged(object sender, EventArgs e)
        {
            sf4memory.setSteamVersion(chkSteamVersion.Checked);
        }

        //changes the wait frames for a waitframe item
        //this evet fires even when the value is changed from the program (as happens in the TimeLine_SelectedIndexChanged method)
        //thats why this method used this crude numChgWaitFrames.Focused countermeasure to avoid infinte loops.
        private void numChgWaitFrames_ValueChanged(object sender, EventArgs e)
        {
            if (numChgWaitFrames.Focused)
            {
                int index = selectedTimeLineIndex;
                TimeLine.Items.Insert(index, new WaitFrameItem((int)numChgWaitFrames.Value));
                TimeLine.Items.RemoveAt(index + 1);
                TimeLine.Focus();
                TimeLine.SetSelected(index, true);
            }
        }


        private void playTimeline()
        {
            for (int i = 0; i < TimeLine.Items.Count; i++)
            {
                TimeLineItem item = (TimeLineItem)TimeLine.Items[i];

                // if we aren't in a match (defined by being on a menu or pause is selected) the play timeline stops.
                if (sf4control.inMatch) item.Action(sf4control, chkSendInputs.Checked);

                // i chose to comment this out because it looks nicer when the highlight goes to the bottom.
                //else
                //    break;


                //highlighting of current item
                DoThreadSafe(TimeLine, () =>
                {
                    TimeLine.TopIndex = i - (TimeLine.ClientSize.Height / TimeLine.ItemHeight) / 2;
                    TimeLine.SelectedItem = item;
                });

            }

            sf4control.releaseALL();
        }

        public static void DoThreadSafe(Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(action);
            }
            else
            {
                action();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (chkAutoSwitch.Checked)
            {
                if (!sf4control.switchToSF4()) { return; }
                sf4control.waitFrames(10);
            }

            freezeTimeline();
            playTimeline();
            unfreezeTimeline();
        }

        //Loop section
        private System.Threading.Thread loopThread = null;
        private volatile bool _shouldStop;
        private void btnLoop_Click(object sender, EventArgs e)
        {
            if (FramesInTimeline < 1) { return; }

            freezeTimeline();

            if (chkAutoSwitch.Checked)
            {
                if (!sf4control.switchToSF4()) { return; }
                sf4control.waitFrames(10);
            }

            //prevent multiple threads
            if (null != loopThread) { return; }

            loopThread = new System.Threading.Thread(playLoop);
            loopThread.Start();

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _shouldStop = true;
            if (loopThread != null)
            {
                loopThread.Join();
                loopThread = null;
            }
            unfreezeTimeline();
        }

        ///LOOP THREAD METHOD       
        public void playLoop()
        {
            _shouldStop = false;

            // This inMatch check will make it so if you pause the game during the loop it stops the loop.
            while (!_shouldStop && sf4control.inMatch)
            {
                playTimeline();
            }
        }

        private int FramesInTimeline
        {
            get
            {
                int sum = 0;
                foreach (TimeLineItem item in TimeLine.Items)
                {
                    sum += item.getFrameDuration();
                }
                return sum;
            }

        }




        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SF4 Combo|*.cmb";
            saveFileDialog.Title = "Save your combo";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog.FileName))
                {
                    foreach (TimeLineItem item in TimeLine.Items)
                    {
                        file.WriteLine(item.serialize());
                    }
                }
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "SF4 Combo|*.cmb";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] lines = System.IO.File.ReadAllLines(openFileDialog.FileName);

                foreach (String line in lines)
                {
                    TimeLine.Items.Add(TimeLineItem.deserialize(line));
                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Click yes to delete all timeline items.", "Clear Timeline?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                TimeLine.Items.Clear();
            }
        }

        //disables UI while timeline is playing to avoid weird malfunctioning
        private void freezeTimeline()
        {
            btnSave.Enabled = false;
            btnLoad.Enabled = false;
            btnClear.Enabled = false;

            btnPlay.Enabled = false;
            btnLoop.Enabled = false;

            btnMoveDown.Enabled = false;
            btnMoveUp.Enabled = false;
            btnDelete.Enabled = false;
            numChgWaitFrames.Enabled = false;

            btnWait.Enabled = false;

            btnPress.Enabled = false;
            btnHold.Enabled = false;
            btnRelease.Enabled = false;

            TimeLine.Enabled = false;
        }

        private void unfreezeTimeline()
        {
            btnSave.Enabled = true;
            btnLoad.Enabled = true;
            btnClear.Enabled = true;

            btnPlay.Enabled = true;
            btnLoop.Enabled = true;

            btnMoveDown.Enabled = true;
            btnMoveUp.Enabled = true;
            btnDelete.Enabled = true;
            numChgWaitFrames.Enabled = true;

            btnWait.Enabled = true;

            btnPress.Enabled = true;
            btnHold.Enabled = true;
            btnRelease.Enabled = true;

            TimeLine.Enabled = true;
        }








    }
}
