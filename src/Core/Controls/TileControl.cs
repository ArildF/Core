using System.Windows;
using System.Windows.Controls;

namespace Rogue.Core.UI.Controls
{
	public class TileControl : ItemsControl
	{
		static TileControl()
		{
			var itemsPanelTemplate = new ItemsPanelTemplate(new FrameworkElementFactory(typeof(TilePanel)));
			itemsPanelTemplate.Seal();

			ItemsControl.ItemsPanelProperty.OverrideMetadata(typeof(TileControl), new FrameworkPropertyMetadata(itemsPanelTemplate));

			DefaultStyleKeyProperty.OverrideMetadata(typeof(TileControl), new FrameworkPropertyMetadata(typeof(ItemsControl)));
		}

		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return item is TileItem;
		}

		protected override DependencyObject GetContainerForItemOverride()
		{
			return new TileItem();
		}

	}
}
