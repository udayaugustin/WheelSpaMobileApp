﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WheelSpaMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddVechicleInfo : ContentPage
    {
        public AddVechicleInfo(Vehicle vehicle)
        {
            InitializeComponent();
            BindingContext = new VehicleViewModel(new PageService(), vehicle);
        }
    }
}