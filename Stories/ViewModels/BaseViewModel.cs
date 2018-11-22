using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Stories.Services;
using Xamarin.Forms;

namespace Stories.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IWebService DataService { get; }
        public BaseViewModel()
        {
            DataService = DependencyService.Get<IWebService>();
        }

        string _title;
        public string Title
        {
            get => _title;
            set
            {
                if (_title == value)
                {
                    return;
                }
                _title = value;
                OnPropertyChanged();
            }
        }

        bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy == value)
                {
                    return;
                }
                _isBusy = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNotBusy));
            }
        }

        public bool IsNotBusy => !IsBusy;

        string _error;
        public string Error
        {
            get => _error;
            set
            {
                if (_error == value)
                {
                    return;
                }

                _error = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }

}
