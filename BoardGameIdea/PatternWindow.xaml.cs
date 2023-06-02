using BoardGameIdea.Entities;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BoardGameIdea;

/// <summary>
/// Logique d'interaction pour PatternWindow.xaml
/// </summary>
public partial class PatternWindow : Window
{
    public PatternWindow(PatternBase[] patterns)
    {
        InitializeComponent();
        SetupPatterns(patterns);
    }

    public void SetupPatterns(PatternBase[] patterns)
    {
        Grid mainGrid = FindName("MainPatternGrid") as Grid;
        for(int i = 0; i < Math.Min(patterns.Length, 15); i++)
        {
            int column = i % 5;
            int row = i / 5;
            Grid grid = GenerateGridForPattern(patterns[i]);
            Border border = new Border();
            border.Child = grid;
            border.BorderBrush = new SolidColorBrush(Colors.Black);
            border.BorderThickness = new Thickness(1);
            mainGrid.Children.Add(border);
            Grid.SetColumn(border, column);
            Grid.SetRow(border, row);
        }
    }

    public Grid GenerateGridForPattern(PatternBase pattern)
    {
        Grid grid = new Grid();
        #region Setup grid definitions
        RowDefinition rowDef = new RowDefinition();
        rowDef.Height = new GridLength(Statics.PATTERN_CIRCLE_SIZE);
        grid.RowDefinitions.Add(rowDef);
        rowDef = new RowDefinition();
        rowDef.Height = new GridLength(Statics.PATTERN_CIRCLE_SIZE * Statics.PATTERN_SIZE);
        grid.RowDefinitions.Add(rowDef);
        ColumnDefinition colDef = new ColumnDefinition();
        colDef.Width = new GridLength(Statics.PATTERN_CIRCLE_SIZE * Statics.PATTERN_SIZE);
        grid.ColumnDefinitions.Add(colDef);
        grid.HorizontalAlignment = HorizontalAlignment.Center;
        #endregion
        #region Text
        TextBlock textblock = new TextBlock();
        textblock.Text = pattern.Score.ToString();
        textblock.HorizontalAlignment = HorizontalAlignment.Center;
        grid.Children.Add(textblock);
        Grid.SetRow(textblock, 0);
        Grid.SetColumn(textblock, 0);
        #endregion
        #region Circles grid
        Grid gridPattern = new Grid();
        gridPattern.HorizontalAlignment = HorizontalAlignment.Center;
        bool[,] trueValues = pattern.ToBoolArray();
        int height = trueValues.GetUpperBound(0);
        int width = trueValues.GetUpperBound(1);
        for(int i = 0; i < Statics.PATTERN_SIZE; i++)
        {
            rowDef = new RowDefinition();
            rowDef.Height = new GridLength(Statics.PATTERN_CIRCLE_SIZE);
            gridPattern.RowDefinitions.Add(rowDef);
            colDef = new ColumnDefinition();
            colDef.Width = new GridLength(Statics.PATTERN_CIRCLE_SIZE);
            gridPattern.ColumnDefinitions.Add(colDef);
            for (int j = 0; j < Statics.PATTERN_SIZE; j++)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Stroke = new SolidColorBrush(Colors.Ivory);
                if (i <= height && j <= width && trueValues[i, j])
                    ellipse.Fill = new SolidColorBrush(Colors.Black);
                else
                    ellipse.Fill = new SolidColorBrush(Colors.Transparent);
                gridPattern.Children.Add(ellipse);
                Grid.SetRow(ellipse, i);
                Grid.SetColumn(ellipse, j);
            }
        }

        grid.Children.Add(gridPattern);
        Grid.SetRow(gridPattern, 1);
        Grid.SetColumn(gridPattern, 0);
        #endregion
        return grid;
    }
}
