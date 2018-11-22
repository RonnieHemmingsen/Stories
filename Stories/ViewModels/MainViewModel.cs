using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MvvmHelpers;
using Stories.Models;
using Xamarin.Forms;

namespace Stories.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Story> Stories { get; }
        public Command GetStoriesCommand { get; }
        public MainViewModel()
        {
            Stories = new ObservableRangeCollection<Story>();
            Title = "Stories";
            GetStoriesCommand = new Command(async () => await GetStories());

        }

        async Task GetStories()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                var stories = await DataService.GetStories();
                Stories.Clear();
                Stories.AddRange(stories);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
