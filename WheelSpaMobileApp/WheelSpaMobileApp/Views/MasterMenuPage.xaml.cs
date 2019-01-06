using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;

namespace WheelSpaMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMenuPage : ContentPage
    {
        private IPageService pageService;

        public ListView ListView;

        public MasterMenuPage()
        {
            InitializeComponent();
            BindingContext = new MasterMenuPageViewModel();

            pageService = new PageService();
            ListView = MenuItemsListView;
        }

        class MasterMenuPageViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<TyreDetailMenuItem> MenuItems { get; set; }

            public MasterMenuPageViewModel()
            {
                MenuItems = new ObservableCollection<TyreDetailMenuItem>(new[]
                {
                    new TyreDetailMenuItem { Id = 4, Title = MenuListConstants.VehicleList, Icon="vehicletyre"},
                    new TyreDetailMenuItem { Id = 4, Title = MenuListConstants.VehicleTyres, Icon="vehicletyre"},
                    new TyreDetailMenuItem { Id = 0, Title = MenuListConstants.ServiceHistory, Icon="service"},
                    new TyreDetailMenuItem { Id = 1, Title = MenuListConstants.ServiceOffered, Icon="offer" },
                    new TyreDetailMenuItem { Id = 2, Title = MenuListConstants.Appoinment, Icon="appoinment" },
                    new TyreDetailMenuItem { Id = 3, Title = MenuListConstants.Notifications, Icon="notification" },
                    new TyreDetailMenuItem { Id = 5, Title = MenuListConstants.Feedback, Icon="feedback" },
                    new TyreDetailMenuItem { Id = 6, Title = MenuListConstants.Settings, Icon="settings" },
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

        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menuItem = e.SelectedItem as TyreDetailMenuItem;
            if (menuItem.Title.Equals(MenuListConstants.VehicleList))
            {
                pageService.PushAsync(new VehicleList());
            }

            if (menuItem.Title.Equals(MenuListConstants.VehicleTyres))
            {
                pageService.PushAsync(new TyreDetailsPage());
            }

            pageService.HideHamburgerMenu();
        }
    }
}