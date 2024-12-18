namespace KR_TP;

public class MyRectangle
{
    public Point LeftUpCorner;
    public Point RightDownCorner;
    
    

    public MyRectangle(Point leftUpCorner, Point rightDownCorner)
    {
        LeftUpCorner = leftUpCorner;
        RightDownCorner = rightDownCorner;
    }

    public override string ToString()
    {
        return LeftUpCorner.ToString() + " | " + RightDownCorner.ToString();
    }

    public double Square => (LeftUpCorner.Y - RightDownCorner.Y) * (RightDownCorner.X - LeftUpCorner.X);
}