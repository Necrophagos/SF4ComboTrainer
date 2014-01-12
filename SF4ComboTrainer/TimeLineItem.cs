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

        public static Roadie roadie = new Roadie();
        
        //creates a string representation of the object
        public abstract String serialize();

        /**creates a timeline object from a string serialization and assumes the following
         * formats (specified by the respective serialize methods)
         * 
         * WaitFrameItem: ITEMTYPE#PLAYSOUND#NUMFRAMES[#ENABLED]
         * InputItem:     ITEMTYPE#PLAYSOUND#NUMIMPUTS#INPUT1#INPUT2...[#ENABLED]
         */
        public static TimeLineItem deserialize(String obj)
        {

            String[] tokens = obj.Split('#');

            if (tokens[0].Equals(WaitFrameItem.itemType))
            {
                WaitFrameItem item = new WaitFrameItem(int.Parse(tokens[2]));
                item.playSound = Boolean.Parse(tokens[1]);
                if (tokens.Length == 4)
                {
                    item.enabled = (bool.Parse(tokens[3]));
                }
                return item;
            }
            else if (tokens[0].Equals(PressItem.itemType))
            {
                int numInputs = int.Parse(tokens[2]);
                Input[] inputs = new Input[numInputs];
                for (int i = 0; i < numInputs; i++)
                {
                    inputs[i] = parseInput(tokens[3 + i]);
                }
                PressItem item= new PressItem(inputs);
                item.playSound = Boolean.Parse(tokens[1]);
                if (tokens.Length == 3 + numInputs + 1)
                {
                    item.enabled = (bool.Parse(tokens[3 + numInputs]));
                }
                return item;
            }
            else if (tokens[0].Equals(HoldItem.itemType))
            {
                int numInputs = int.Parse(tokens[2]);
                Input[] inputs = new Input[numInputs];
                for (int i = 0; i < numInputs; i++)
                {
                    inputs[i] = parseInput(tokens[3 + i]);
                }
                HoldItem item = new HoldItem(inputs);
                item.playSound = Boolean.Parse(tokens[1]);
                if (tokens.Length == 3 + numInputs + 1)
                {
                    item.enabled = (bool.Parse(tokens[3 + numInputs]));
                }
                return item;
            }
            else if (tokens[0].Equals(ReleaseItem.itemType))
            {
                int numInputs = int.Parse(tokens[2]);
                Input[] inputs = new Input[numInputs];
                for (int i = 0; i < numInputs; i++)
                {
                    inputs[i] = parseInput(tokens[3 + i]);
                }
                ReleaseItem item = new ReleaseItem(inputs);
                item.playSound = Boolean.Parse(tokens[1]);
                if (tokens.Length == 3 + numInputs + 1)
                {
                    item.enabled = (bool.Parse(tokens[3 + numInputs]));
                }
                return item;
            }

            throw new FormatException("Failed to deserialize TimelineItem, wrong string format: " + obj);
        }

        //might be better to use Enum.Parse
        public static Input parseInput(String str)
        {
            foreach (Input input in directions)
            {
                if (str.Equals(input.ToString())) { return input; }
            }
            foreach (Input input in buttons)
            {
                if (str.Equals(input.ToString())) { return input; }
            }
            throw new FormatException("Cannot parse Input for " + str);
        }

        //arrays that distinguish directional from button inputs (to help find sound)
        public static Input[] directions = new Input[] { Input.P1_UP, Input.P1_DN, Input.P1_LE, Input.P1_RI, Input.P1_BK, Input.P1_FW };
        public static Input[] buttons = new Input[] { Input.P1_LP, Input.P1_MP, Input.P1_HP, Input.P1_LK, Input.P1_MK, Input.P1_HK };

        //core method of the timeline items, gets called when timeline is played
        public abstract void Action(SF4Control sf4control, bool sendInputs);

        //gets amount of frames the item needs to play its action
        public abstract int getFrameDuration();

        public bool playSound = false;

        public String description;

        public bool enabled = true;

        public override string ToString()
        {
            return description;
        }
    }

    class WaitFrameItem : TimeLineItem
    {
        private int frames;

        public static String itemType = "Wait";

        public WaitFrameItem(int frames)
        {
            this.frames = frames;
            this.description = "Wait " + frames + " frames";
        }

        public override int getFrameDuration()
        {
            return frames;
        }

        public override string serialize()
        {
            return itemType + "#" + playSound + "#" + frames + "#" + enabled;
        }

        public override void Action(SF4Control sf4control, bool sendInputs)
        {
            sf4control.waitFrames(frames);
            if (playSound) { roadie.playSound(Roadie.WAIT_SOUND); }
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
            this.description = itemType + " " + getInputString(inputs);

        }

        public override int getFrameDuration()
        {
            return 1;
        }

        public override string serialize()
        {
            String obj = itemType + "#" + playSound + "#" + inputs.Count();
            foreach (Input input in inputs)
            {
                obj += "#" + input;
            }
            obj += "#" + enabled;
            return obj;
        }

        public override void Action(SF4Control sf4control, bool sendInputs)
        {
            if (sendInputs)
            {
                sf4control.press(inputs);
            }
            else
            {
                //press event waits 1 frame, if send inputs is disabled wait frame is maintained
                sf4control.waitFrames(1);
            }

            if (playSound)
            {
                if (inputs.Intersect(directions).Count() > 0)
                {
                    roadie.playSound(Roadie.PRESS_DIRECTION_SOUND);
                }
                if (inputs.Intersect(buttons).Count() > 0)
                {
                    roadie.playSound(Roadie.PRESS_BUTTON_SOUND);
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
            this.description = itemType + " " + getInputString(inputs);
        }

        public override int getFrameDuration()
        {
            return 0;
        }


        public override void Action(SF4Control sf4control, bool sendInputs)
        {
            if (sendInputs)
            {
                sf4control.hold(inputs);
            }

            if (playSound)
            {
                if (inputs.Intersect(directions).Count() > 0)
                {
                    roadie.playSound(Roadie.HOLD_DIRECTION_SOUND);
                }
                if (inputs.Intersect(buttons).Count() > 0)
                {
                    roadie.playSound(Roadie.HOLD_BUTTON_SOUND);
                }
            }
        }



        public override string serialize()
        {
            String obj = itemType + "#" + playSound + "#" + inputs.Count();
            foreach (Input input in inputs)
            {
                obj += "#" + input;
            }
            obj += "#" + enabled;
            return obj;
        }
    }

    class ReleaseItem : InputItem
    {
        public static String itemType = "Release";

        public ReleaseItem(params Input[] inputs)
        {
            this.inputs = inputs;
            this.description = itemType + " " + getInputString(inputs);
        }

        public override void Action(SF4Control sf4control, bool sendInputs)
        {
            if (sendInputs)
            {
                sf4control.release(inputs);
            }

            if (playSound)
            {
                if (inputs.Intersect(directions).Count() > 0)
                {
                    roadie.playSound(Roadie.RELEASE_DIRECTION_SOUND);
                }
                if (inputs.Intersect(buttons).Count() > 0)
                {
                    roadie.playSound(Roadie.RELEASE_BUTTON_SOUND);
                }
            }
        }

        public override int getFrameDuration()
        {
            return 1;
        }



        public override string serialize()
        {
            String obj = itemType + "#" + playSound + "#" + inputs.Count();
            foreach (Input input in inputs)
            {
                obj += "#" + input;
            }
            obj += "#" + enabled;
            return obj;
        }
    }

}
