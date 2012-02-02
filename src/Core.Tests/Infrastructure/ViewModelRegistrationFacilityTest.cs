using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Core.Tests.Infrastructure.ViewModels;
using Core.Tests.Infrastructure.Views;
using NUnit.Framework;
using Rogue.Core.UI.Infrastructure;

namespace Core.Tests.Infrastructure
{
	[TestFixture]
	public class ViewModelRegistrationFacilityTest
	{
		[Test]
		[RequiresSTA]
		public void View_will_automatically_bind_to_corresponding_viewmodel()
		{
			var app = new Application();

			var container = new WindsorContainer();
			container.AddFacility(new ViewModelRegistrationFacility(Application.Current));

			container.Register(Component.For<SquareViewModel>().ImplementedBy<SquareViewModel>());

			var window = new Window();
			app.MainWindow = window;

			var contentPresenter = new ContentPresenter();
			window.Content = contentPresenter;
			var vm = new SquareViewModel();
			contentPresenter.Content = vm;

			window.Show();

			try
			{
				var child = VisualTreeHelper.GetChild(contentPresenter, 0);
				Assert.That(child, Is.InstanceOf<SquareView>());
				Assert.That(((Control) child).DataContext, Is.SameAs(vm));
			}
			finally
			{
				window.Close();
			}
		}
	}
}
