

public struct Vector
{
    //properties
    public int X { get; set; }
    public int Y { get; set; }
    //Consturctor
    public Vector(Directon directon)
    {
        switch (directon)
        {
            case Directon.Left:
                X = -1;
                Y = 0;
                break;
            case Directon.Right:
                X = 1;
                Y = 0;
                break;
            case Directon.Up:
                X = 0;
                Y = -1;
                break;
            case Directon.Down:
                X = 0;
                Y = 1;
                break;
            default:
                X = 0;
                Y = 0;
                return;
        }
    }
    public Vector()
    {
        X = 0;
        Y = 0;
    }
    public Vector(int x, int y)
    {
        X = x;
        Y = y;

    }
    public void Add(Vector other)
    {
        X += other.X;
        Y += other.Y;
    }
    //Operator overloads
    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector(a.X + b.X, a.Y + b.Y);
    }
    public static Vector operator -(Vector a, Vector b)
    {
        return new Vector(a.X - b.X, a.Y - b.Y);
    }
    public static Vector operator -(Vector a)
    {
        return new Vector(-a.X, -a.Y);
    }
}

public enum Directon
{
    Left,
    Right,
    Up,
    Down
}