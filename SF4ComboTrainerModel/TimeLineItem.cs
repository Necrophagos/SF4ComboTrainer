using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPInputLibrary;

namespace SF4ComboTrainerModel
{
    /**
     * the timeline classes are the core of this application.
     * they represent an entry in the timeline listbox. there are currently 4 types
     * press input, hold input, release input and wait frame.
     * these differences are represented by the following class hierarchy
     * 
     * TimeLineItemModel --- WaitFrameItemModel
     *          |
     *          |------ InputItemModel
     *                      |
     *                      |--- PressItemModel
     *                      |--- HoldItemModel
     *                      |--- ReleaseItemModel
     */

    /**
     * The new layout will incorporate the InputItemModel as the base for Press, Hold and Release.
     * However we will be removing WaitFrameItemModel and incorporating it into InputItemModel.
     * There is no reason to have the WaitFrameItem as we can make the PressItemModel act upon
     * its behalf by inputing a neutral input. This creates a waitframe without any inputs.
     *      
     *          InputItemModel
     *               |
     *               |--- PressItemModel
     *               |--- HoldItemModel
     *               |--- ReleaseItemModel
     */


    public abstract class InputItemModel
    {
        //The static shared sound handler
        protected static Roadie roadie = new Roadie();

        private string description;
        public abstract string Description
        {
            get;
        }

        protected int frames;
        public int Frames
        {
            get { return frames; }
            set
            {
                frames = value;
            }
        }
        public static String itemType = "Wait";

        //arrays that distinguish directional from button inputs (to help find sound)
        public static Input[] Directions = new Input[] { Input.P1_UP, Input.P1_DN, Input.P1_LE, Input.P1_RI, Input.P1_BK, Input.P1_FW };
        public static Input[] Buttons = new Input[] { Input.P1_LP, Input.P1_MP, Input.P1_HP, Input.P1_LK, Input.P1_MK, Input.P1_HK };

        public bool PlaySound = false;

        protected Input[] inputs = new Input[0];
        public Input[] Inputs
        {
            get { return inputs; }
            set
            {
                inputs = value;
            }
        }

        protected SF4InputState inputState = new SF4InputState();
        public SF4InputState InputState
        {
            get { return inputState; }
            set { inputState = value; }
        }
        //creates a string representation of the object
        public abstract String Serialize();

        public static InputItemModel Deserialize(String obj)
        {
            /**
             * Creates a timeline object from a string serialization and assumes the following
             * formats (specified by the respective Serialize methods)
             * 
             * InputItemModel:     ITEMTYPE#PLAYSOUND#NUMFRAMES#NUMIMPUTS[#INPUT1,#INPUT2...]
             */
            String[] tokens = obj.Split('#');

            // Big change: this is the new default to help transform old file type.
            if (tokens[0].Equals(InputItemModel.itemType))
            {
                PressItemModel item = new PressItemModel(int.Parse(tokens[2]));
                item.PlaySound = Boolean.Parse(tokens[1]);
                return item;
            }
            else if (tokens[0].Equals(PressItemModel.itemType))
            {
                int numInputs = int.Parse(tokens[2]);
                Input[] inputs = new Input[numInputs];
                for (int i = 0; i < numInputs; i++)
                {
                    inputs[i] = ParseInput(tokens[3 + i]);
                }
                PressItemModel item = new PressItemModel(inputs);
                item.PlaySound = Boolean.Parse(tokens[1]);
                return item;
            }
            else if (tokens[0].Equals(HoldItemModel.itemType))
            {
                int numInputs = int.Parse(tokens[2]);
                Input[] inputs = new Input[numInputs];
                for (int i = 0; i < numInputs; i++)
                {
                    inputs[i] = ParseInput(tokens[3 + i]);
                }
                HoldItemModel item = new HoldItemModel(inputs);
                item.PlaySound = Boolean.Parse(tokens[1]);
                return item;
            }
            else if (tokens[0].Equals(ReleaseItemModel.itemType))
            {
                int numInputs = int.Parse(tokens[2]);
                Input[] inputs = new Input[numInputs];
                for (int i = 0; i < numInputs; i++)
                {
                    inputs[i] = ParseInput(tokens[3 + i]);
                }
                ReleaseItemModel item = new ReleaseItemModel(inputs);
                item.PlaySound = Boolean.Parse(tokens[1]);
                return item;
            }

            throw new FormatException("Failed to deserialize TimelineItem, wrong string format: " + obj);
        }

        //might be better to use Enum.Parse
        public static Input ParseInput(String str)
        {
            foreach (Input input in Directions)
            {
                if (str.Equals(input.ToString())) { return input; }
            }
            foreach (Input input in Buttons)
            {
                if (str.Equals(input.ToString())) { return input; }
            }
            throw new FormatException("Cannot parse Input for " + str);
        }

        //Deconstructor to make the Roadie private:
        public static void DisposeRoadie()
        {
            roadie.Dispose();
        }

