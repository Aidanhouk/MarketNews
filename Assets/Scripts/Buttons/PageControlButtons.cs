using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanielLochner.Assets.SimpleScrollSnap;

public class PageControlButtons : MonoBehaviour
{
    [SerializeField] SimpleScrollSnap slots;

    public void OnNextPage()
    {
        slots.GoToNextPanel();
    }

    public void OnPreviousPage()
    {
        slots.GoToPreviousPanel();
    }
}
