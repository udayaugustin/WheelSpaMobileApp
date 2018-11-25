using Xamarin.Forms;

namespace WheelSpaMobileApp
{
    public partial class App : Application
    {
        private const string AuthToken = "AuthToken";

        public App()
        {
            InitializeComponent();

            if (IsUserloggedIn)
            {
                //MainPage = new NavigationPage(new Services()) { BarBackgroundColor = Color.FromHex("#2699FB"), BarTextColor = Color.White };
                MainPage = new NavigationPage(new Login()) { BarBackgroundColor = Color.FromHex("#2699FB"), BarTextColor = Color.White };
            }
            else
            {
                MainPage = new NavigationPage(new Login()) { BarBackgroundColor = Color.FromHex("#2699FB"), BarTextColor = Color.White };
            }
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public string UserAuthToken
        {
            get
            {
                if (Properties.ContainsKey(AuthToken))
                {
                    return Properties[AuthToken].ToString();
                }

                return string.Empty;
            }

            set
            {
                Properties[AuthToken] = value;
                Current.SavePropertiesAsync();
            }
        }

        public bool IsUserloggedIn
        {
            get
            {
                if (!string.IsNullOrEmpty(UserAuthToken))
                {
                    return true;
                }

                return false;
            }
        }
    }
}
