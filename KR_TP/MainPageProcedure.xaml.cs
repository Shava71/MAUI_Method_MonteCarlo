using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR_TP;

public partial class MainPageProcedure : ContentPage
{
    public MainPageProcedure()
    {
        InitializeComponent();
        BindingContext = new MainPageProcedureViewModel();
        ExampleRadioButton.IsChecked = true;
        RadioButton_OnCheckedChanged(ExampleRadioButton, new CheckedChangedEventArgs(true));
    }

    private void RadioButton_OnCheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            if (sender == ExampleRadioButton)
            {
                b_x.Text = "0";
                b_y.Text = "6";
                d_x.Text = "10";
                d_y.Text = "0";
            }
            else if (sender == EnterYourselfRadioButton)
            {
                b_x.Text = "";
                b_y.Text = "";
                d_x.Text = "";
                d_y.Text = "";
            }
        }
    }

    private void ButtonClear_OnClicked(object? sender, EventArgs e)
    {
        b_x.Text = "";
        b_y.Text = "";
        d_x.Text = "";
        d_y.Text = "";

        RealSquareFigure.Text = "";
        
        (BindingContext as MainPageProcedureViewModel)?.TableDataProcedure.Clear();
    }

    private void ButtonEnter_OnClicked(object? sender, EventArgs e)
    {
        try
        {
            double bx = Convert.ToDouble(b_x.Text);
            double by = Convert.ToDouble(b_y.Text);
            double dx = Convert.ToDouble(d_x.Text);
            double dy = Convert.ToDouble(d_y.Text);
            
            if (bx > dx || dy > by)
            {
                DisplayAlert("Ошибка", "Введите корректные числовые значения для координат.", "OK");
            }
            
            double mainRectSquare = (by-dy)*(dx-dy);
            
            double xo_left = bx;
            double xo_right = dx;
            double radius = (by - dy) / 2;
            double yo = dy + radius;
            
            double CirclesSquare = Math.PI * radius * radius;
            
            double RightSideRectSquare = radius * radius;
            
            double RealSquareFigureValue = mainRectSquare - CirclesSquare/2 - CirclesSquare/2 -(RightSideRectSquare - CirclesSquare/4);
            
            RealSquareFigure.Text = RealSquareFigureValue.ToString();
            
            int Points = 1000;
            for (int i = 0; i < 5; i++)
            {
                var stopwatch = System.Diagnostics.Stopwatch.StartNew();
                
                double S_MC = 0;
                
                int M = 0;
                Random rand = new Random();
                for (int j = 0; j < Points; j++)
                {
                    double X = dx - rand.NextDouble() * (dx - bx);
            
                    double Y = by + rand.NextDouble() * (dy - by);

                    var left = Math.Pow((double)(X - xo_left), 2) + Math.Pow((double)(Y - yo), 2);
                    var right = Math.Pow((double)(X - xo_right), 2) + Math.Pow((double)(Y - yo), 2);
                    if (
                        !(left < Math.Pow(radius, 2))
                        && !(right < Math.Pow(radius, 2))
                        && !(Y < yo && Y > dy && X < dx && X > dx-radius)
                        )
                    {
                        M++;
                    }
                }
                Console.WriteLine(M);
                S_MC = mainRectSquare * (double)M/Points;
                
                stopwatch.Stop();
                
                double error = Math.Abs((S_MC - RealSquareFigureValue) / RealSquareFigureValue) * 100;
                
                (BindingContext as MainPageProcedureViewModel)?.Add(new TableRow
                {
                    Index = i + 1,
                    N = Points,
                    Area = S_MC,
                    Error = error,
                    Time = (int)stopwatch.ElapsedMilliseconds
                });
                
                Points *= 10;
            }
        }
        catch (FormatException)
        {
            DisplayAlert("Ошибка", "Введите корректные числовые значения для координат.", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("Ошибка", $"Произошла ошибка: {ex.Message}", "OK");
        }
    }
}