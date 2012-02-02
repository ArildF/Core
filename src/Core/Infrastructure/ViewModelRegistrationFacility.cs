using System;
using System.Windows;
using Castle.MicroKernel;
using Castle.MicroKernel.Facilities;

namespace Rogue.Core.UI.Infrastructure
{
	public class ViewModelRegistrationFacility : AbstractFacility
	{
		private readonly ResourceDictionary _resources;

		public ViewModelRegistrationFacility(ResourceDictionary resources)
		{
			_resources = resources;
		}

		public ViewModelRegistrationFacility(Application application) : this(application.Resources)
		{
		}

		protected override void Init()
		{
			Kernel.ComponentRegistered += KernelOnComponentRegistered;
		}

		private void KernelOnComponentRegistered(string key, IHandler handler)
		{
			Type implementation = handler.ComponentModel.Implementation;
			if (implementation.Namespace == null || 
				!implementation.Namespace.EndsWith("ViewModels"))
			{
				return;
			}

			var viewTypeName = implementation.Namespace.Replace("ViewModels", "Views") + "." +
			                    implementation.Name.Replace("ViewModel", "View");

			var qualifiedViewTypeName = implementation.AssemblyQualifiedName.Replace(implementation.FullName, viewTypeName);

			Type viewType = Type.GetType(qualifiedViewTypeName, false);
			if (viewType == null)
			{
				throw new InvalidOperationException();
			}

			var dt = new DataTemplate {DataType = viewType};

			var viewFactory = new FrameworkElementFactory(viewType);
			dt.VisualTree = viewFactory;


			_resources.Add(new DataTemplateKey(implementation), dt);
		}
	}
}
