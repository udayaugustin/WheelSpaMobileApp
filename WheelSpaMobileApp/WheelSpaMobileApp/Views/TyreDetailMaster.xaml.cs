using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WheelSpaMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TyreDetailMaster : ContentPage
    {
        public ListView ListView;

        public TyreDetailMaster()
        {
            InitializeComponent();
            BindingContext = new TyreDetailMasterViewModel();
            ListView = MenuItemsListView;
        }

        class TyreDetailMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<TyreDetailMenuItem> MenuItems { get; set; }

            public TyreDetailMasterViewModel()
            {
                MenuItems = new ObservableCollection<TyreDetailMenuItem>(new[]
                {
                    new TyreDetailMenuItem { Id = 0, Title = "Service History", Icon="service"},
                    new TyreDetailMenuItem { Id = 1, Title = "Service Offered", Icon="offer" },
                    new TyreDetailMenuItem { Id = 2, Title = "Appoinment", Icon="appoinment" },
                    new TyreDetailMenuItem { Id = 3, Title = "Notifications", Icon="notification" },
                    new TyreDetailMenuItem { Id = 4, Title = "Vehicle Tyres", Icon="vehicletyre" },
                    new TyreDetailMenuItem { Id = 5, Title = "Feedback", Icon="feedback" },
                    new TyreDetailMenuItem { Id = 6, Title = "Settings", Icon="settings" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}