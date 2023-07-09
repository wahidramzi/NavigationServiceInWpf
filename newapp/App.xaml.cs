using Microsoft.Extensions.DependencyInjection;
using newapp.Core;
using newapp.MVVM.ViewModel;
using newapp.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace newapp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private ServiceProvider _ServiceProvider;

		public App()
		{
			IServiceCollection services = new ServiceCollection();
			services.AddSingleton<MainWindow>(Provider => new MainWindow
			{
				DataContext = Provider.GetRequiredService<MainViewModel>()
			});

			services.AddSingleton<MainViewModel>();
			services.AddSingleton<StandardLessonViewModel>();
			services.AddSingleton<ListeningLessonViewModel>();

			services.AddSingleton<INavigationService , NavigationService>();

			services.AddSingleton<Func<Type, ViewModel>>(ServiceProvider => viewModelType => (ViewModel)ServiceProvider.GetRequiredService(viewModelType));


			_ServiceProvider = services.BuildServiceProvider();



		}

		protected override void OnStartup(StartupEventArgs e)
		{
			var MainWindow = _ServiceProvider.GetService<MainWindow>();
			MainWindow.Show();
			base.OnStartup(e);
		}
	}
}
