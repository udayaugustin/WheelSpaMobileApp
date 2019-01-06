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
    public partial class MasterRootPage : Xamarin.Forms.MasterDetailPage
    {
        public MasterRootPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }
    }
}