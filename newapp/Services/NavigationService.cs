using newapp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newapp.Services
{
	public interface INavigationService
	{
		ViewModel CurrentView { get; }

		void NavigateTo<T>() where T : ViewModel;
	}
	public class NavigationService : ObservaableObject , INavigationService
	{
		private readonly Func<Type, ViewModel> _viewModelFactory;

		private  ViewModel _CurrentView;
		public ViewModel CurrentView
		{
			get => _CurrentView;
			private set
			{
				_CurrentView = value;
				OnPropertyChanged();
			}
		}

		

		public NavigationService(Func<Type, ViewModel> viewModelFactory)
		{
			_viewModelFactory = viewModelFactory;
		}

		public void NavigateTo<TViewModel>() where TViewModel : ViewModel
		{
			ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
			CurrentView = viewModel;
		}


	}
}
