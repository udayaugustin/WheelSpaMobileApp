using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace WheelSpaMobileApp
{
    public class VehicleViewModel
    {
        private Vehicle vehicle;
        private RestServices restServices;
        private IPageService pageService;

        public Vehicle Vehicle
        {
            get
            {
                return vehicle;
            }
            set
            {
                vehicle = value;
            }
        }

        public ICommand SubmitCommand
        {
            get;
            set;
        }

        public VehicleViewModel(IPageService pageService, Vehicle vehicle)
        {
            restServices = new RestServices();
            this.pageService = pageService;
            this.vehicle = vehicle;
            this.vehicle.VehicleType = "Bike";
            this.vehicle.VehicleModel = "2018";
            this.vehicle.UserId = "1";

            SubmitCommand = new Command(async () => await AddVehcicle());
        }

        private async Task AddVehcicle()
        {
            var result = await restServices.AddVehicle(vehicle);

            if(result?.Status == "success")
            {
                await pageService.PushAsync(new Services());
            }
        }
    }
}
