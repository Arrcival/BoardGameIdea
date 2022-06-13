using BoardGameIdea.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static BoardGameIdea.Entities.Helper;

namespace BoardGameIdea;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Statics.InitializeGame();
        SetupMainGame();
        SetupPatterns();
    }

    public void SetupMainGame()
    {
        Grid? grid = FindName("MainGame") as Grid;
        if(grid != null)
        {
            int heightBoard = Statics.Game.Board.GetUpperBound(0) + 1;
            double cellSize = Statics.GRID_HEIGHT / heightBoard;
            grid.Height = Statics.GRID_HEIGHT;
            for (int i = 0; i < Statics.GRID_WIDTH; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = new GridLength(cellSize);
                ColumnDefinition rowCol = new ColumnDefinition();
                rowCol.Width = new GridLength(cellSize);
                grid.RowDefinitions.Add(rowDef);
                grid.ColumnDefinitions.Add(rowCol);
            }
            for(int i = 0; i < heightBoard; i++)
            {
                for(int j = 0; j < heightBoard; j++)
                {
                    Ellipse ellipse = new Ellipse();
                    ellipse.Fill = new SolidColorBrush(Colors.Transparent);
                    ellipse.Stroke = new SolidColorBrush(Colors.Ivory);
                    string ellipseName = $"Cell{i * Statics.GRID_WIDTH + j}";
                    ellipse.Name = ellipseName;
                    RegisterName(ellipseName, ellipse);
                    ellipse.MouseUp += CellClick;
                    Grid.SetRow(ellipse, i);
                    Grid.SetColumn(ellipse, j);
                    grid.Children.Add(ellipse);
                }
            }
        }
    }
    public void SetupPatterns()
    {
        for(int i = 0; i < Statics.PATTERNS.Length; i++)
        {
            Pattern currentPattern = Statics.PATTERNS[i];
            int height = currentPattern.PatternShape.GetUpperBound(0);
            int width = currentPattern.PatternShape.GetUpperBound(1);
            for(int j = 0; j <= height; j++)
            {
                for(int k = 0; k <= width; k++)
                {
                    if (currentPattern.PatternShape[j, k])
                    {
                        int curNumber = j * Statics.PATTERN_WIDTH + k;
                        Ellipse? ellipse = FindName($"p{i}{curNumber}") as Ellipse;
                        if(ellipse != null)
                        {
                            ellipse.Fill = new SolidColorBrush(Colors.Black);
                        }
                        TextBlock? text = FindName($"s{i}") as TextBlock;
                        if (text != null)
                        {
                            text.Text = currentPattern.Score.ToString();
                        }
                    }
                }
            }
        }
    }
    public void RefreshGame()
    {
        TileType[,] board = Statics.Game.Board;
        int height = board.GetUpperBound(0) + 1;
        int width = board.GetUpperBound(1) + 1;
        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                int curCell = i * height + j;
                string cellName = $"Cell{curCell}";
                Ellipse? ellipse = FindName(cellName) as Ellipse;
                if(ellipse != null)
                {
                    ellipse.Fill = board[i, j].GetBrushFromPlayer();
                }
            }
        }
        TextBox? text = FindName($"ScoreGame") as TextBox;
        if (text != null)
        {
            text.Text = $"White : {Statics.Game.WhiteScore} / Black : {Statics.Game.BlackScore}";
        }
    }

    private void CellClick(object sender, RoutedEventArgs e)
    {
        if(!Statics.Game.IsGameOver())
        {
            Ellipse ellipse = (Ellipse)sender;
            int curCell = int.Parse(ellipse.Name.Split("Cell")[1]);
            int x = (int)curCell / Statics.GRID_WIDTH;
            int y = curCell % Statics.GRID_WIDTH;
            Statics.Game.Play(x, y);
            RefreshGame();
        }        
    }

    private void Reset(object sender, RoutedEventArgs e)
    {
        Statics.InitializeGame();
        RefreshGame();
    }
}
