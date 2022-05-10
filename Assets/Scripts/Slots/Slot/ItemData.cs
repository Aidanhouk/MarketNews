using System.Collections;
using System.Collections.Generic;

static public class ItemData
{
    public enum ItemType
    {
        Butter,
        Corn,
        Mushrooms,
        Wheat,

        MAX_NUMBER,
    }

    class Item
    {
        public Item(string name, string image)
        { this.name = name; this.image = image; }

        public string name;
        public string image;
    }

    static List<Item> itemNames = new List<Item>
    {
        new Item("Масло", "Butter"),
        new Item("Кукуруза", "Corn"),
        new Item("Грибы", "Mushrooms"),
        new Item("Пшеница", "Wheat"),
    };

    static public string GetItemName(ItemType itemType)
    {
        return itemNames[(int)itemType].name;
    }

    static public string GetItemImage(ItemType itemType)
    {
        return itemNames[(int)itemType].image;
    }
}
