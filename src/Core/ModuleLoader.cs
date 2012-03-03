using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reactive.Concurrency;
using System.Reflection;
using Castle.Core;
using System.Linq;
using Castle.Windsor;
using ReactiveUI;
using System.Reactive.Linq;

namespace Rogue.Core.UI
{
	public class ModuleLoader : IStartable
	{
		private readonly IMessageBus _bus;
		private readonly IWindsorContainer _windsorContainer;
		private CompositionContainer _container;

		public ModuleLoader(IMessageBus bus, IWindsorContainer windsorContainer)
		{
			_bus = bus;
			_windsorContainer = windsorContainer;

			_bus.Listen<ApplicationLoadedMessage>().ObserveOn(Scheduler.ThreadPool).Subscribe(OnApplicationLoaded);
		}

		[Export(typeof(IWindsorContainer))]
		public IWindsorContainer WindsorContainer
		{
			get { return _windsorContainer; }
		}

		private void OnApplicationLoaded(ApplicationLoadedMessage msg)
		{

			var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
			_container = new CompositionContainer(catalog);
			_container.ComposeParts(this);

			var moduleContainers = _container.GetExports<IModuleContainer>();

			foreach (var module in moduleContainers.SelectMany(mc => mc.Value.GetModules()))
			{
				_bus.SendMessage(new ModuleLoadedMessage(module));
			}
		}

		public void Start()
		{
			
		}

		public void Stop()
		{
			_container.Dispose();
		}
	}

}
