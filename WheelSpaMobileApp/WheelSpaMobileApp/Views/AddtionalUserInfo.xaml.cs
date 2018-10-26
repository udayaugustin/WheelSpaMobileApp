using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WheelSpaMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddtionalUserInfo : TabbedPage
    {
        public AddtionalUserInfo(FacebookViewModel facebookViewModel)
        {            
            InitializeComponent();

            BindingContext = new ProfileViewModel(new PageService(), facebookViewModel);

        }
    }
}