using Paradigm.Common;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.UI.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Paradigm
{
    public class FeedItem
    {
        public string headLine;
        public string lastUpdate;
        public string description;
    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Feeds : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public static StackPanel AddFeed(FeedItem feed)
        {
            StackPanel panel = new StackPanel();

            TextBlock headLine = new TextBlock()
            {
                FontFamily = new FontFamily("Segoe UI Semibold"),
                TextWrapping = Windows.UI.Xaml.TextWrapping.Wrap,
                Text = feed.headLine,
                FontSize = 20,
                FontWeight = FontWeights.ExtraBold
            };

            TextBlock lastUpdate = new TextBlock()
            {
                TextWrapping = Windows.UI.Xaml.TextWrapping.Wrap,
                Text = feed.lastUpdate,
            };

            TextBlock description = new TextBlock()
            {
                TextWrapping = Windows.UI.Xaml.TextWrapping.Wrap,
                Text = feed.description,
                FontSize = 15,
            };

            var margin = panel.Margin;
            margin.Bottom = margin.Top = margin.Left = margin.Right = 5;
            panel.Margin = margin;

            panel.Children.Add(headLine);
            panel.Children.Add(lastUpdate);
            panel.Children.Add(description);

            return panel;
        }

        public Feeds()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            RefreshRotate.Begin();
            RefreshRotate.Pause();
        }

        public async Task UpdateRss()
        {
            if (progrssRing.IsActive == false)
            {
                List.Items.Clear();

                progrssRing.IsActive = true;
                RefreshRotate.Resume();

                HttpClient downloader = new HttpClient();
                downloader.DefaultRequestHeaders.IfModifiedSince = new DateTimeOffset(2000, 2, 2, 2, 1, 1, 3, TimeSpan.FromHours(5));
                var cacheControl = new System.Net.Http.Headers.CacheControlHeaderValue();
                cacheControl.NoCache = true;
                downloader.DefaultRequestHeaders.CacheControl = cacheControl;

                var rssContent = await downloader.GetStringAsync("http://www.repeatserver.com/Users/Kappspot/paradigm.xml");
                var rssData = from rss in XElement.Parse(rssContent).Descendants("item")
                              select new FeedItem
                                  {
                                      headLine = rss.Element("title").Value,
                                      description = rss.Element("description").Value,
                                      lastUpdate = rss.Element("pubDate").Value,
                                  };

                foreach (var i in rssData)
                {
                    List.Items.Add(AddFeed(i));
                }

                RefreshRotate.Pause();
                progrssRing.IsActive = false;
            }
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
            Task x = UpdateRss();
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void List_ItemClick(object sender, ItemClickEventArgs e)
        {
            string description = ((e.ClickedItem as StackPanel).Children[2] as TextBlock).Text;
            string title = "☕" + " " + ((e.ClickedItem as StackPanel).Children[0] as TextBlock).Text.ToUpper();

            new ExpandedItem(title, description).ShowAsync();
 
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Task x = UpdateRss();
        }

        private void RefreshRotate_Completed(object sender, object e)
        {
            RefreshRotate.Begin();
        }
    }
}