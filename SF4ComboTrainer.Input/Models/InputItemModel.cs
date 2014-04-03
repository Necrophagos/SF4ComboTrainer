namespace SF4ComboTrainer.Input.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    using SF4ComboTrainer.Input.Utilities;

    /**
    * the timeline classes are the core of this application.
    * they represent an entry in the timeline listbox. there are currently 4 types
    * press input, hold input, release input and wait frame.
    * these differences are represented by the following class hierarchy
    * 
    * InputItemModel --- WaitFrameItemModel
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

    [Serializable()]
    public class InputItemModel
    {
        public enum InputItemTypeEnum
        {
            Wait,
            Press,
            Hold,
            Release
        }

        /// <summary>
        /// The sound handler.
        /// </summary>
        protected static Roadie roadie = new Roadie();

        /// <summary>
        /// The type of the time line item.
        /// </summary>
        public InputItemTypeEnum InputItemType = InputItemTypeEnum.Wait;

        /// <summary>
        /// Array that defines directional inputs.
        /// </summary>
        public static Input[] Directions = new Input[] { Input.P1_UP, Input.P1_DN, Input.P1_LE, Input.P1_RI, Input.P1_BK, Input.P1_FW };

        /// <summary>
        /// Array that defines button inputs.
        /// </summary>
        public static Input[] Buttons = new Input[] { Input.P1_LP, Input.P1_MP, Input.P1_HP, Input.P1_LK, Input.P1_MK, Input.P1_HK };

        /// <summary>
        /// The frame duration of this Time Line Item.
        /// </summary>
        public int Frames { get; set; }

        /// <summary>
        /// If set to true, will play a sound on the time line item being played in the time line.
        /// </summary>
        public bool PlaySound = false;

        public Input[] Inputs { get { return InputCommandState.ToInputsArray(); } }

        /// <summary>
        /// The InputCommandState that is configured by the view model.
        /// </summary>
        public InputCommandModel InputCommandState { get; set; }

        /// <summary>
        /// Abstract definition for serializing the inputs into a string. Must be defined by any inheritting classes
        /// </summary>
        /// <returns><see cref="string"/></returns>
        public string Serialize()
        {

            String obj = Enum.GetName(typeof(InputItemTypeEnum), InputItemType) + "#" + PlaySound + "#" + Frames + "#" + Inputs.Count();
            foreach (Input input in Inputs)
            {
                obj += "#" + input;
            }

            return obj;
        }

        /// <summary>
        /// Static definition for deserializing a string into a set of inputs.
        /// </summary>
        /// <param name="value">The <see cref="string"/> value to deserialize.</param>
        /// <returns><see cref="InputItemModel"/> containing the inputs from the string.</returns>
        //public static InputItemModel Deserialize(String value)
        //{
        //    /**
        //     * Creates a timeline object from a string serialization and assumes the following
        //     * formats (specified by the respective Serialize methods)
        //     * 
        //     * InputItemModel:     ItemType#PlaySound#NumFrames#NumInputs[#Input1,#Input2...]
        //     *                        
        //     */
        //    String[] tokens = value.ToUpper().Split('#');

        //    // Big change: this is the new default to help transform old file type.
        //    if (tokens[0].Equals(InputItemTypeEnum.WAIT.ToString()))
        //    {
        //        PressItemModel item = new PressItemModel(int.Parse(tokens[2]));
        //        item.PlaySound = Boolean.Parse(tokens[1]);
        //        return item;
        //    }
        //    else if (tokens[0].Equals(InputItemTypeEnum.PRESS.ToString()))
        //    {
        //        int numInputs = int.Parse(tokens[2]);
        //        Input[] inputs = new Input[numInputs];
        //        for (int i = 0; i < numInputs; i++)
        //        {
        //            inputs[i] = ParseInput(tokens[3 + i]);
        //        }
        //        PressItemModel item = new PressItemModel(inputs);
        //        item.PlaySound = Boolean.Parse(tokens[1]);
        //        return item;
        //    }
        //    else if (tokens[0].Equals(InputItemTypeEnum.HOLD.ToString()))
        //    {
        //        int numInputs = int.Parse(tokens[2]);
        //        Input[] inputs = new Input[numInputs];
        //        for (int i = 0; i < numInputs; i++)
        //        {
        //            inputs[i] = ParseInput(tokens[3 + i]);
        //        }
        //        HoldItemModel item = new HoldItemModel(inputs);
        //        item.PlaySound = Boolean.Parse(tokens[1]);
        //        return item;
        //    }
        //    else if (tokens[0].Equals(InputItemTypeEnum.RELEASE.ToString()))
        //    {
        //        int numInputs = int.Parse(tokens[2]);
        //        Input[] inputs = new Input[numInputs];
        //        for (int i = 0; i < numInputs; i++)
        //        {
        //            inputs[i] = ParseInput(tokens[3 + i]);
        //        }
        //        ReleaseItemModel item = new ReleaseItemModel(inputs);
        //        item.PlaySound = Boolean.Parse(tokens[1]);
        //        return item;
        //    }

        //    throw new FormatException("Failed to deserialize TimelineItem, wrong string format: " + value);
        //}

        public static InputItemModel Deserialize(string value) { 
            return new InputItemModel( );
        }

        /// <summary>
        /// Parses inputs from string to an input enum.
        /// </summary>
        /// <param name="str">The <see cref="string"/> to convert.</param>
        /// <returns><see cref="Input"/></returns>
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

        /// <summary>
        ///  Deconstructor to make the Roadie private.
        /// </summary>
        public static void DisposeRoadie()
        {
            roadie.Dispose();
        }

        public string GetInputString()
        {
            return GetInputString(Inputs);
        }

        public string GetInputString(params Input[] inputs)
        {
            String inputString = "";
            foreach (Input input in inputs)
            {
                inputString += (input.ToString().Split('_'))[1] + " ";
            }
            return inputString;
        }

        /// <summary>
        /// Action is called when timeline is played.
        /// </summary>
        /// <param name="sf4control">The SF4Control.</param>
        /// <param name="sendInputs">If true, sends inputs to the running instance of SF4.</param>
        public void Action(SF4Control sf4control, bool sendInputs)
        {
            if (sendInputs)
            {
                sf4control.Press(InputCommandState);
            }
            else
            {
                //press event waits 1 frame, if send inputs is disabled wait frame is maintained
                sf4control.WaitFrames(1);
            }

            if (PlaySound)
            {
                if (Inputs.Intersect(Directions).Count() > 0 && Inputs.Intersect(Buttons).Count() > 0)
                {
                    roadie.PlaySound(Roadie.WAIT_SOUND);
                }
                else
                {
                    if (Inputs.Intersect(Directions).Count() > 0)
                        roadie.PlaySound(Roadie.PRESS_DIRECTION_SOUND);
                    if (Inputs.Intersect(Buttons).Count() > 0)
                        roadie.PlaySound(Roadie.PRESS_BUTTON_SOUND);
                }
            }

            //After sound has played we wait the remainder of the frame duration
            sf4control.WaitFrames(Frames - 1);
        }

        public InputItemModel(InputCommandModel inputCommand)
        {
            InputCommandState = inputCommand;
            InputItemType = InputItemTypeEnum.Wait;
        }
        
        public InputItemModel() : this(new InputCommandModel()){}
    }
}