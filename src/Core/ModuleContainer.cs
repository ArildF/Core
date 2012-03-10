using System.Collections.Generic;
using System.ComponentModel.Composition;
using Castle.Windsor;

namespace Rogue.Core.UI
{
	[Export(typeof(IModuleContainer))]
	public class ModuleContainer : IModuleContainer
	{
		[Import(typeof(IWindsorContainer))]
		public IWindsorContainer Container
		{
			get;
			set;
		}

		public IEnumerable<IModule> GetModules()
		{
			yield return Container.Resolve<WeightModule>();
			yield return Container.Resolve<ExerciseModule>();
			yield return Container.Resolve<DietModule>();
		}
	}
}
