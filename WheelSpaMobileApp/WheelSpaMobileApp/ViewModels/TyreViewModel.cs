using System.Windows.Input;
using Xamarin.Forms;

namespace WheelSpaMobileApp
{
    public class TyreViewModel
    {
        public Tyre SameTyre { get; set; }

        public DifferentTypeTyre DifferentTypeTyre { get; set; }

        public ICommand SubmuitCommand { get; set; }

        public TyreViewModel(IPageService pageService)
        {
            SubmuitCommand = new Command(Submit);
        }

        private void Submit()
        {

        }

    }
}
