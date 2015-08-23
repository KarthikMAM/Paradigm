using Windows.Graphics.Display;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Paradigm
{
    public sealed partial class ExpandedItem : ContentDialog
    {
        public ExpandedItem(string title, string itemDetail)
        {
            this.InitializeComponent();

            Title = title;
            Body.Text = itemDetail;

            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.None;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.None;
        }
    }
}
