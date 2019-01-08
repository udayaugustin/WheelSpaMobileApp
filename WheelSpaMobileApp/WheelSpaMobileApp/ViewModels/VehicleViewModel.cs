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
        private string alertMessage;
        
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

        public VehicleViewModel(IPageService pageService, Vehicle vehicle, string userId)
        {
            restServices = new RestServices();
            this.pageService = pageService;
            this.vehicle = vehicle;
            this.vehicle.VehicleType = "Bike";
            this.vehicle.VehicleModel = "2018";
            this.vehicle.UserId = (Application.Current as App).LoggedInUserId;

            SubmitCommand = new Command(async () => await AddVehcicle());
        }

        private async Task AddVehcicle()
        {
            if (ValidateFields())
            {
                var result = await restServices.AddVehicle(vehicle);

                if (result?.Status == "success")
                {
                    await pageService.UpdateNavigationPage(new Services());
                }
            }
            else
            {
                await pageService.DisplayAlert("Validation Failed", alertMessage, "ok");
            }
        }

        private bool ValidateFields()
        {
            string errorMessage = string.Empty;

            if (string.IsNullOrEmpty(vehicle.VehicleNo))
            {
                errorMessage = "No";
            }

            if (string.IsNullOrEmpty(vehicle.VehicleName))
            {
                errorMessage += "Name";
            }

            if (string.IsNullOrEmpty(vehicle.VehicleBrand))
            {
                errorMessage += "Brand";
            }

            if (string.IsNullOrEmpty(vehicle.VehicleModel))
            {
                errorMessage += "Model";
            }

            if (string.IsNullOrEmpty(vehicle.VehicleType))
            {
                errorMessage += "Type";
            }

            if (string.IsNullOrEmpty(vehicle.VehicleVersion))
            {
                errorMessage += "Version";
            }

            if (string.IsNullOrEmpty(vehicle.YearPurchase))
            {
                errorMessage += "Year Purchase";
            }

            if (string.IsNullOrEmpty(vehicle.KmDone))
            {
                errorMessage += "Km Done";
            }

            if (string.IsNullOrEmpty(vehicle.AvgDrive))
            {
                errorMessage += "Avg Drive";
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                alertMessage = "Please enter " + errorMessage + " of the vehicle";
                return false;
            }

            return true;
        }
    }
}
