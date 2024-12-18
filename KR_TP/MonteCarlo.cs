namespace KR_TP;

public class MonteCarlo
{
    public double Method_Monte_Carlo(MyFigure myFigure, int N)
    {
        int M = 0;
        Random rand = new Random();
        for (int i = 0; i < N; i++)
        {
            double X = myFigure.RectangleCommon.RightDownCorner.X - rand.NextDouble() * 
                (myFigure.RectangleCommon.RightDownCorner.X - myFigure.RectangleCommon.LeftUpCorner.X);
            
            double Y = myFigure.RectangleCommon.LeftUpCorner.Y + rand.NextDouble() *
                (myFigure.RectangleCommon.RightDownCorner.Y - myFigure.RectangleCommon.LeftUpCorner.Y);
            
            MyPoint p = new MyPoint(X,Y);

            
            if (!(myFigure.CheckCircleContains(p, myFigure.CircleLeftSide))
                && !(myFigure.CheckCircleContains(p, myFigure.CircleRightSide))
                && !(myFigure.CheckRectangleRightSideContains(p)))
            {
                M++;
            }
        }
        Console.WriteLine(M);
        return myFigure.RectangleCommon.Square * (double)M/N;
    }
}