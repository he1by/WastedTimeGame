using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public Canvas MainCanvas;
    public Canvas OptionsCanvas;

    public void Awake()
    {
        OptionsCanvas.enabled = false;
    }

    public void OptionsOn()
    {
        MainCanvas.enabled = false;
        OptionsCanvas.enabled = true;
    }
    public void ReturnOn()
    {
        OptionsCanvas.enabled = false;
        MainCanvas.enabled = true;
    }
    public void LoadOn()
    {
        Application.LoadLevel("lvl1");
    }
}
