using Paradigm.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Paradigm
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Registration : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public Registration()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (progrssRing.IsActive == false && System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                progrssRing.SetValue(ProgressRing.IsActiveProperty, true);

                Click();

                progrssRing.SetValue(ProgressRing.IsActiveProperty, false);
            }
            else
            {
                new MessageDialog("The registration client is unable to connect. Please try again in a short while !!", "⛔ " + "UNABLE TO CONNECT").ShowAsync();
            }
        }

        public bool Validate()
        {
            if (Name.Text == "" || Institution.Text == "" || Phone.Text == "" || Email.Text == "")
            {
                new MessageDialog("There should not be any empty fields", "⛔ " + "EMPTY FIELDS").ShowAsync();
                return false;
            }

            if (Phone.Text.Length != 10)
            {
                new MessageDialog("The phone number is your identification. It must be a 10 digit standard phone number.", "⛔ " + "INVALID NUMBER").ShowAsync();
                return false;
            }

            if (Regex.IsMatch(Email.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$") == false)
            {
                new MessageDialog("The Email Id is used to send your Paradigm Id. Please enter a valid Email ID.", "⛔ " + "INVALID EMAIL ID").ShowAsync();
                return false;
            }

            return true;
        }

        public void Click()
        {
            if (Validate())
            {
                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(10);

                Uri connectionUrl = new Uri("http://www.ssnparadigm.com/register/paradigmapi/index.php");

                List<KeyValuePair<string, string>> form = new List<KeyValuePair<string, string>>();

                form.Add(new KeyValuePair<string, string>("tag", "register"));
                form.Add(new KeyValuePair<string, string>("name", Name.Text));
                form.Add(new KeyValuePair<string, string>("institution", Institution.Text));
                form.Add(new KeyValuePair<string, string>("year", (Convert.ToString(Year.SelectedIndex + 1))));
                form.Add(new KeyValuePair<string, string>("department", (Department.SelectedItem as ComboBoxItem).Content.ToString()));
                form.Add(new KeyValuePair<string, string>("phone", Phone.Text));
                form.Add(new KeyValuePair<string, string>("email", Email.Text));

                FormUrlEncodedContent x = new FormUrlEncodedContent(form);

                HttpResponseMessage response = client.PostAsync(connectionUrl, x).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = Result(response.Content.ReadAsStringAsync().Result).Result;
                }
                else
                {
                    new MessageDialog("The registration client is unable to connect. Please try again in a short while !!", "⛔ " + "UNABLE TO CONNECT").ShowAsync();
                }
            }
        }

        public async Task<bool> Result(string result)
        {
            string finalString = result;

            if (result.Contains("\"tag\":\"register\""))
            {
                if (result.Contains("\"success\":0") || result.Contains("\"error\":1"))
                {
                    new MessageDialog("The phone number you have entered is already registered. If not, mail to helpdesk@ssnparadigm.com", "⛔ " + "ERROR").ShowAsync();
                    return false;
                }

                if (result.Contains("\"RegStatus\":\"success\"") && result.Contains("\"success\":1,\"error\":0"))
                {
                    new MessageDialog("Registration Success. Please Check your mail for further details.", "☑ " + "SUCCESS").ShowAsync();
                    return true;
                }
            }

            new MessageDialog("It seems that there is an error in the data you sent. Please Contact helpdesk@ssnparadigm.com", "⛔ " + "ERROR").ShowAsync();
            return false;
        }

        private void Name_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                Phone.Focus(FocusState.Programmatic);
            }
        }

        private void Phone_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                Email.Focus(FocusState.Programmatic);
            }
        }

        private void Email_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                Institution.Focus(FocusState.Programmatic);
            }
        }

        private void Institution_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if (progrssRing.IsActive == false && System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    progrssRing.IsActive = true;

                    Click();

                    progrssRing.IsActive = false;
                }
                else
                {
                    new MessageDialog("The registration client is unable to connect. Please try again in a short while !!", "⛔ " + "UNABLE TO CONNECT").ShowAsync();
                }
            }
        }

        private void HelpDesk_Click(object sender, RoutedEventArgs e)
        {
            new Navigation_Links("null", "null", "mailto:helpdesk@ssnparadigm.com", "9566260418", "HELP DESK").ShowAsync();
        }
    }
}