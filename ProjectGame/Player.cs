using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

    public class Speed
    {
        public int X;
        public int Y;

        public Speed(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Player
    {
        public Speed speed = new(0, 0);
        public PositionPerson Position;

        public Player(int speedX, PositionPerson position)
        {
            speed.X = speedX;
            Position = position;
        }


        public void MovePlayerLeft()
        {
            Position.X -= speed.X;
        }

        public void MovePlayerRight()
        {
            Position.X += speed.X;
        }

        public void JumpPlayer()
        {
            //DO JUMP LOGIC 
        }
    }
}
