using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF4ComboTrainerView
{
    class TimeLineItemCollectionViewModel : ObservableObject
    {
        private ObservableCollection<TimeLineItemViewModel> timeLineItems;
        public ObservableCollection<TimeLineItemViewModel> TimeLineItems
        {
            get { return timeLineItems; }
            set
            {
                if (value != timeLineItems)
                {
                    timeLineItems = value;
                    OnPropertyChanged("TimeLineItems");
                }
            }
        }
        
    }
}
