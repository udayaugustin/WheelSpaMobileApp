using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace WheelSpaMobileApp
{
    public class TyreViewModel : INotifyPropertyChanged
    {
        private RestServices restServices;
        private string selectedTyreStatus;

        public event PropertyChangedEventHandler PropertyChanged;

        public Tyre SameTyre { get; set; }

        public DifferentTypeTyre DifferentTypeTyre { get; set; }

        public List<string> TyreStatusList { get; set; }

        public string SelectedTyreStatus
        {
            get
            {
                return selectedTyreStatus;
            }
            set
            {
                selectedTyreStatus = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedTyreStatus)));
            }
        }

        public ICommand SubmitCommand { get; set; }

        public TyreViewModel(IPageService pageService)
        {
            restServices = new RestServices();
            SameTyre = new Tyre();
            DifferentTypeTyre = new DifferentTypeTyre
            {
                FrontTyre = new Tyre(),
                RearTyre = new Tyre()
            };
            TyreStatusList = new List<string>()
            {
                "New",
                "Old"
            };

            SubmitCommand = new Command<string>(async (type) => await Submit(type));
        }

        private async Task Submit(string type)
        {
            string VehicleId = "7";
            string AuthToken = (Application.Current as App).UserAuthToken;
            string TyreType = type;
            string jsonData = string.Empty;
            if (type == "Same")
            {
                SameTyre.TyreStatus = SelectedTyreStatus;
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
                DifferentTypeTyre.FrontTyre.TyreStatus = SelectedTyreStatus;
                DifferentTypeTyre.RearTyre.TyreStatus = selectedTyreStatus;
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
            if (result.Status == "Success")
            {

            }
        }

    }
}
