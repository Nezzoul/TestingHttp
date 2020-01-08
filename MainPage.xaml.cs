using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestingHttp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {

            this.InitializeComponent();
            DataProvider.DataProvider.InitializeClient();
        }


        private async void GetDataAsync()
        {
            string url = "https://cat-fact.herokuapp.com/facts/random?animal_type=cat&amount=1";
            Result.Text = "One";
            using (HttpResponseMessage response = await DataProvider.DataProvider.ApiClient.GetAsync(url))
            {
                Result.Text = "Two";
                if(response.IsSuccessStatusCode)
                {
                    Result.Text = "Yepp";
                }
                else
                {
                    Result.Text = "Nope";
                }
            }
                
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = "Start";
             GetDataAsync();
        }
    }
}
