using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WheelSpaMobileApp
{
    public interface IPageService
    {
        Task PushAsync(Page page);

        void PushAsMainPage(Page page);

        Task DisplayAlert(string title, string message, string cancel);

        Task UpdateNavigationPage(Page page);

        void HideHamburgerMenu();
    }
}
