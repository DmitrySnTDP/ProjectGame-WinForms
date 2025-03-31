using System.Data.Common;
using Timer = System.Windows.Forms.Timer;

namespace ProjectGame
{
    public partial class GameForm : Form
    {
        GameModel game;
        public GameForm(GameModel game)
        {
            this.game = game;
            this.Size = new System.Drawing.Size(1280, 720);
            var player = new Player(Direction.Right, game.Speed, Tuple.Create(0, 0));
            Controls.Add(player.Picture);

            FormClosing += (sender, eventArgs) =>
            {
                var result = MessageBox.Show("Действительно закрыть?", "", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                    eventArgs.Cancel = true;
            };
            game.Start();
        }

        public static void MainGame()
        {
            var gameModel = new GameModel(5);
            Application.Run(new GameForm(gameModel));
        }
     
        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }

    public class GameModel
    {
        public readonly double Speed;
        public int Time { get; private set; } = 0;
        public GameModel(double speed)
        {
            Speed = speed;
        }
        
        public void GameTimer()
        {
            var timer = new Timer();
            timer.Interval = 20;
            timer.Tick += (sender, args) =>
            {
                Time++;
            };
            timer.Start();
        }

        public void Start()
        {

        }
    }
}