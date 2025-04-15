using System.Data.Common;
using System.Drawing;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Timer = System.Windows.Forms.Timer;

namespace ProjectGame
{
    public partial class GameForm : Form
    {   
        GameModel gameModel;

        static Player player = default;
        public GameForm()
        {
            gameModel = new();
            this.Size = new System.Drawing.Size(1280, 720);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            //this.KeyPress += OnKeyPress;
            this.KeyDown += OnKeyDown;
            this.KeyUp += OnKeyUp;

            var speedPlayer = 1;
            player = new Player(speedPlayer, new PositionPerson(0, 500));

            Paint += (sender, e) =>
            {
                MoveController(); //костыль
                e.Graphics.Clear(Color.White);
                e.Graphics.DrawImage(player.Picture, new Point(player.Position.X * this.Width / 1000, player.Position.Y * this.Height / 1000));
            };
            gameModel.Start(player);
        }

        private bool IsPressA = false;
        private bool IsPressD = false;

        public void MoveController()
        {
            if (IsPressA) MovePlayerLeft();
            if (IsPressD) MovePlayerRight();

            this.Invalidate();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    IsPressA = true;
                    break;
                case Keys.D:
                    IsPressD = true;
                    break;
                case Keys.Space:
                    GameForm.JumpPlayer();
                    break;
            }
            e.Handled = true;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    IsPressA = false;
                    break;
                case Keys.D:
                    IsPressD = false;
                    break;
                case Keys.Space:
                    GameForm.JumpPlayer();
                    break;
            }
            e.Handled = true;
        }

        public static void MovePlayerLeft()
        {
            player.Position.X -= player.speed.X;
        }

        public static void MovePlayerRight()
        {
            player.Position.X += player.speed.X;
        }

        public static void JumpPlayer()
        {
            //DO JUMP LOGIC 
        }
        public static void MainGame()
        {

            Application.Run(new GameForm());
        }
     
        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }

    public class GameModel : Form
    {
        public GameModel()
        {

        }

        public int Time { get; private set; } = 0;

        public void GameTimer(Player player)
        {
            var timer = new Timer();
            timer.Interval = 20;
            timer.Tick += (sender, e) =>
            {
                Time++;
            };
            timer.Start();
        }

        public void Start(Player player)
        {
            GameTimer(player);
        }
    }
}