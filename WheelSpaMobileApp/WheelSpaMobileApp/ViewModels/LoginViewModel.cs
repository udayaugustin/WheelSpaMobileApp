using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using System;

namespace WheelSpaMobileApp
{
    public class LoginViewModel
    {
        private IPageService pageService;
        public ICommand AuthenticateViaFacebook { get; set; }


        public LoginViewModel(IPageService pageService)
        {
            this.pageService = pageService;
            AuthenticateViaFacebook = new Command(async () => await FacebookLoginAsync());
        }

        private async Task FacebookLoginAsync()
        {
            await pageService.PushAsync(new FacebookProfileCsPage(pageService));
        }
    }
}
