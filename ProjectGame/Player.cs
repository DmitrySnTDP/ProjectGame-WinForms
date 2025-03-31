using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGame
{
    public class PositionPerson
    {
        public int X;
        public int Y;
        public PositionPerson(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public enum Direction
    {
        Left = -1,
        Right = 1,
    }

    public class Player
    {
        public readonly PictureBox Picture = new PictureBox();
        public Direction DirectionP;
        private int speed;
        public PositionPerson Position;
        public readonly double Acceleration = 0;
        public int Speed
        {
            get => speed;
            set => speed = (int)DirectionP * value;
        }
        public Player(Direction direction, int speed, PositionPerson position)
        {
            DirectionP = direction;
            this.speed = speed;
            this.Position = position;
            Picture.SizeMode = PictureBoxSizeMode.AutoSize;
            Picture.Image = Image.FromFile(@"Images\Player1.png");
            Picture.Location = new Point(Position.X, Position.Y);
        }

        public void UpdateLocation()
        {
            Picture.Location = new Point(Position.X,Position.Y);
        }
    }
}
