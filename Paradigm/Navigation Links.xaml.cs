using System;
using Windows.Graphics.Display;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Paradigm
{
    public sealed partial class Navigation_Links : ContentDialog
    {
        private string github;
        private string facebook;
        private string mail;
        private string call;
        private string name;

        public Navigation_Links(string github, string facebook, string mail, string call, string name)
        {
            this.InitializeComponent();

            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;

            this.github = github;
            this.facebook = facebook;
            this.mail = mail;
            this.call = call;
            this.name = name;

            this.Title = "☎ " + name.ToUpper();

            if (github == "null") 
            {
                github1.Width = github3.Width;
                github2.Width = github3.Width;
            }

            if (facebook == "null")
            {
                facebook1.Width = github3.Width;
                facebook2.Width = github3.Width;
            }

            if (mail == "null")
            {
                mail1.Width = github3.Width;
                mail2.Width = github3.Width;
            }
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.None;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.None;
        }
        

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch ((sender as ListView).Name)
            {
                case "Github":
                    Windows.System.Launcher.LaunchUriAsync(new Uri(github));
                    break;
                case "Facebook":
                    Windows.System.Launcher.LaunchUriAsync(new Uri(facebook));
                    break;
                case "Mail":
                    Windows.System.Launcher.LaunchUriAsync(new Uri(mail));
                    break;
                case "Call":
                    Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI(call, name);
                    break;
            }
        }
    }
}
