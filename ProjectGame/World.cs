using ProjectGame;
using System;

public enum Direction{
    Left = -1,
    Right = 1
}

public class Fone
{
    private Point position1 = new(0, 0);
    private Point position2 = new(1280, 0);
    private readonly int gameSpeed;
    public int FoneScrollCount { get; private set; } = 1;

    public Fone(int gameSpeed)
	{
        this.gameSpeed = gameSpeed;
    }

    public void Draw(Bitmap img, Graphics graphics)
    {
        graphics.DrawImage(img, position1);
        graphics.DrawImage(img, position2);
    }

    public void ScrollFone(Direction direction)
    {
        position1 = new Point(position1.X + gameSpeed * (int)direction, 0);
        position2 = new Point(position2.X + gameSpeed * (int)direction, 0);
        if (position1.X <= 0 - 1280)
        {
            position1 = new Point(position1.X + 1280, 0);
            position2 = new Point(position2.X + 1280, 0);
            FoneScrollCount++;
        }
        else if (position1.X >= 0)
        {
            position1 = new Point(position1.X - 1280, 0);
            position2 = new Point(position2.X - 1280, 0);
            FoneScrollCount--;
        }
    }
}
