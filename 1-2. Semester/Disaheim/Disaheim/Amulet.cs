using System.Runtime.InteropServices.ComTypes;

namespace Disaheim;

public class Amulet : Merchandise
{
    public Level Quality;
    public string Design;
    
    public Amulet(string itemId) : this("",Level.medium, "")
    {
        ItemId = itemId;
    }
    public Amulet(string itemId, Level quality) : this("", quality, "")
    {
        ItemId = itemId;
        Quality = quality;
    }

    public Amulet(string itemId, Level quality, string design)
    {
        ItemId = itemId;
        Quality = quality;
        Design = design;
    }

    public override string ToString()
    {
        return $"ItemId: {ItemId}, Quality: {Quality}, Design: {Design}";
    }
}