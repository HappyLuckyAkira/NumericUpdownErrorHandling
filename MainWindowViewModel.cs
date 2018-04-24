using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;

namespace WpfAppErrorHandling
{
    class MainWindowViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double input1_;
        private double input2_;
        bool hasViewError;
        public bool HasViewError
        {
            get { return hasViewError; }
            set
            {
                hasViewError = value;
                OnPropertyChanged("hasViewError");
                SampleCommand.RaiseCanExecuteChanged();
            }
        }

        public MainWindowViewModel()
        {
            this.SampleCommand = new DelegateCommand(
                // Execute
                () =>
                {
                },
                // CanExecute
                () =>
                {
                    return !HasViewError;
                });
        }

        public DelegateCommand SampleCommand { get; private set; }
        public double Input1
        {
            get { return input1_; }
            set
            {
                input1_ = value;
                OnPropertyChanged("Input1");
            }
        }
        public double Input2
        {
            get { return input2_; }
            set
            {
                input2_ = value;
                OnPropertyChanged("Input2");
            }
        }
        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
