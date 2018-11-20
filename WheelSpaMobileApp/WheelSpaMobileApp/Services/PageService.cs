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

        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}
