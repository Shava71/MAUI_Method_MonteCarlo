using System.Collections.ObjectModel;

namespace KR_TP;

public class MainPageProcedureViewModel
{
    public ObservableCollection<TableRow> TableDataProcedure { get; set; }

    public MainPageProcedureViewModel()
    {
        TableDataProcedure = new ObservableCollection<TableRow>();

    }
    
    public void Add(TableRow row)
    {
        TableDataProcedure.Add(row);
    }
}