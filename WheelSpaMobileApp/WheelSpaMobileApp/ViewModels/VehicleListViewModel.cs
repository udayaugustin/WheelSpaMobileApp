using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace WheelSpaMobileApp
{
    public class VehicleListViewModel : INotifyPropertyChanged
    {
        private IPageService pageService;
        private RestServices restServices;
        private List<Vehicle> vehicleList;
        private List<string> vehicleNoList;
        private Vehicle selectedVehicle;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Vehicle> VehicleList
        {
            get
            {
                return vehicleList;
            }
            set
            {
                vehicleList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VehicleList)));
            }
        }

        public Vehicle SelectedVehicle { get; set; }

        public VehicleListViewModel(IPageService pageService)
        {
            this.pageService = pageService;
            Task.Run(async () =>
            {
                VehicleList = await restServices.GetVehicleList("orqg9711");
            });
        }
    }
}
