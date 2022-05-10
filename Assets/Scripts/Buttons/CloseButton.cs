using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    public void OnButtonClose()
    {
        //Application.Quit();
        canvas.enabled = false;
    }
}
