using System;
using System.Windows.Input;
using Xamarin.Forms;
using FacebookLogin.Models;

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
                user = new User();

                user.userName = facebookProfile?.Email;
                user.Name = facebookProfile?.Name;
                user.roleId = "2";

            }
        }

        public void CreateUser()
        {
            restServices.AddUser(User);            
        }

    }
}
