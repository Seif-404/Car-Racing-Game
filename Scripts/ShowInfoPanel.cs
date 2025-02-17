using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfoPanel : MonoBehaviour
{
    public GameObject infoPanel; 

    public void ShowPanel()
    {
        infoPanel.SetActive(true);
    }

    public void HidePanel()
    {
        infoPanel.SetActive(false);
    }
}
