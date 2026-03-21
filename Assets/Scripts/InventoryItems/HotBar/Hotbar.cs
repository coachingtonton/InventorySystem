public class Hotbar
{
    public Item[] slots = new Item[7];
    public int selectedIndex = 0;

    public void AssignItem(Item item, int index)
    {
        slots[index] = item;
        EventManager.current.TriggerHotbarChanged();
    }

    public Item GetSelectedItem()
    {
        return slots[selectedIndex];
    }
}