using System;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Rankings.Xamarin.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            using (var client = new HttpClient()
            {
                BaseAddress = new Uri("http://192.168.1.198:9111")
            }
                )
            {
                var result = client.GetAsync("weatherforecast").GetAwaiter().GetResult();

                var content = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                Title = content;
            }


       

            OpenWebCommand = new Command(() => Launcher.OpenAsync(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}