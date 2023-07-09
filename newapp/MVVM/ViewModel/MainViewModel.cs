using newapp.Core;
using newapp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newapp.MVVM.ViewModel
{
	internal class MainViewModel : Core.ViewModel
	{
		private INavigationService _navigation;

		public INavigationService Navigation
		{
			get => _navigation;
			set
			{
				_navigation = value;
				OnPropertyChanged();
			}
		}
		public RelayCommand NavigationStandardCommand { get; set; }

		public RelayCommand NavigationListeningCommand { get; set; }

		public MainViewModel(INavigationService navservice)
		{
			Navigation = navservice;
			NavigationStandardCommand = new RelayCommand(o => { Navigation.NavigateTo<StandardLessonViewModel>(); }, o => true);
			NavigationListeningCommand = new RelayCommand(o => { Navigation.NavigateTo<ListeningLessonViewModel>(); }, o => true);

		}
	}
}
