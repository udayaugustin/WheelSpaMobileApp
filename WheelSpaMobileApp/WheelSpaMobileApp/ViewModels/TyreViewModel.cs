using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace WheelSpaMobileApp
{
    public class TyreViewModel : INotifyPropertyChanged
    {
        private RestServices restServices;
        private IPageService pageService;
        private string sameTypeTyreStatus;
        private string differentTypeFrontTyreStatus;
        private string differentTypeRearTyreStatus;
        private List<Vehicle> vehicleList;        
        private List<string> vehicleNoList;
        private string TyreType;
        private string alertMessage;
        private string sameTyreSelectedVehicle;
        private string differentTyreSelectedVehicle;

        public event PropertyChangedEventHandler PropertyChanged;

        public Tyre SameTyre { get; set; }

        public DifferentTypeTyre DifferentTypeTyre { get; set; }

        public List<string> TyreStatusList { get; set; }

        public string SameTypeTyreStatus
        {
            get
            {
                return sameTypeTyreStatus;
            }
            set
            {
                sameTypeTyreStatus = value;
                OnPropertyChanged();
            }
        }

        public string DifferentTypeFrontTyreStatus
        {
            get
            {
                return differentTypeFrontTyreStatus;
            }
            set
            {
                differentTypeFrontTyreStatus = value;
                OnPropertyChanged();
            }
        }

        public string DifferentTypeRearTyreStatus
        {
            get
            {
                return differentTypeRearTyreStatus;
            }
            set
            {
                differentTypeRearTyreStatus = value;
                OnPropertyChanged();
            }
        }

        public List<Vehicle> VehicleList
        {
            get
            {
                return vehicleList;
            }
            set
            {
                vehicleList = value;
                OnPropertyChanged();
            }
        }

        public List<string> VehicleNoList
        {
            get
            {
                return vehicleNoList;
            }
            set
            {
                vehicleNoList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VehicleNoList)));
            }
        }

        public string SameTyreSelectedVehicle
        {
            get
            {
                return sameTyreSelectedVehicle;
            }
            set
            {
                sameTyreSelectedVehicle = value;
                OnPropertyChanged();
            }
        }

        public string DifferentTyreSelectedVehicle
        {
            get
            {
                return differentTyreSelectedVehicle;
            }
            set
            {
                differentTyreSelectedVehicle = value;
                OnPropertyChanged();
            }
        }

        public ICommand SubmitCommand { get; set; }

        public TyreViewModel(IPageService pageService, string authToken)
        {
            restServices = new RestServices();
            this.pageService = pageService;
            Task.Run(async () =>
            {
                VehicleList = await restServices.GetVehicleList((Application.Current as App).UserAuthToken);
                VehicleNoList = VehicleList.Select(l => l.VehicleNo).ToList();
            });

            SameTyre = new Tyre();
            DifferentTypeTyre = new DifferentTypeTyre
            {
                FrontTyre = new Tyre(),
                RearTyre = new Tyre()
            };
            TyreStatusList = new List<string>()
            {
                CommonConstants.NewTyreType,
                CommonConstants.OldTyreType
            };

            SubmitCommand = new Command<string>(async (type) => await Submit(type));
        }

        private async Task Submit(string type)
        {
            string vehicleId;
            string authToken = (Application.Current as App).UserAuthToken;
            TyreType = type;

            string jsonData = string.Empty;
            if (type == CommonConstants.SameTypeTyre)
            {
                vehicleId = VehicleList.Where(v => v.VehicleNo == SameTyreSelectedVehicle).FirstOrDefault()?.VehicleId;
                SameTyre.TyreStatus = SameTypeTyreStatus;

                if (!ValidateFields())
                    return;

                jsonData = JsonConvert.SerializeObject(
                    new
                    {
                        authToken,
                        vehicleId,
                        TyreType,
                        SameTyre
                    });
            }
            else
            {
                vehicleId = VehicleList.Where(v => v.VehicleNo == DifferentTyreSelectedVehicle).FirstOrDefault()?.VehicleId;
                DifferentTypeTyre.FrontTyre.TyreStatus = DifferentTypeFrontTyreStatus;
                DifferentTypeTyre.RearTyre.TyreStatus = DifferentTypeRearTyreStatus;

                if (!ValidateFields())
                    return;

                jsonData = JsonConvert.SerializeObject(
                    new
                    {
                        authToken,
                        vehicleId,
                        TyreType,
                        DifferentTypeTyre
                    });
            }

            var result = await restServices.AddTyreInfo(jsonData);
            if (result.Status == CommonConstants.SuccessStatus)
            {

            }
        }

        private string GenerateJsonData(string authToken, string vehicleId, string TyreType, object Tyre )
        {
            return "";
        }

        private bool ValidateFields()
        {
            if (TyreType == CommonConstants.SameTypeTyre)
            {
                if (!IsTyrePropertiesAreEmpty(SameTyre))
                {
                    pageService.DisplayAlert("Validation Failed", alertMessage, "ok");
                    return false;
                }
            }
            else
            {
                if (!IsTyrePropertiesAreEmpty(DifferentTypeTyre.FrontTyre))
                {
                    pageService.DisplayAlert("Front Tyre Validation Failed", alertMessage, "ok");
                    return false;
                }
                if (!IsTyrePropertiesAreEmpty(DifferentTypeTyre.RearTyre))
                {
                    pageService.DisplayAlert("Rear Tyre Validation Failed", alertMessage, "ok");
                    return false;
                }
            }

            return true;
        }

        private bool IsTyrePropertiesAreEmpty(Tyre tyre)
        {
            alertMessage = string.Empty;
            if (string.IsNullOrEmpty(tyre.TyreStatus))
            {
                alertMessage += "Tyre Status";
            }

            if (string.IsNullOrEmpty(tyre.TyreBrand))
            {
                alertMessage += "Tyre Brand";
            }

            if (string.IsNullOrEmpty(tyre.TyreName))
            {
                alertMessage += "Tyre Name";
            }

            if (string.IsNullOrEmpty(tyre.TyreSize))
            {
                alertMessage += "Tyre Size";
            }

            if (string.IsNullOrEmpty(tyre.RimSize))
            {
                alertMessage += "Rim Size";
            }

            if (string.IsNullOrEmpty(tyre.TyreLife))
            {
                alertMessage += "Tyre Life";
            }

            if (string.IsNullOrEmpty(tyre.DateOfPurchase))
            {
                alertMessage += "Date Of Purchase";
            }

            if (!string.IsNullOrEmpty(alertMessage))
                return false;

            return true;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
