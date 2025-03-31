using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGame
{
    public enum Direction
    {
        Left = -1,
        Right = 1,
    }
    public class Player
    {
        public readonly PictureBox Picture = new PictureBox();
        private Direction direction;
        private double speed;
        
        public readonly Tuple<int, int> Position = Tuple.Create(0,0);
        public readonly double Acceleration = 0;
        public double Speed
        {
            get => speed;
            set => speed = (int)direction * value;
        }
        public Direction DirectionP
        {
            get => direction;
            set => direction = value;
        }
        public Player(Direction direction, double speed, Tuple<int, int> position)
        {
            this.direction = direction;
            this.speed = speed;
            Position = position;
            var image = Image.FromFile(@"D:\my_informations\code_C#\ProjectGame\ProjectGame\images\player1.gif");
            Picture.SizeMode = PictureBoxSizeMode.AutoSize;
            Picture.Image = image;
            Picture.Location = new Point(Position.Item1, Position.Item2);
        }
    }
}
