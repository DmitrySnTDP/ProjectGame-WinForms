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
            var player = new Player(Direction.Right, 5, new PositionPerson(0, this.Height - 300));
            Controls.Add(player.Picture);

            FormClosing += (sender, eventArgs) =>
            {
                var result = MessageBox.Show("Действительно закрыть?", "", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                    eventArgs.Cancel = true;
            };
            Paint += (sender, args) =>
            {
                player.Picture.Update();
            };
            game.Start(player);
        }

        public static void MainGame()
        {
            var gameModel = new GameModel();
            Application.Run(new GameForm(gameModel));
        }
     
        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }

    public class GameModel : Form
    {
        public int Time { get; private set; } = 0;
        public GameModel()
        {
            
        }
        
        public void GameTimer(Player player)
        {
            var timer = new Timer();
            timer.Interval = 20;
            timer.Tick += (sender, args) =>
            {
                Time++;
                player.Position.X += player.Speed;
                player.UpdateLocation();
                //Invalidate();
            };
            timer.Start();
        }

        public void Start(Player player)
        {
            GameTimer(player);
        }
    }
}