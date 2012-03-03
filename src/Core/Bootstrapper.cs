using System.Windows;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using ReactiveUI;
using Rogue.Core.UI.Infrastructure;
using Rogue.Core.UI.ViewModels;
using Rogue.Core.UI.Views;

namespace Rogue.Core.UI
{
	class Bootstrapper
	{
		private readonly IWindsorContainer _container;

		public Bootstrapper()
		{
			_container = new WindsorContainer();
		}

		public IShellWindow BootStrap()
		{
			_container.AddFacility(new ViewModelRegistrationFacility(Application.Current));
			_container.AddFacility<StartableFacility>();

			_container.Register(Component.For<IWindsorContainer>().Instance(_container));

			_container.Register(Component.For<IMessageBus>().ImplementedBy<MessageBus>());
			_container.Install(FromAssembly.This());

			return _container.Resolve<IShellWindow>();

		}
	}

}
