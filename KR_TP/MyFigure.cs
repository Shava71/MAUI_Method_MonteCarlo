namespace KR_TP;

public class MyFigure
{
    public MyCircle CircleLeftSide;
    public MyCircle CircleRightSide;
    public MyRectangle RectangleCommon;
    public MyRectangle RectangleRightSide;

    public MyFigure(MyRectangle rectangleCommon)
    {
        RectangleCommon = rectangleCommon;

        double xo_left = (double)RectangleCommon.LeftUpCorner.X;
        double xo_right = (double)RectangleCommon.RightDownCorner.X;
        double radius = (double)((RectangleCommon.LeftUpCorner.Y - RectangleCommon.RightDownCorner.Y) / 2);
        double yo = (double)(RectangleCommon.RightDownCorner.Y + radius);
        // MyPoint o1 = new MyPoint(xo_left, yo);
        // MyPoint o2 = new MyPoint(xo_right, yo);

        CircleLeftSide = new MyCircle(xo_left, yo, radius); 
        CircleRightSide = new MyCircle(xo_right, yo, radius);

        RectangleRightSide = new MyRectangle(new MyPoint((double)(RectangleCommon.RightDownCorner.X-radius),yo), RectangleCommon.RightDownCorner);
    }
    
    // public double RealSquare => RectangleCommon.Square - CircleLeftSide.Square/2 - CircleRightSide.Square/2 - (RectangleRightSide.Square - CircleLeftSide.Square/4);

    public double RealSquare => RectangleCommon.Square - CircleLeftSide.Square/2 - CircleRightSide.Square/2 - (RectangleRightSide.Square - CircleLeftSide.Square/4);
    
    
    //(x-x0)^2 + (y-y0)^2 < R^2 - не принадлежит фигуре
    public bool CheckCircleContains(MyPoint p, MyCircle circle)
    {
        double leftSide = Math.Pow((double)(p.X - circle.X)!, 2) + Math.Pow((double)(p.Y - circle.Y)!, 2);
        // if (leftSide < Math.Pow(circle.Radius,2))
        // {
        //     return true;
        // }
        // else
        // {
        //     return false;
        // }
        return leftSide < Math.Pow(circle.Radius, 2);
    }

    public bool CheckRectangleRightSideContains(MyPoint p)
    {
        // if (p.Y < RectangleRightSide.LeftUpCorner.Y && p.X < RectangleRightSide.RightDownCorner.X)
        // {
        //     return true;
        // }
        // else
        // {
        //     return false;
        // }
        return p.Y < RectangleRightSide.LeftUpCorner.Y && 
               p.Y > RectangleRightSide.RightDownCorner.Y && 
               p.X < RectangleRightSide.RightDownCorner.X &&
               p.X > RectangleRightSide.LeftUpCorner.X;
    }
}