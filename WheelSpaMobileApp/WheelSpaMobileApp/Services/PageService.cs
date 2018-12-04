using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks;
using WheelSpaMobileApp.Views;
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

        public void PushAsMainPage(Page page)
        {
            //var rootPage = new Mas();
            //rootPage.Master = new TyreDetailMaster();
            //(Application.Current as App).NavigationPage = new NavigationPage(new TyreDetailDetail());
            //rootPage.Detail = (Application.Current as App).NavigationPage;
            //Application.Current.MainPage = rootPage;
        }

        public async Task PushAsync(Page page)
        {
            await (Application.Current as App).NavigationPage.PushAsync(page);
        }

        public async Task UpdateNavigationPage(Page page)
        {
            var app = (Application.Current as App);
            var servicePage = new Services();
            var homePage = app.NavigationPage.Navigation.NavigationStack.First();
            app.NavigationPage.Navigation.InsertPageBefore(servicePage, homePage);
            await app.NavigationPage.PopToRootAsync(false);
        }
    }
}
