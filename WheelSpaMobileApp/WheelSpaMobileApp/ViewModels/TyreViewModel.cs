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
        private string sameTypeTyreStatus;
        private string differentTypeFrontTyreStatus;
        private string differentTypeRearTyreStatus;
        private List<Vehicle> vehicleList;
        private string selectedVehicle;
        private List<string> vehicleNoList;

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

        public Vehicle SelectedVehicle
        {
            get; set;
        }

        public ICommand SubmitCommand { get; set; }

        public TyreViewModel(IPageService pageService, string authToken)
        {
            restServices = new RestServices();
            Task.Run(async () =>
            {
                VehicleList = await restServices.GetVehicleList("orqg9711");
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
            string VehicleId = "7";
            string AuthToken = (Application.Current as App).UserAuthToken;
            string TyreType = type;
            string jsonData = string.Empty;
            if (type == CommonConstants.SameTypeTyre)
            {
                SameTyre.TyreStatus = SameTypeTyreStatus;
                jsonData = JsonConvert.SerializeObject(
                    new
                    {
                        AuthToken,
                        VehicleId,
                        TyreType,
                        SameTyre
                    });
            }
            else
            {
                DifferentTypeTyre.FrontTyre.TyreStatus = DifferentTypeFrontTyreStatus;
                DifferentTypeTyre.RearTyre.TyreStatus = DifferentTypeRearTyreStatus;
                jsonData = JsonConvert.SerializeObject(
                    new
                    {
                        AuthToken,
                        VehicleId,
                        TyreType,
                        DifferentTypeTyre
                    });
            }

            var result = await restServices.AddTyreInfo(jsonData);
            if (result.Status == CommonConstants.SuccessStatus)
            {

            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
