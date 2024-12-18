namespace KR_TP;

public class MyCircle : MyPoint
{
    public double Radius { get; set; }

    public MyCircle(double x, double y, double radius) : base(x, y)
    {
        X = x;
        Y = y;
        Radius = radius;
    }
    
    public double Square => Math.PI * Radius * Radius;

    public override string ToString()
    {
        return X + "; " + Y + "; " + Radius;
    }
}