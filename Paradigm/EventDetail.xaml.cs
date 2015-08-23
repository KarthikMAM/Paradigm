using Paradigm.Common;
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Paradigm
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EventDetail : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public EventDetail()
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


        public static StackPanel BulletPoint(string contents, string bulletCode)
        {
            StackPanel member = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };

            TextBlock bullet = new TextBlock()
            {
                Text = bulletCode,
                Width = 40,
                FontSize = 30
            };

            TextBlock content = new TextBlock()
            {
                Width = 300,
                TextWrapping = Windows.UI.Xaml.TextWrapping.WrapWholeWords,
                Text = contents,
                FontSize = 20
            };

            member.Children.Add(bullet);
            member.Children.Add(content);

            var margin = member.Margin;
            margin.Bottom = 10;
            member.Margin = margin;

            return member;
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
            string name = e.Parameter as string;
            Details eventDetails = DataProvider.eventDetails[name];
            PivotHead.Title = name.ToUpper();

            About.Text = eventDetails.about;
            foreach(var i in eventDetails.team)
            {
                Teams.Items.Add(BulletPoint(i, "⛲"));
            }
            foreach (var i in eventDetails.rules)
            {
                Rules.Items.Add(BulletPoint(i, "⛨"));
            }
            foreach (var i in eventDetails.contacts)
            {
               Organizers.Items.Add(BulletPoint(i.name + "\n" + i.number, "☎"));
            }
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void Organizers_ItemClick(object sender, ItemClickEventArgs e)
        {
            TextBlock details = ((e.ClickedItem as StackPanel).Children.ElementAt(1) as TextBlock);
            new Navigation_Links("null", "null", "null", details.Text.Split('\n')[1], details.Text.Split('\n')[0]).ShowAsync();
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach(var i in (sender as ListView).Items)
            {
                TextBlock text = (i as StackPanel).Children[1] as TextBlock;
                text.Width = e.NewSize.Width - 40;
            }
        }

        private void Listview_ItemClick(object sender, ItemClickEventArgs e)
        {
            string itemContent = ((e.ClickedItem as StackPanel).Children[1] as TextBlock).Text;
            string bulletIcon = ((e.ClickedItem as StackPanel).Children[0] as TextBlock).Text;
            string eventName = bulletIcon + " " + PivotHead.Title.ToString().ToUpper();

            new ExpandedItem(eventName, itemContent).ShowAsync();
        }
    }
}
