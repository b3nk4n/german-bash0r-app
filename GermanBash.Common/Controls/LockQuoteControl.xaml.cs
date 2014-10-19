using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using GermanBash.Common.Models;
using GermanBash.Common.Conversion;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Data;

namespace GermanBash.Common.Controls
{
    public partial class LockQuoteControl : UserControl
    {
        private IndexToThicknessConverter _indexToThicknessConverter;
        
        private static readonly SolidColorBrush WHITE = new SolidColorBrush(Colors.White);
        private static readonly SolidColorBrush GRAY = new SolidColorBrush(Colors.Gray);
        private static readonly SolidColorBrush DARK_GRAY = new SolidColorBrush(Colors.DarkGray);
        private static readonly SolidColorBrush BLACK = new SolidColorBrush(Colors.Black);

        private const double FONT_SIZE = 26;


        public LockQuoteControl(BashData bashData)
        {
            InitializeComponent();
            _indexToThicknessConverter = new IndexToThicknessConverter();

            // generate UI
            CreateBashQuotes(bashData.QuoteItems);
        }

        private void CreateBashQuotes(List<BashQuoteItem> bashQuoteItems)
        {
            foreach (var bashQuoteItem in bashQuoteItems)
            {
                Panel quoteControl;

                if (bashQuoteItem.PersonIndex < 0)
                {
                    quoteControl = CreateServerQuote(bashQuoteItem);
                }
                else
                {
                    quoteControl = CreateUserQuote(bashQuoteItem);
                }

                QuoteItems.Items.Add(quoteControl);
            }
        }

        private Panel CreateServerQuote(BashQuoteItem bashQuoteItem)
        {
            Panel container = new Grid();

            Border innerBorder = new Border();
            innerBorder.Margin = new Thickness(10, 6, 10, 6);
            innerBorder.Width = 724;
            innerBorder.Background = DARK_GRAY;
            container.Children.Add(innerBorder);

            StackPanel innerStackPanel = new StackPanel();
            innerStackPanel.Margin = new Thickness(6);
            innerBorder.Child = innerStackPanel;
            
            TextBlock text = new TextBlock();
            text.TextWrapping = TextWrapping.Wrap;
            text.TextAlignment = TextAlignment.Center;
            text.Foreground = BLACK;
            text.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            text.Text = bashQuoteItem.Text;
            text.FontSize = FONT_SIZE;
            innerStackPanel.Children.Add(text);

            return container;
        }

        private Panel CreateUserQuote(BashQuoteItem bashQuoteItem)
        {
            Panel container = new Grid();

            Border border = new Border();
            border.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            border.Margin = (Thickness)_indexToThicknessConverter.Convert(bashQuoteItem.PersonIndex, typeof(Thickness), null, null);
            container.Children.Add(border);

            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            border.Child = stackPanel;

            if (bashQuoteItem.PersonIndex % 2 == 0)
            {
                Path pathLeft = GeneratePath(bashQuoteItem.PersonIndex, "M 0,20 20,0, 20,20 Z", new Thickness(12, 0, -8, 12));
                stackPanel.Children.Add(pathLeft);
            }

            Border innerBorder = new Border();
            innerBorder.Margin = new Thickness(6);
            innerBorder.Width = 640;
            innerBorder.Background = WHITE;
            stackPanel.Children.Add(innerBorder);

            StackPanel innerStackPanel = new StackPanel();
            innerStackPanel.Margin = new Thickness(0, 6, 0, 6);
            innerBorder.Child = innerStackPanel;
            
            TextBlock text = new TextBlock();
            text.TextWrapping = TextWrapping.Wrap;
            text.Margin = new Thickness(12, 0, 12, 0);
            text.Foreground = BLACK;
            text.Text = bashQuoteItem.Text;
            text.FontSize = FONT_SIZE;
            innerStackPanel.Children.Add(text);

            TextBlock nick = new TextBlock();
            nick.TextTrimming = TextTrimming.WordEllipsis;
            nick.Margin = new Thickness(12, -6, 12, 0);
            nick.Foreground = GRAY;
            nick.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            nick.Text = bashQuoteItem.Nick;
            nick.FontSize = FONT_SIZE;
            innerStackPanel.Children.Add(nick);

            if (bashQuoteItem.PersonIndex % 2 == 1)
            {
                Path pathLeft = GeneratePath(bashQuoteItem.PersonIndex, "M 20,20 0,0, 0,20 Z", new Thickness(-8, 0, 12, 12));
                stackPanel.Children.Add(pathLeft);
            }

            return container;
        }

        private Path GeneratePath(int bashIndexPosition, string pathData, Thickness margin)
        {
            Path pathLeft = new Path();
            pathLeft.Margin = margin;
            pathLeft.Width = 20;
            pathLeft.Height = 20;
            pathLeft.Fill = WHITE;
            pathLeft.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            var b = new Binding
            {
                Source = pathData
            };
            BindingOperations.SetBinding(pathLeft, Path.DataProperty, b);
            return pathLeft;
        }
    }
}
