using System;
using System.Collections.Generic;

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
    }
}
