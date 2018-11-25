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
    public partial class RegisterationTapView : TabbedPage
    {
        public RegisterationTapView(FacebookViewModel facebookViewModel = null)
        {
            InitializeComponent();

            this.Children.Add(new ProfileView(new User(), facebookViewModel));
            this.Children.Add(new AddVechicleInfo(new Vehicle()));
        }

        public void SwitchToVechicleInfoTab()
        {
            CurrentPage = Children[1];
        }
    }
}