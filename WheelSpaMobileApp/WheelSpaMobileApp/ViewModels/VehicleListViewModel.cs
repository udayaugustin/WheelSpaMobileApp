using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace WheelSpaMobileApp
{
    public class VehicleListViewModel : INotifyPropertyChanged
    {
        private IPageService pageService;
        private RestServices restServices;
        private List<Vehicle> vehicleList;
        private Vehicle selectedVehicle;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddNewVehicle{ get; set; }

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

        public Vehicle SelectedVehicle
        {
            get
            {
                return selectedVehicle;
            }
            set
            {
                if (value != null)
                {
                    selectedVehicle = value;
                    GoToVehicleManageView(selectedVehicle);
                }
            }
        }

        public VehicleListViewModel(IPageService pageService)
        {
            this.pageService = pageService;
            restServices = new RestServices();
            AddNewVehicle = new Command<Vehicle>((v) => GoToVehicleManageView(new Vehicle()));            
        }

        public async Task GetVehicleList()
        {
            VehicleList = await restServices.GetVehicleList((Application.Current as App).UserAuthToken);
        }

        private void GoToVehicleManageView(Vehicle vehicle)
        {
            pageService.PushAsync(new AddVechicleInfo(vehicle));
        }        
    }
}
