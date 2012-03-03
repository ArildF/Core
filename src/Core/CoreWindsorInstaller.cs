using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Rogue.Core.UI.ViewModels;
using Rogue.Core.UI.Views;

namespace Rogue.Core.UI
{
	public class CoreWindsorInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<IShellWindow>().ImplementedBy<ShellView>());
			container.Register(Component.For<IShellViewModel>().ImplementedBy<ShellViewModel>());
			container.Register(Component.For<IMainScreen>().ImplementedBy<MainScreenViewModel>());

			container.Register(AllTypes.FromThisAssembly().InSameNamespaceAs<ShellViewModel>());
			container.Register(AllTypes.FromThisAssembly().BasedOn<IModule>());
			container.Register(AllTypes.FromThisAssembly().BasedOn<IStartable>());

		}
	}
}
