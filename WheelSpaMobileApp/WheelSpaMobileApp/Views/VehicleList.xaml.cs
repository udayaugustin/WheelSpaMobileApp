using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WheelSpaMobileApp
{
    public partial class VehicleList : ContentPage
    {
        public VehicleList()
        {
            InitializeComponent();
            BindingContext = new VehicleListViewModel(new PageService());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await (BindingContext as VehicleListViewModel).GetVehicleList();
        }
    }
}
