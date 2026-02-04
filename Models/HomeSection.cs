using System.Collections.ObjectModel;

namespace _TmpMaui.Models;

public class HomeSection
{
    public string Title { get; set; } = string.Empty;
    public ObservableCollection<HomeItem> Items { get; set; } = new ObservableCollection<HomeItem>();
}
