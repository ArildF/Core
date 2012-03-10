using System;
using System.Collections.Generic;
using ReactiveUI;
using ReactiveUI.Xaml;
using Rogue.Core.UI.Infrastructure;

namespace Rogue.Core.UI.ViewModels
{
	public class ShellViewModel : ReactiveObject, IShellViewModel
	{
		private object _mainContent;

		private readonly Stack<object> _navigationStack = new Stack<object>();

		public ShellViewModel(IMainScreen mainScreen, IMessageBus bus)
		{
			_navigationStack.Push(mainScreen);

			bus.Listen<NavigateMainModuleMessage>().SubscribeUI(msg => NavigateTo(msg.Module.MainViewModel));

			NavigateBackCommand = new ReactiveCommand();
			NavigateBackCommand.SubscribeUI(NavigateBack);

		}

		private void NavigateBack(object o)
		{
			if (_navigationStack.Count > 1)
			{
				_navigationStack.Pop();
				RaiseNavigationProperties();
			}
		}

		public ReactiveCommand NavigateBackCommand { get; private set; }

		private void NavigateTo(object viewModel)
		{
			_navigationStack.Push(viewModel);
			RaiseNavigationProperties();
		}

		private void RaiseNavigationProperties()
		{
			this.RaisePropertyChanged(vm => vm.MainContent);
			this.RaisePropertyChanged(vm => vm.CanNavigateBack);
		}

		public bool CanNavigateBack
		{
			get { return _navigationStack.Count > 1; }
		}

		public object MainContent
		{
			get { return _navigationStack.Peek(); }
		}
	}

}
