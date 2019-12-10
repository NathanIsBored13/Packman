using System;
using System.Timers;
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

namespace Packman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public struct Vector
    {
        Vector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        int x;
        int y;
    }
    public enum Direction
    {
        up,
        down,
        left,
        right,
    }
    public partial class MainWindow : Window
    {
        const float board_scale = 0.1f;
        private Timer frame, tick;
        private bool game_state = false;
        private Player packman;
        private BitmapImage bitmap;
        public MainWindow()
        {
            InitializeComponent();
            frame = new Timer(10);
            frame.Elapsed += Frame_Elapsed;
            tick = new Timer(1000);
            tick.Elapsed += Tick_Elapsed;
            bitmap = new BitmapImage(new Uri(@"C:\Users\Nathan\source\repos\Packman\Packman\Resources\Game_Board.bmp"));
            GameArea.Width = bitmap.Width * board_scale;
            GameArea.Height = bitmap.Height * board_scale;
            packman = new Player();
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            DrawGameArea();
        }
        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            if (game_state) Stop_Game();
            else
            {
                Start_Game();
            }
        }
        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            Stop_Game();
            Reset_Game();
        }
        private void Settings_Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Tick_Elapsed(object sender, ElapsedEventArgs e)
        {

        }
        private void Frame_Elapsed(object sender, ElapsedEventArgs e)
        {
            DrawGameArea();
        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.Key);
            if (e.Key == Key.Escape) Close();
            if (new Key[] { Key.Up, Key.Down, Key.Left, Key.Right, Key.Space, Key.Tab, Key.Enter }.Contains(e.Key))
            {
                e.Handled = true;
            }
        }
        private void Start_Game()
        {
            game_state = true;
            frame.Start();
            tick.Start();
        }
        private void Stop_Game()
        {
            game_state = false;
            frame.Stop();
            tick.Stop();
        }
        private void Reset_Game()
        {

        }
        private void DrawGameArea()
        {
            GameArea.Children.Clear();
            Image image = new Image();
            image.Stretch = Stretch.Uniform;
            image.StretchDirection = StretchDirection.Both;
            image.Width = GameArea.Width;
            image.Height = GameArea.Height;
            image.Source = bitmap;
            GameArea.Children.Add(image);
        }
    }
}

