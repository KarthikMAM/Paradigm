using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Paradigm
{
    public sealed partial class Register : ContentDialog
    {
        public Register()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Button_Click();
        }

        public string Quote(string input)
        {
            return "\"" + input + "\"";
        }

        private async void Button_Click()
        {
            HttpClient clientOb = new HttpClient();
            Uri connectionUrl = new Uri("http://requestb.in/qddlqdqd");

            string jsonString = 
                "{" + 
                Quote("tag") + " : " + Quote("register") + " , " +
                Quote("name") + " : " + Quote(Name.Text) + " , " +
                Quote("institution") + " : " + Quote(Institution.Text) + " , " +
                Quote("year") + " : " + Quote((Year.SelectedItem as ComboBoxItem).Content.ToString()) + " , " +
                Quote("department") + " : " + Quote((Department.SelectedItem as ComboBoxItem).Content.ToString()) + " , " +
                Quote("phone") + " : " + Quote(Phone.Text) + " , " +
                Quote("email") + " : " + Quote(Email.Text) + " , " +
                "}";

            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await clientOb.PostAsync(connectionUrl, (HttpContent)content);
            if (response.IsSuccessStatusCode)
            {
                var dialog = new MessageDialog(await response.Content.ReadAsStringAsync());
                await dialog.ShowAsync();
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void StackPanel_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {

        }
    }
}
