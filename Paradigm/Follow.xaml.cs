using Paradigm.Common;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Paradigm
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Follow : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public Follow()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            Developers.Items.Add(Paradigm.TeamMember("Karthik M A M", "9487907066", "Developer & Design", "Karthik M A M.jpg"));
            Developers.Items.Add(Paradigm.TeamMember("Dineshraj Gunasekaran", "8754434808", "Design", "Dinesh Raj.jpg"));

            Credits.Items.Add(Paradigm.TeamMember("Mohan Kumar P T", "7708819811", "Assets Design", "Mohan.jpg"));
            Credits.Items.Add(Paradigm.TeamMember("Mohan Sha", "9551175171", "Assets Design", "Mohan Sha.jpg"));
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

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch((sender as ListView).Name)
            {
                case "Facebook":
                    Windows.System.Launcher.LaunchUriAsync(new Uri("https://www.facebook.com/ssnparadigm"));
                    break;
                case "Website":
                    Windows.System.Launcher.LaunchUriAsync(new Uri("http://www.ssnparadigm.com/"));
                    break;
                case "Maps":
                    Windows.System.Launcher.LaunchUriAsync(new Uri("https://www.google.co.in/maps/dir//SSN+College+of+Engineering,+Old+Mahabalipuram+Road,+Kalavakkam,+Tamil+Nadu+603110/@12.7508651,80.1972702,17z/data=!4m12!1m3!3m2!1s0x3a52512f04729e11:0xbc4ea0ae50ca1aaa!2sSSN+College+of+Engineering!4m7!1m0!1m5!1m1!1s0x3a52512f04729e11:0xbc4ea0ae50ca1aaa!2m2!1d80.1972702!2d12.7508651?hl=en"));
                    break;
            }
        }

        private void Developers_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem == Developers.Items[0])
            {
                new Navigation_Links("http://www.github.com/KarthikMAM", "https://www.facebook.com/karthik.king.165", "mailto:karthik_m_a_m@outlook.com", "9487907066", "Karthik M A M").ShowAsync();
            }
            else if (e.ClickedItem == Developers.Items[1])
            {
                new Navigation_Links("null", "https://www.facebook.com/dineshraj.gunasekaran", "mailto:dhinu145@gmail.com", "8754434808", "Dineshraj Gunasekaran").ShowAsync();
            }
            else if (e.ClickedItem == Credits.Items[0])
            {
                new Navigation_Links("null", "https://www.facebook.com/mohankumarssn", "mailto:mohankumarssn@gmail.com", "7708819811", "Mohan Kumar P T").ShowAsync();
            }
            else if (e.ClickedItem == Credits.Items[1])
            {
                new Navigation_Links("null", "https://www.facebook.com/mohanshadon", "mailto:mohansha@outlook.com", "9551175171", "Mohan Sha").ShowAsync();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Windows.System.Launcher.LaunchUriAsync(new Uri("https://docs.google.com/forms/d/1FZ1lWqaOh1KI0rFCv6Irix4yMsj8EslnXQicaz-Y_Bg/viewform?usp=send_form"));
        }
    }
}
