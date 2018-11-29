using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WheelSpaMobileApp
{
    public class PageService : IPageService
    {
        private Page MainPage;
        public PageService()
        {
            MainPage = Application.Current.MainPage;
        }

        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public async Task UpdateNavigationPage(Page page)
        {
            var firstPage = (Application.Current as App).NavigationPage.Navigation.NavigationStack.First();
            (Application.Current as App).NavigationPage.Navigation.InsertPageBefore(page, firstPage);
            await (Application.Current as App).NavigationPage.PopToRootAsync(false);
        }

        public async Task PushAsync(Page page)
        {
            await (Application.Current as App).NavigationPage.PushAsync(page);
        }
    }
}
