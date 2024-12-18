using System.Collections.ObjectModel;

namespace KR_TP;

public class TableRow
{
    public int Index { get; set; }
    public int N { get; set; }
    public double Area { get; set; }
    public double Error { get; set; }
    public int Time { get; set; }
}

public class MainPageOOPViewModel
{
    public ObservableCollection<TableRow> TableData { get; set; }

    public MainPageOOPViewModel()
    {
        TableData = new ObservableCollection<TableRow>
        {
            
        };
    }

    public void Add(TableRow row)
    {
        TableData.Add(row);
    }
}