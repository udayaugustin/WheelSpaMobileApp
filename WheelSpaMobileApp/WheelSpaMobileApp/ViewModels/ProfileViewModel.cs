using FacebookLogin.Models;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace WheelSpaMobileApp
{
    public class ProfileViewModel
    {
        private IPageService pageService;
        private User user;
        RestServices restServices = new RestServices();

        public FacebookProfile facebookProfile { get; set; }

        public User User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        public ProfileViewModel(IPageService pageService, User user, FacebookViewModel facebookViewModel = null)
        {
            this.pageService = pageService;

            if (user.UserName == null)
            {
                user.RoleId = "2";
                if (facebookViewModel != null)
                {
                    facebookProfile = facebookViewModel?.FacebookProfile;
                    user.UserName = facebookProfile?.Email;
                    user.Name = facebookProfile?.Name;
                    user.LoginType = "facebook";
                }                
            }

            this.user = user;
        }

        public async Task<bool> CreateUser()
        {
            var validationResult = await ValidateFields();
            if (validationResult)
            {
                ResultData result = await restServices.AddUser(User);
                if (result.Status == "success")
                {
                    (Application.Current as App).UserAuthToken = result.AuthToken;
                    (App.Current as App).LoggedInUserId = result.UserDetails.UserId;

                    return true;
                }

                await pageService.DisplayAlert(result.Status, result.Message, "Ok");
            }

            return false;
        }

        private async Task<bool> ValidateFields()
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var alertMessage = "";

            if (string.IsNullOrEmpty(user.UserName) || !regex.Match(user.UserName).Success)
            {
                alertMessage += "Valid Email Address";
            }

            if (string.IsNullOrEmpty(user.Name))
            {
                alertMessage += "Name";
            }

            if (string.IsNullOrEmpty(user.Mobile))
            {
                alertMessage += "Mobile No";
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                alertMessage += "Password";
            }

            if (!string.IsNullOrEmpty(alertMessage))
            {
                var message = "Please enter " + alertMessage;
                await pageService.DisplayAlert("Validation Failed", message, "Ok");
                return false;
            }

            return true;
        }

    }
}
