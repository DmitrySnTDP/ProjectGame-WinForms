using System.Data.Common;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ProjectGame
{
    public partial class GameForm : Form
    {
        //public static GameController Controller;
        public static void MainGame()
        {
            var controller = new GameController();
            Application.Run(controller.ModelG.ViewG);

        }

        private void GameForm_Load(object sender, EventArgs e) {}
    }

    public class GameController
    {
        public GameModel ModelG { get; }
        public int GameSpeed = 5;
        private bool IsPressA = false;
        private bool IsPressD = false;

        public GameController()
        {
            var player = new Player(GameSpeed, new PositionPerson(0, 500));
            var fone = new Fone(GameSpeed);
            ModelG = new GameModel(player, fone, this);

            InitializeTimer();
        }

        private void InitializeTimer()
        {
            ModelG.Start();
        }

        public void MoveController()
        {
            if (IsPressD)
            {
                if (ModelG.PlayerP.Position.X >= 800)
                    ModelG.FoneWorld.ScrollFone(Direction.Left);
                else
                    ModelG.PlayerP.MovePlayerRight();
            }
            if (IsPressA)
            {
                if (ModelG.PlayerP.Position.X <= 200 && ModelG.FoneWorld.FoneScrollCount > 0)
                    ModelG.FoneWorld.ScrollFone(Direction.Right);
                else if (ModelG.PlayerP.Position.X > 0)
                    ModelG.PlayerP.MovePlayerLeft();
            }
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
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
                    ModelG.PlayerP.JumpPlayer();
                    break;
            }
            e.Handled = true;
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    IsPressA = false;
                    break;
                case Keys.D:
                    IsPressD = false;
                    break;
            }
            e.Handled = true;
        }
    }

    public class GameModel : Form
    {
        public GameView ViewG { get; }
        public Player PlayerP { get; }
        public Fone FoneWorld { get; }
        public int Time { get; private set; } = 0;
        public readonly GameController controller;

        public GameModel(Player player, Fone foneWorld, GameController controller)
        {
            PlayerP = player;
            FoneWorld = foneWorld;
            this.controller = controller;
            ViewG = new GameView(this);
        }

        public void GameTimer()
        {
            var timer = new Timer();
            timer.Interval = 20;
            timer.Tick += (sender, e) =>
            {
                controller.MoveController();
                //this.Update();
                ViewG.Invalidate();
                Time++;
            };
            timer.Start();
        }

        public void Start()
        {
            GameTimer();
        }
    }

    public class GameView : Form
    {
        private readonly GameModel gameModel;
        private readonly Bitmap foneImg = new (@"Images\Fone1.png", true);
        private readonly Bitmap playerImg = new (@"Images\Player1.png", true);

        public GameView(GameModel gameModel)
        {
            this.gameModel = gameModel;
            InitializeView();
        }

        private void InitializeView()
        {
            this.Size = new System.Drawing.Size(1280, 720);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.KeyDown += gameModel.controller.OnKeyDown;
            this.KeyUp += gameModel.controller.OnKeyUp;
            Paint += (sender, e) => Painter(e.Graphics);
        }

        public void Painter (Graphics graphics)
        {
            var player = gameModel.PlayerP;
            graphics.Clear(Color.White);
            gameModel.FoneWorld.Draw(foneImg, graphics);
            graphics.DrawImage(playerImg,
                new Point(player.Position.X * this.Width / 1000,
                player.Position.Y * this.Height / 1000));
        }
    }
}