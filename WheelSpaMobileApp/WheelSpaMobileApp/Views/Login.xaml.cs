using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WheelSpaMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(new PageService());
        }
    }
}