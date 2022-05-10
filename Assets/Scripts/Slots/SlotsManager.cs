using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManager : MonoBehaviour
{
    [SerializeField]
    public GameObject slotsPagePrefab;
    float slotsPageWidth;
    int slotsCountOnPage;

    string filepath;

    Slots slots = new Slots();

    // Start is called before the first frame update
    void Start()
    {
        slotsPageWidth = slotsPagePrefab.GetComponent<RectTransform>().sizeDelta.x;
        slotsCountOnPage = slotsPagePrefab.transform.childCount;

        filepath = Application.persistentDataPath + "/ItemsData.json";

        GenerateSlots();

        slots = Slots.ReadFromFile(filepath);

        CreateSlotPages();
    }

    void GenerateSlots()
    {
        int slotsNumber = 100;
        slots.Generate(slotsNumber);
        slots.WriteToFile(filepath);
    }

    void CreateSlotPages()
    {
        float positionOffset = 0.0f;
        for (int i = 0; i < slots.slotsData.Count; i += slotsCountOnPage)
        {
            var slotsPage = Instantiate(slotsPagePrefab, this.transform);
            slotsPage.transform.localPosition = new Vector3(positionOffset, 0.0f);
            positionOffset += slotsPageWidth;
        
            for (int j = 0; j < slotsCountOnPage; j++)
            {
                int slotIndex = i + j;
                var slot = slotsPage.transform.GetChild(j).gameObject;
                if (slotIndex < slots.slotsData.Count)
                {
                    slot.GetComponent<SlotUI>().SetData(slots.slotsData[slotIndex]);
                }
                else
                {
                    slot.SetActive(false);
                }
            }
        }
    }
}
