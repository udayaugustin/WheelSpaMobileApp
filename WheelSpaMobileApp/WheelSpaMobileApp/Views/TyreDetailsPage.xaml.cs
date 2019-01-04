using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WheelSpaMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TyreDetailsPage : TabbedPage
    {
        public TyreDetailsPage()
        {
            InitializeComponent();
            BindingContext = new TyreViewModel(new PageService(), (Application.Current as App).UserAuthToken);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var vehicleList = (new RestServices()).GetVehicleList("orqg9711");
        }
    }
}