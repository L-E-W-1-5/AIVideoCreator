using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using AIVideoCreator.WPF.Models;

namespace AIVideoCreator.WPF.ViewModels
{


    public partial class MainViewModel : ObservableObject
    {


        [ObservableProperty]    
        private string _welcomeMessage = "Welcome to your AI Video Creator";

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(GenerateVideoCommand))]
        private string _videoTitle = string.Empty;

        partial void OnVideoTitleChanged(string value)
        {
            WelcomeMessage = string.IsNullOrWhiteSpace(value)
                ? "Welcome to AI Video Creator"
                : $"Creating a video about: {value}";
        }

        public ObservableCollection<Project> Projects { get; set; } =
        [
            new Project { Name = "Project 1"},
            new Project { Name = "Project 2"},
            new Project { Name = "Project 3"}
        ];

        public RelayCommand DashboardCommand { get; }

        public RelayCommand AddProjectCommand { get; }

        public RelayCommand RemoveProjectCommand { get; }

        public RelayCommand GenerateVideoCommand { get; }

        private int _counter = 1;

        public MainViewModel()
        {
            DashboardCommand = new RelayCommand(() =>
            {
                WelcomeMessage = "Dashboard Clicked!";
            });

            AddProjectCommand = new RelayCommand(AddProject, CanAddProject);

            RemoveProjectCommand = new RelayCommand(RemoveProject, CanRemoveProject);

            GenerateVideoCommand = new RelayCommand(GenerateVideo, CanGenerateVideo);
        }


        private void GenerateVideo()
        {
            WelcomeMessage = $"Generating video: {VideoTitle}";
        }

        private bool CanGenerateVideo()
        {
            return !string.IsNullOrWhiteSpace(VideoTitle);
        }

        private void RemoveProject()
        {
            Projects.RemoveAt(Projects.Count - 1);

            _counter--;

            AddProjectCommand.NotifyCanExecuteChanged();

            RemoveProjectCommand.NotifyCanExecuteChanged();
        }

        private bool CanRemoveProject()
        {
            return Projects.Count > 0;
        }

        private void AddProject()
        {
            Projects.Add(new Project { Name = $"New Project {_counter}" });

            _counter++;

            AddProjectCommand.NotifyCanExecuteChanged();
        }

        private bool CanAddProject()
        {
            return Projects.Count < 7;
        }
    
    }
}
