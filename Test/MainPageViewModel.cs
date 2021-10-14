using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Test
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private int index = 0;
        public ObservableCollection<string> Items { get; set; } = new ObservableCollection<string>();
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SetNextIndexCommand { get; private set; }

        public int Index
        {
            get { return index; }
            set
            {
                index = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Index"));
            }
        }

        public MainPageViewModel()
        {
            SetNextIndexCommand = new Command(SetNextIndex);

            Items.Add("First");
            Items.Add("Second");
            Items.Add("Third");
        }

        private void SetNextIndex()
        {
            Index = (Index + 1) % 3;
        }
    }
}