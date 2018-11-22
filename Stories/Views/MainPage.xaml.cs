using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stories.Models;
using Stories.ViewModels;
using Xamarin.Forms;

namespace Stories.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var vm = BindingContext as MainViewModel;
            vm.GetStoriesCommand.Execute(null);
            base.OnAppearing();

        }

        async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is Story story)) {
                return;
            }

            await Navigation.PushAsync(new StoryView(story));
            ((ListView)sender).SelectedItem = null;
        }
    }
}

