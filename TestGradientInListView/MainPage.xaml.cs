using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestGradientInListView
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


            var myList = new ObservableCollection<string> { "", "", "", "", "" };
            MyListView1.ItemsSource = myList;
            MyListView2.ItemsSource = myList;
        }
    }
}
