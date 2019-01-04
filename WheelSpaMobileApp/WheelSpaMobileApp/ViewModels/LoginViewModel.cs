using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace WheelSpaMobileApp
{
    public class LoginViewModel
    {
        private IPageService pageService;
        private RestServices restServices;

        public ICommand AuthenticateViaFacebook { get; set; }

        public ICommand AuthenticateUserViaManual { get; set; }

        public ICommand GoToRegisterPage { get; set; }

        public User User { get; set; }


        public LoginViewModel(IPageService pageService)
        {
            this.pageService = pageService;
            restServices = new RestServices();
            User = new User();

            AuthenticateViaFacebook = new Command(async () => await FacebookLoginAsync());
            AuthenticateUserViaManual = new Command(async () => await AuthenticateUser());
            GoToRegisterPage = new Command(async () => await NaviagateToRegisterPage());
        }

        private async Task FacebookLoginAsync()
        {
            await pageService.PushAsync(new FacebookProfileCsPage(pageService));            
        }

        private async Task AuthenticateUser()
        {
            var result = await restServices.AuthenticateUserViaManual(User);
            if (result.Status == "Success")
            {
                (App.Current as App).UserAuthToken = result.UserDetails.AuthToken;
            }

            await GoToServicePage();
        }

        private async Task GoToServicePage()
        {
            await pageService.UpdateNavigationPage(new Services());
        }

        private async Task NaviagateToRegisterPage()
        {
            await pageService.PushAsync(new RegisterationTapView());
        }
    }
}
