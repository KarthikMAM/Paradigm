using System;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Paradigm
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //https://docs.google.com/forms/d/1FZ1lWqaOh1KI0rFCv6Irix4yMsj8EslnXQicaz-Y_Bg/viewform?usp=send_form
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += timer_Tick;
            timer.Start();

            FlipAnimation.Begin();

            Paradigm.Height 
                = Window.Current.Bounds.Width;
            Events.Height
                = Map.Height
                = Links.Height
                = Feeds.Height
                = Register.Height 
                = Window.Current.Bounds.Width / 3;
            Gallery.Height 
                = (Window.Current.Bounds.Width / 3) * 2 + 2;

            BackgroundScrollGrid.Height
                = (Window.Current.Bounds.Width / 3) * 5.5;
        }

        Random randomizer = new Random();
        void timer_Tick(object sender, object e)
        {
            int inc = randomizer.Next(0, 100) / 50 == 0 ? -1 : 1;
            if (inc + MainCarousel.SelectedIndex == MainCarousel.Items.Count || inc + MainCarousel.SelectedIndex < 0) { inc *= -1; }
            MainCarousel.SelectedIndex = (inc + MainCarousel.SelectedIndex);
        }

        private void FlipAnimation_Completed(object sender, object e)
        {
            if ((sender as Storyboard).Equals(FlipAnimation))
            {
                Object selectedImage = GalleryCarousel.SelectedItem;
                GalleryCarousel.Items.RemoveAt(0);
                GalleryCarousel.Items.Add(selectedImage);

                FlipAnimationReverse.Begin();
            }
            else
            {
                FlipAnimation.Begin();
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.None;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch((sender as ListView).Name)
            {
                case "Paradigm":
                    Frame.Navigate(typeof(Paradigm));
                    break;
                case "Register":
                    //new Register().ShowAsync();
                    Frame.Navigate(typeof(Registration));
                    break;
                case "Events":
                    Frame.Navigate(typeof(EventList));
                    break;
                case "Feeds":
                    Frame.Navigate(typeof(Feeds));
                    break;
                case "Links":
                    Frame.Navigate(typeof(Follow));
                    break;
                case "Map":
                    Frame.Navigate(typeof(Map));
                    break;
                case "Gallery":
                    Frame.Navigate(typeof(Gallery));
                    break;
            }
        }

        private void MainScroller_ViewChanging(object sender, ScrollViewerViewChangingEventArgs e)
        {
            BackgroundScroll.ChangeView(0, (MainScroller.VerticalOffset / MainScroller.ScrollableHeight) * BackgroundScroll.ScrollableHeight, 1);
        }
    }
}