        //core method of the timeline items, gets called when timeline is played
        public abstract void Action(SF4Control sf4control, bool sendInputs);

        //gets amount of frames the item needs to play its action
        public abstract int GetFrameDuration();

        public override string ToString()
        {
            return Description;
        }

        protected string getInputString()
        {
            return getInputString(inputState.ToInputsArray());
        }

        protected String getInputString(params Input[] inputs)
        {
            String inputString = "";
            foreach (Input input in inputs)
            {
                inputString += (input.ToString().Split('_'))[1] + " ";
            }
            return inputString;
        }

    }

    public class PressItemModel : InputItemModel
    {
        public new static String itemType = "Press";

        public override string Description
        {
            get
            {
                if (inputs.Count() > 0 && frames < 2)
                {
                    return itemType + " " + getInputString(inputs);
                }
                else if (inputs.Count() > 0 && frames > 1)
                {
                    return itemType + " " + getInputString(inputs) + " and wait " + frames + " frames";
                }
                else
                {
                    return "Wait " + frames + " frames";
                }
            }
        }

        public PressItemModel()
        {
            new PressItemModel(1);
        }

        public PressItemModel(int frames)
        {
            this.frames = frames;

        }

        public PressItemModel(params Input[] inputs)
        {
            this.inputs = inputs;
            this.frames = 1;
        }
        public PressItemModel(int frames, params Input[] inputs)
        {
            this.inputs = inputs;
            this.frames = frames;
        }
        public override string Serialize()
        {

            String obj = itemType + "#" + PlaySound + "#" + frames + "#" + inputs.Count();
            foreach (Input input in inputs)
            {
                obj += "#" + input;
            }

            return obj;
        }

        public override void Action(SF4Control sf4control, bool sendInputs)
        {
            if (sendInputs)
            {
                sf4control.Press(inputs);
            }
            else
            {
                //press event waits 1 frame, if send inputs is disabled wait frame is maintained
                sf4control.WaitFrames(1);
            }

            if (PlaySound)
            {
                if (inputs.Intersect(Directions).Count() > 0 && inputs.Intersect(Buttons).Count() > 0)
                {
                    roadie.PlaySound(Roadie.WAIT_SOUND);
                }
                else
                {
                    if (inputs.Intersect(Directions).Count() > 0)
                        roadie.PlaySound(Roadie.PRESS_DIRECTION_SOUND);
                    if (inputs.Intersect(Buttons).Count() > 0)
                        roadie.PlaySound(Roadie.PRESS_BUTTON_SOUND);
                }
            }

            //After sound has played we wait the remainder of the frame duration
            sf4control.WaitFrames(this.GetFrameDuration() - 1);
        }

        public override int GetFrameDuration()
        {
            return frames;
        }
    }

    public class HoldItemModel : InputItemModel
    {
        public new static String itemType = "Hold";

        public override string Description
        {
            get
            {
                return itemType + " " + getInputString(inputs);
            }
        }

        public HoldItemModel(params Input[] inputs)
        {
            this.inputs = inputs;
            frames = 0;
        }

        public override void Action(SF4Control sf4control, bool sendInputs)
        {
            if (sendInputs)
            {
                sf4control.Hold(inputs);
            }

            if (PlaySound)
            {
                if (inputs.Intersect(Directions).Count() > 0)
                {
                    roadie.PlaySound(Roadie.HOLD_DIRECTION_SOUND);
                }
                if (inputs.Intersect(Buttons).Count() > 0)
                {
                    roadie.PlaySound(Roadie.HOLD_BUTTON_SOUND);
                }
            }
        }

        public override string Serialize()
        {
            String obj = itemType + "#" + PlaySound + "#" + inputs.Count();
            foreach (Input input in inputs)
            {
                obj += "#" + input;
            }
            return obj;
        }

        public override int GetFrameDuration()
        {
            return GetFrameDuration();
        }
    }

    public class ReleaseItemModel : InputItemModel
    {
        public new static String itemType = "Release";

        public override string Description
        {
            get
            {
                return itemType + " " + getInputString(inputs);
            }
        }

        public ReleaseItemModel(params Input[] inputs)
        {
            this.inputs = inputs;
        }

        public override void Action(SF4Control sf4control, bool sendInputs)
        {
            if (sendInputs)
            {
                sf4control.Release(inputs);
            }

            if (PlaySound)
            {
                if (inputs.Intersect(Directions).Count() > 0)
                {
                    roadie.PlaySound(Roadie.RELEASE_DIRECTION_SOUND);
                }
                if (inputs.Intersect(Buttons).Count() > 0)
                {
                    roadie.PlaySound(Roadie.RELEASE_BUTTON_SOUND);
                }
            }
        }

        public override int GetFrameDuration()
        {
            return 1;
        }

        public override string Serialize()
        {
            String obj = itemType + "#" + PlaySound + "#" + inputs.Count();
            foreach (Input input in inputs)
            {
                obj += "#" + input;
            }
            return obj;
        }
    }
}
