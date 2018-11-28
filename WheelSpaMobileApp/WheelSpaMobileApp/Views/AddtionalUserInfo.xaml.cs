using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WheelSpaMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterationTapView : TabbedPage
    {
        public RegisterationTapView(FacebookViewModel facebookViewModel = null)
        {
            InitializeComponent();

            Children.Add(new ProfileView(new User(), facebookViewModel));
            Children.Add(new AddVechicleInfo(new Vehicle()));
        }

        public void SwitchToVechicleInfoTab()
        {
            CurrentPage = Children[1];
        }
    }
}