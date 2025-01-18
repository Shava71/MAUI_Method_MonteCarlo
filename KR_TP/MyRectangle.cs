namespace KR_TP;

public class MyRectangle
{
    public MyPoint LeftUpCorner;
    public MyPoint RightDownCorner;
    
    

    public MyRectangle(MyPoint leftUpCorner, MyPoint rightDownCorner)
    {
        LeftUpCorner = leftUpCorner;
        RightDownCorner = rightDownCorner;
    }

    public override string ToString()
    {
        return LeftUpCorner.ToString() + " | " + RightDownCorner.ToString();
    }

    public double Square => (double)((LeftUpCorner.Y - RightDownCorner.Y) * (RightDownCorner.X - LeftUpCorner.X));
}