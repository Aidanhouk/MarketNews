using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Slots
{
    public List<SlotData> slotsData = new List<SlotData>();

    public void Generate(int slotsNumber)
    {
        for (int i = 0; i < slotsNumber; i++)
        {
            slotsData.Add(CreateRandomSlot());
        }
    }

    private SlotData CreateRandomSlot()
    {
        SlotData slotData = new SlotData();

        int randItemType = Random.Range(0, (int)ItemData.ItemType.MAX_NUMBER);
        slotData.itemType = (ItemData.ItemType)randItemType;
        slotData.itemsCount = Random.Range(1, 10);
        slotData.price = Random.Range(1, 100);
        slotData.playerName = GetRandName();
        slotData.playerAvatar = GetRandImageUrl();
        slotData.playerLevel = Random.Range(1, 100);

        return slotData;
    }

    private string GetRandName()
    {
        string res = "";
        int symbolsCount = Random.Range(4, 10);

        bool vowel = Random.Range(0, 2) == 0;
        res += GetRandSymbol(vowel);
        for (int i = 0; i < symbolsCount; i++)
        {
            vowel = !vowel;
            res += GetRandSymbol(vowel).ToString().ToLower();
        }

        res += '_' + Random.Range(10, 100).ToString();

        return res;
    }

    private char GetRandSymbol(bool vowel)
    {
        const string vowels = "AEIOUY";
        const string consonants = "BCDFGHJKLMNPQRSTVWXZ";

        return vowel ? vowels[Random.Range(0, vowels.Length)] : consonants[Random.Range(0, consonants.Length)];
    }

    private string GetRandImageUrl()
    {
        string[] urls =
        {
            "https://avatanplus.com/files/resources/mid/5ca4bcf6d96fc169e382246b.png",
            "https://i.pinimg.com/236x/ec/ec/37/ecec3794c3c80dc031d5524631abe8eb.jpg",
            "https://st.renderu.com/artwork/177142",
            "https://avavatar.ru/images/original/4/HgFFn8aV7Hg7m6to.jpg",
            "https://static.wikia.nocookie.net/warcraft-iii/images/9/93/%D0%9E%D1%80%D0%BA.jpg/revision/latest/scale-to-width-down/400?cb=20160802131700&path-prefix=ru",
            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS98auu-iocYoXJ0X6g534A0en4GAZQA4KvzQ&usqp=CAU",
            "https://www.streamscheme.com/wp-content/uploads/2020/04/smorc.png",
            "https://media.2x2tv.ru/content/images/size/h1080/2021/05/-----5.jpg",
        };

        return urls[Random.Range(0, urls.Length)];
    }

    public void WriteToFile(string filepath)
    {
        string slotDataStr = JsonUtility.ToJson(this, true);
        File.WriteAllText(filepath, slotDataStr);
    }

    static public Slots ReadFromFile(string filepath)
    {
        if (!File.Exists(filepath))
        {
            Debug.Log("Can't load. Save file doesn't exist in " + filepath);
            return null;
        }

        string savingDataStr = File.ReadAllText(filepath);
        return JsonUtility.FromJson<Slots>(savingDataStr);
    }
}
