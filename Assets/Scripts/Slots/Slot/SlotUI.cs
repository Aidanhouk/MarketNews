using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SlotUI : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemCount;
    [SerializeField] TextMeshProUGUI itemPrice;
    [SerializeField] RawImage playerAvatar;
    [SerializeField] TextMeshProUGUI playerName;
    [SerializeField] TextMeshProUGUI playerLevel;

    public void SetData(SlotData slotData)
    {
        string itemImageFilepath = ItemData.GetItemImage(slotData.itemType);
        itemImage.overrideSprite = Resources.Load<Sprite>($"Sprites/Items/{itemImageFilepath}");
        itemName.SetText(ItemData.GetItemName(slotData.itemType));

        itemCount.SetText(slotData.itemsCount.ToString());
        itemPrice.SetText(slotData.price.ToString());

        playerName.SetText(slotData.playerName);
        playerLevel.SetText(slotData.playerLevel.ToString());

        StartCoroutine(DownloadImage(slotData.playerAvatar));
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            playerAvatar.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }
}
