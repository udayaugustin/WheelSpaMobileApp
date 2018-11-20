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
	public partial class ProfileView : ContentPage
	{
		public ProfileView (FacebookViewModel facebookViewModel)
		{
            BindingContext = new ProfileViewModel(new PageService(), facebookViewModel);
            InitializeComponent();
		}

        private async Task SubmitUserDetails(object sender, EventArgs e)
        {
            var tappedPage = this.Parent as AddtionalUserInfo;
            var isValidationSuccess = await (BindingContext as ProfileViewModel)?.CreateUser();
            if (isValidationSuccess)
            {
                tappedPage.SwitchToVechicleInfoTab();
            }

        }
    }
}