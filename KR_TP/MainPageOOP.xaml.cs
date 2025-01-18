using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR_TP;

public partial class MainPageOOP : ContentPage
{
    public MainPageOOP()
    {
        InitializeComponent();
        BindingContext = new MainPageOOPViewModel();
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

            MyRectangle rectanglecommon = new MyRectangle(
                new MyPoint(bx, by),
                new MyPoint(dx, dy)
            );

            MyFigure myFigure = new MyFigure(rectanglecommon);
            RealSquareFigure.Text = myFigure.RealSquare.ToString();

            int Points = 1000;
            MonteCarlo mc = new MonteCarlo();
            // MainPageOOPViewModel DataGrid = new MainPageOOPViewModel();
            
            for (int i = 0; i < 5; i++)
            {
                var stopwatch = System.Diagnostics.Stopwatch.StartNew();
                double S_MC = mc.Method_Monte_Carlo(myFigure, Points);
                stopwatch.Stop();
                
                double error = Math.Abs((S_MC - myFigure.RealSquare) / myFigure.RealSquare) * 100;
                
                (BindingContext as MainPageOOPViewModel)?.Add(new TableRow
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

    private void ButtonClear_OnClicked(object? sender, EventArgs e)
    {
        b_x.Text = "";
        b_y.Text = "";
        d_x.Text = "";
        d_y.Text = "";

        RealSquareFigure.Text = "";
        
        (BindingContext as MainPageOOPViewModel)?.TableData.Clear();
    }
}