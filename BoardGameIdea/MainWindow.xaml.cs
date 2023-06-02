using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using static BoardGameIdea.Entities.HelperConst;

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
    }

    public void SetupMainGame()
    {
        Grid grid = FindName("MainGame") as Grid;
        int heightBoard = Statics.Game.GetBoard().GetUpperBound(0) + 1;
        double cellSize = Statics.GRID_HEIGHT / heightBoard;
        grid.Height = Statics.GRID_HEIGHT;
        for (int i = 0; i < Statics.GRID_WIDTH; i++)
        {
            RowDefinition rowDef = new RowDefinition();
            rowDef.Height = new GridLength(1, GridUnitType.Star);
            ColumnDefinition rowCol = new ColumnDefinition();
            rowCol.Width = new GridLength(1, GridUnitType.Star);
            grid.RowDefinitions.Add(rowDef);
            grid.ColumnDefinitions.Add(rowCol);
        }
        for (int i = 0; i < heightBoard; i++)
        {
            for (int j = 0; j < heightBoard; j++)
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
    public void SetupPatterns()
    {
        for (int i = 0; i < Statics.PATTERNS.Length; i++)
        {
            bool[,] currentPattern = Statics.PATTERNS[i].ToBoolArray();
            int height = currentPattern.GetUpperBound(0);
            int width = currentPattern.GetUpperBound(1);
            for (int j = 0; j <= height; j++)
            {
                for (int k = 0; k <= width; k++)
                {
                    if (currentPattern[j, k])
                    {
                        int curNumber = j * Statics.PATTERN_SIZE + k;
                        Ellipse ellipse = FindName($"p{i}{curNumber}") as Ellipse;

                        ellipse.Fill = new SolidColorBrush(Colors.Black);

                        TextBlock text = FindName($"s{i}") as TextBlock;

                        text.Text = Statics.PATTERNS[i].Score.ToString();

                    }
                }
            }
        }
    }
    public void RefreshGame()
    {
        TileType[,] board = Statics.Game.GetBoard();
        int height = board.GetUpperBound(0) + 1;
        int width = board.GetUpperBound(1) + 1;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                int curCell = i * height + j;
                string cellName = $"Cell{curCell}";
                Ellipse ellipse = FindName(cellName) as Ellipse;

                ellipse.Fill = board[i, j].GetBrushFromPlayer();

            }
        }
        TextBox text = FindName($"ScoreGame") as TextBox;

        text.Text = $"White : {Statics.Game.WhiteScore} / Black : {Statics.Game.BlackScore}";

    }

    private void CellClick(object sender, RoutedEventArgs e)
    {
        if (!Statics.Game.IsGameOver())
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

    private void ShowPatterns(object sender, RoutedEventArgs e)
    {
        PatternWindow window = new PatternWindow(Statics.PATTERNS);
        window.Show();
    }
}
