using Paradigm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Paradigm
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Paradigm : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public class ContactData
        {
            public string name;
            public string number;
            public string position;
            public BitmapImage photo;
        }

        public static StackPanel BulletPoint(string contents)
        {
            StackPanel member = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };

            TextBlock bullet = new TextBlock()
            {
                Text = "⛨",
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

            var margin = member.Margin;
            margin.Bottom = 10;
            member.Margin = margin;

            member.Children.Add(bullet);
            member.Children.Add(content);

            return member;
        }

        public static StackPanel TeamMember(string name, string number, string position, string photoName)
        {
            StackPanel member = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };

            Image photo = new Image()
            {
                Width = 85,
                Height = 85,
                Stretch = Stretch.Fill,
                Source = new BitmapImage(new Uri(@"ms-appx:///Assets/People/" + photoName))
            };

            member.Children.Add(photo);

            StackPanel details = new StackPanel();

            var margin = details.Margin;
            margin.Left = 5;
            member.Margin = details.Margin = margin;

            TextBlock memberName = new TextBlock()
            {
                Text = name,
                FontSize = 25
            };

            TextBlock memberNumber = new TextBlock()
            {
                Text = number,
                FontSize = 25
            };

            TextBlock memberPosition = new TextBlock()
            {
                Text = position,
                FontSize = 25
            };

            details.Children.Add(memberName);
            details.Children.Add(memberPosition);
            details.Children.Add(memberNumber);

            member.Children.Add(details);

            return member;
        }

        public Paradigm()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;


            List<ContactData> contact = new List<ContactData>();
            Committee.Items.Add(TeamMember("Devesh Rastogi", "9962463212", "President", "Devesh Rastogi.jpg"));
            Committee.Items.Add(TeamMember("Siddaarth S", "9677043422", "VicePresident", "Siddarth S.jpg"));
            Committee.Items.Add(TeamMember("Shivani K", "9940697803", "Secretary", "Shivani K.jpg"));
            Committee.Items.Add(TeamMember("Aswin Kumar R", "9962020163", "Joint Secretary", "Aswin Kumar R.jpg"));
            Committee.Items.Add(TeamMember("Vishal Ramaswamy", "9445616866", "Treasurer", "Vishal Ramaswamy.jpg"));
            Committee.Items.Add(TeamMember("Arvind M", "9444443001", "Joint Treasurer", "Arvind M.jpg"));
            Committee.Items.Add(TeamMember("Bharath Kumar S", "9788987749", "Event Coordinator", "Bharath Kumar S.jpg"));
            Committee.Items.Add(TeamMember("Ruban B", "9094831059", "Event Coordinator", "Ruban B.jpg"));

            About.Text = "The Association of Computer Engineers was started in order to provide a platform to all the budding software professionals to showcase their talents. The motto of ACE is \"Education is not just academics\". In order to achieve this goal many events are organized in the Department of Computer Science and Engineering under the banner of ACE. " +
                         "\n\nParadigm is an annual national technical symposium organized by the Department of Computer Science and Engineering. It is conducted by the students and the Association of Computer Science and Engineering(ACE) every year. As a jewel in the crown, Paradigm attracts several thousand students from hundreds of colleges and universities across India. ";

            Details.Items.Add(BulletPoint("All the participants are requested to register with us before hand."));
            Details.Items.Add(BulletPoint("This year the event takes place on September 1."));
            Details.Items.Add(BulletPoint("The participants are requested not to litter within the campus grounds."));
            Details.Items.Add(BulletPoint("All the decisions made by the judges/organizers are final and binding on the participants."));
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

        private void Committee_ItemClick(object sender, ItemClickEventArgs e)
        {
            StackPanel details = ((e.ClickedItem as StackPanel).Children.ElementAt(1) as StackPanel);

            string github = "null";
            string facebook = "null";
            string mail = "null";
            string call = (details.Children.ElementAt(2) as TextBlock).Text;
            string name = (details.Children.ElementAt(0) as TextBlock).Text;

            switch(name)
            {
                case "Devesh Rastogi":
                    facebook = "https://www.facebook.com/devesh1234";
                    mail = "mailto:deveshrastogi3@gmail.com";
                    break;
                case "Siddaarth S":
                    facebook = "https://www.facebook.com/siddhaarth.sudhakarannellayil";
                    mail = "mailto:siddhaarthnellayil@gmail.com";
                    break;
                case "Shivani K":
                    facebook = "https://www.facebook.com/shivani.kandavelu";
                    mail = "mailto:shivanikandavelu@gmail.com";
                    break;
                case "Aswin Kumar R":
                    facebook = "https://www.facebook.com/ashishere123";
                    mail = "mailto:snake.eyes_100@yahoo.com";
                    break;
                case "Vishal Ramaswamy":
                    facebook = "https://www.facebook.com/vishal.ramaswamy.9";
                    mail = "mailto:cvvishal@gmail.com";
                    break;
                case "Arvind M":
                    facebook = "https://www.facebook.com/arvind.muthuraman";
                    mail = "mailto:arv457@gmail.com";
                    break;
                case "Bharath Kumar S":
                    facebook = "https://www.facebook.com/bharathsiva007";
                    mail = "mailto:bharathkumar1147@gmail.com";
                    break;
                case "Ruban B":
                    facebook = "https://www.facebook.com/ru.ban.908";
                    mail = "mailto:bharathkumar1147@gmail.com";
                    break;
            }
            new Navigation_Links(github, facebook, mail, call, name).ShowAsync();
        }

        private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (var i in (sender as ListView).Items)
            {
                TextBlock text = (i as StackPanel).Children[1] as TextBlock;
                text.Width = e.NewSize.Width - 40;
            }
        }

        private void Details_ItemClick(object sender, ItemClickEventArgs e)
        {
            string itemContent = ((e.ClickedItem as StackPanel).Children[1] as TextBlock).Text;
            string bulletIcon = ((e.ClickedItem as StackPanel).Children[0] as TextBlock).Text;
            string eventName = bulletIcon + " " + "PARADIGM";

            new ExpandedItem(eventName, itemContent).ShowAsync();
        }
    }
}
