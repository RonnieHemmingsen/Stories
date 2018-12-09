using System;
using System.Collections.Generic;
using Stories.Models;
using Stories.ViewModels;
using Xamarin.Forms;

namespace Stories.Views
{
    public partial class StoryView : ContentPage
    {
        public StoryView()
        {
            InitializeComponent();
        }

        public StoryView(Story story)
        {
            InitializeComponent();
            ((StoryViewModel)BindingContext).Story = story;
            ((StoryViewModel)BindingContext).Sequences = story.Pages[0].Sequences;
        }
    }
}
