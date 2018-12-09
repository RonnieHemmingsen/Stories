using System;
using System.Collections.Generic;
using System.Diagnostics;
using Stories.Models;

namespace Stories.ViewModels
{
    public class StoryViewModel : BaseViewModel
    {
        public StoryViewModel()
        {
        }

        public StoryViewModel(Story story) : this()
        {
        }

        private Story _story;
        public Story Story
        {
            get => _story;
            set
            {
                if (_story == value)
                {
                    return;
                }

                _story = value;
                Title = $"{Story.Title}";
                OnPropertyChanged();
            }
        }

        private List<Sequence> _sequences;
        public List<Sequence> Sequences
        {
            get => _sequences;
            set {
                if(_sequences == value){
                    return;
                }

                _sequences = value;
                OnPropertyChanged();
            }
        }

    }
}
