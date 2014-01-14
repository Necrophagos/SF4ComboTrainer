using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SF4ComboTrainer
{
    /**
     * the timeline classes are the core of this application.
     * they represent an entry in the timeline listbox. there are currently 4 types
     * press input, hold input, release input and wait frame.
     * these differences are represented by the following class hierarchy
     * 
     * TimeLineItem --- WaitFrameItem
     *          |
     *          |------ InputItem
     *                      |
     *                      |--- PressItem
     *                      |--- HoldItem
     *                      |--- ReleaseItem
     */
    abstract class TimeLineItem
    {

        //The static shared sound handler
        protected static Roadie roadie = new Roadie();

        public String Description;

        //arrays that distinguish directional from button inputs (to help find sound)
        public static Input[] Directions = new Input[] { Input.P1_UP, Input.P1_DN, Input.P1_LE, Input.P1_RI, Input.P1_BK, Input.P1_FW };
        public static Input[] Buttons = new Input[] { Input.P1_LP, Input.P1_MP, Input.P1_HP, Input.P1_LK, Input.P1_MK, Input.P1_HK };

        public bool PlaySound = false;

        //creates a string representation of the object
        public abstract String Serialize();

        /**creates a timeline object from a string serialization and assumes the following
         * formats (specified by the respective Serialize methods)
         * 
         * WaitFrameItem: ITEMTYPE#PLAYSOUND#NUMFRAMES
         * InputItem:     ITEMTYPE#PLAYSOUND#NUMIMPUTS#INPUT1#INPUT2...
         */
        public static TimeLineItem Deserialize(String obj)
        {

            String[] tokens = obj.Split('#');

            if (tokens[0].Equals(WaitFrameItem.itemType))
            {
                WaitFrameItem item = new WaitFrameItem(int.Parse(tokens[2]));
                item.PlaySound = Boolean.Parse(tokens[1]);
                return item;
            }
            else if (tokens[0].Equals(PressItem.itemType))
            {
                int numInputs = int.Parse(tokens[2]);
                Input[] inputs = new Input[numInputs];
                for (int i = 0; i < numInputs; i++)
                {
                    inputs[i] = ParseInput(tokens[3 + i]);
                }
                PressItem item= new PressItem(inputs);
                item.PlaySound = Boolean.Parse(tokens[1]);
                return item;
            }
            else if (tokens[0].Equals(HoldItem.itemType))
            {
                int numInputs = int.Parse(tokens[2]);
                Input[] inputs = new Input[numInputs];
                for (int i = 0; i < numInputs; i++)
                {
                    inputs[i] = ParseInput(tokens[3 + i]);
                }
                HoldItem item = new HoldItem(inputs);
                item.PlaySound = Boolean.Parse(tokens[1]);
                return item;
            }
            else if (tokens[0].Equals(ReleaseItem.itemType))
            {
                int numInputs = int.Parse(tokens[2]);
                Input[] inputs = new Input[numInputs];
                for (int i = 0; i < numInputs; i++)
                {
                    inputs[i] = ParseInput(tokens[3 + i]);
                }
                ReleaseItem item = new ReleaseItem(inputs);
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
    }

    class WaitFrameItem : TimeLineItem
    {
        private int frames;

        public static String itemType = "Wait";

        public WaitFrameItem(int frames)
        {
            this.frames = frames;
            this.Description = "Wait " + frames + " frames";
        }

        public override int GetFrameDuration()
        {
            return frames;
        }

        public override string Serialize()
        {
            return itemType + "#" + PlaySound + "#" + frames;
        }

        public override void Action(SF4Control sf4control, bool sendInputs)
        {
            sf4control.WaitFrames(frames);
            if (PlaySound) { roadie.PlaySound(Roadie.WAIT_SOUND); }
        }

    }

    abstract class InputItem : TimeLineItem
    {

        protected Input[] inputs;


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

    class PressItem : InputItem
    {
        public static String itemType = "Press";

        public PressItem(params Input[] inputs)
        {

            this.inputs = inputs;
            this.Description = itemType + " " + getInputString(inputs);

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
                if (inputs.Intersect(Directions).Count() > 0)
                {
                    roadie.PlaySound(Roadie.PRESS_DIRECTION_SOUND);
                }
                if (inputs.Intersect(Buttons).Count() > 0)
                {
                    roadie.PlaySound(Roadie.PRESS_BUTTON_SOUND);
                }
            }
        }


    }

    class HoldItem : InputItem
    {
        public static String itemType = "Hold";

        public HoldItem(params Input[] inputs)
        {
            this.inputs = inputs;
            this.Description = itemType + " " + getInputString(inputs);
        }

        public override int GetFrameDuration()
        {
            return 0;
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
    }

    class ReleaseItem : InputItem
    {
        public static String itemType = "Release";

        public ReleaseItem(params Input[] inputs)
        {
            this.inputs = inputs;
            this.Description = itemType + " " + getInputString(inputs);
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
