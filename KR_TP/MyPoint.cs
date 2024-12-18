namespace KR_TP;

public class MyPoint
{
    public double? X { get; set; }
    public double? Y { get; set; }

    public MyPoint(double x, double y)
    {
        X = x;
        Y = y;
    }

    public MyPoint()
    {
        X = null; Y = null;
    }

    public override string ToString()
    {
        return X.ToString() + "; " + Y.ToString();
    }
}