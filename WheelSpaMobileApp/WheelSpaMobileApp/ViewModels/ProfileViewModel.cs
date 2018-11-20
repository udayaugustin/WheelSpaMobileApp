using FacebookLogin.Models;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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

        public ProfileViewModel(IPageService pageService, FacebookViewModel facebookViewModel)
        {
            this.pageService = pageService;
            facebookProfile = facebookViewModel.FacebookProfile;

            if (user == null)
            {
                user = new User{userName = facebookProfile?.Email, name = facebookProfile?.Name, roleId = "2", pincode = ""};
            }
        }

        public async Task<bool> CreateUser()
        {
            var validationResult =  await ValidateFields();
            if(validationResult)
            {
                await restServices.AddUser(User);
                return true;
            }

            return false;
        }

        private async Task<bool> ValidateFields()
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var alertMessage = "";

            if (string.IsNullOrEmpty(user.userName) || !regex.Match(user.userName).Success)
            {
                    alertMessage += "Valid Email Address";
            }

            if(string.IsNullOrEmpty(user.name))
            {
                alertMessage += "Name";
            }

            if (string.IsNullOrEmpty(user.mobile))
            {
                alertMessage += "Mobile No";
            }

            if (string.IsNullOrEmpty(user.password))
            {
                alertMessage += "Password";
            }

            if(!string.IsNullOrEmpty(alertMessage))
            {
                var message = "Please enter " + alertMessage;
                await pageService.DisplayAlert("Validation Failed", message, "Ok");
                return false;
            }

            return true;
        }

    }
}
