
using System;
namespace WheelSpaMobileApp
{
    public class ProfileViewModel
    {
        private IPageService pageService;

        public FacebookViewModel FacebookViewModel { get; set; }

        public ProfileViewModel(IPageService pageService, FacebookViewModel facebookViewModel)
        {
            this.pageService = pageService;
            FacebookViewModel = facebookViewModel;

        }
    }
}
