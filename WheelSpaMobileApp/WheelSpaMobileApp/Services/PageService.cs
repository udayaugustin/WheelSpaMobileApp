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

        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}
