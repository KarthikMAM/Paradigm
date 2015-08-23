using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Paradigm
{
    public class MainPageViewModel
    {
        public ObservableCollection<Object> Datas
        {
            get; set; }

        public MainPageViewModel()
        {
            var datas = new ObservableCollection<Object>();
            datas.Add(new Data { BitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/Slides/Pic01.jpg", UriKind.Absolute)), Title = "01" });
            datas.Add(new Data { BitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/Slides/Pic02.jpg", UriKind.Absolute)), Title = "02" });
            datas.Add(new Data { BitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/Slides/Pic03.jpg", UriKind.Absolute)), Title = "03" });
            datas.Add(new Data { BitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/Slides/Pic04.jpg", UriKind.Absolute)), Title = "04" });
            datas.Add(new Data { BitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/Slides/Pic05.jpg", UriKind.Absolute)), Title = "05" });
            datas.Add(new Data { BitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/Slides/Pic06.jpg", UriKind.Absolute)), Title = "06" });
            datas.Add(new Data { BitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/Slides/Pic07.jpg", UriKind.Absolute)), Title = "07" });
            datas.Add(new Data { BitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/Slides/Pic08.jpg", UriKind.Absolute)), Title = "08" });
            datas.Add(new Data { BitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/Slides/Pic10.jpg", UriKind.Absolute)), Title = "10" });
            datas.Add(new Data { BitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/Slides/Pic12.jpg", UriKind.Absolute)), Title = "12" });
            datas.Add(new Data { BitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/Slides/Pic13.jpg", UriKind.Absolute)), Title = "13" });
            datas.Add(new Data { BitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/Slides/Pic14.jpg", UriKind.Absolute)), Title = "14" });
            datas.Add(new Data { BitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/Slides/Pic15.jpg", UriKind.Absolute)), Title = "15" });
            datas.Add(new Data { BitmapImage = new BitmapImage(new Uri("ms-appx:///Assets/Slides/Pic16.jpg", UriKind.Absolute)), Title = "16" });

            this.Datas = datas;
        }
    }
    public class Data
    {
        public BitmapImage BitmapImage { get; set; }
        public String Title { get; set; }
    }
}
