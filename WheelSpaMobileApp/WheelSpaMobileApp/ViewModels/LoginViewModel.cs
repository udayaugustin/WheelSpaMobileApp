using System.Windows.Input;
using Xamarin.Forms;

namespace WheelSpaMobileApp
{
    public class LoginViewModel
    {
        public ICommand AuthenticateViaFacebook { get; set; }

        public LoginViewModel()
        {
            AuthenticateViaFacebook = new Command(FacebookLogin);
        }

        private void FacebookLogin()
        {
            
        }
    }
}
