using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WheelSpaMobileApp
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private IPageService pageService;
        private RestServices restServices;
        private bool isLoading;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AuthenticateViaFacebook { get; set; }

        public ICommand AuthenticateUserViaManual { get; set; }

        public ICommand GoToRegisterPage { get; set; }

        public User User { get; set; }

        public bool IsLoading
        {
            get
            {
                return isLoading;
            }
            set
            {
                isLoading = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsLoading)));
            }
        }


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
            IsLoading = true;
            var result = await restServices.AuthenticateUserViaManual(User);
            isLoading = false;
            if (string.Equals(result.Status, CommonConstants.SuccessStatus, StringComparison.OrdinalIgnoreCase))
            {
                (App.Current as App).UserAuthToken = result.UserDetails.AuthToken;
                (App.Current as App).LoggedInUserId = result.UserDetails.UserId;
                await GoToServicePage();
            }
            else
            {
                await pageService.DisplayAlert("Failed", "Username or password is wrong", "Ok");
            }
        }

        private async Task GoToServicePage()
        {
            await pageService.UpdateNavigationPage(new VehicleList());
        }

        private async Task NaviagateToRegisterPage()
        {
            await pageService.PushAsync(new RegisterationTapView());
        }
    }
}
