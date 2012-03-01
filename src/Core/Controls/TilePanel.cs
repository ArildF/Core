using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Rogue.Core.UI.Infrastructure;

namespace Rogue.Core.UI.Controls
{
	public class TilePanel : Panel
	{
		protected override System.Windows.Size MeasureOverride(System.Windows.Size availableSize)
		{
			double desiredWidth = 0;
			double desiredHeight = 0;

			var dims = CalculateGridDimensions(InternalChildren.Count);

			foreach (var childGroup in InternalChildren.Cast<UIElement>().InGroupsOf(dims.X))
			{
				double measuredWidth = 0;
				double measuredHeight = 0;
				foreach (UIElement child in childGroup)
				{
					child.Measure(availableSize);
					measuredWidth += child.DesiredSize.Width;
					measuredHeight = Math.Max(child.DesiredSize.Height, measuredHeight);
				}

				desiredWidth = Math.Max(measuredWidth, desiredWidth);
				desiredHeight += measuredHeight;
			}

			return new Size(desiredWidth, desiredHeight);
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			double x = 0;
			double y = 0;

			var gridSize = CalculateGridDimensions(InternalChildren.Count);

			double widthPerElement = finalSize.Width/gridSize.X;
			double heightPerElement = finalSize.Height/gridSize.Y;

			foreach (var childRow in InternalChildren.Cast<UIElement>().InGroupsOf(gridSize.X))
			{
				foreach (var child in childRow)
				{
					child.Arrange(new Rect(x, y, widthPerElement, heightPerElement));
					x += widthPerElement;
				}

				x = 0;
				y += heightPerElement;

			}
			return finalSize; 
		}

		private GridDimensions CalculateGridDimensions(int count)
		{
			double sqrt = Math.Sqrt(count);
			int rounded = (int)Math.Round(sqrt, MidpointRounding.AwayFromZero);

			if (rounded >= sqrt)
			{
				return new GridDimensions(rounded, rounded);
			}
			return new GridDimensions(rounded + 1, rounded);
		}


		private struct GridDimensions
		{
			public readonly int X;
			public readonly int Y;

			public GridDimensions(int x, int y) : this()
			{
				Y = y;
				X = x;
			}
		}
	}
}
