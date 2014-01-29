using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF4ComboTrainerModel;
using TPInputLibrary;
using SF4ComboTrainerView;

namespace SF4ComboTrainerViewModel
{
    public class InputViewModel : ObservableObject
    {
        private SF4InputState inputState;
        public SF4InputState InputState
        {
            get { return inputState; }
            set
            {
                if (value != inputState)
                {
                    inputState = value;
                    OnPropertyChanged("InputState");
                }
            }
        }


    }
}
