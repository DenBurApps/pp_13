using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdShower : MonoBehaviour
{
    [SerializeField] private GameObject _adCanvas;
    [SerializeField] private GameObject _navogatorCanvas;
    
    public void ShowAd()
    {
        _adCanvas.SetActive(true);
        _navogatorCanvas.SetActive(false);
    }

    public void HideAd()
    {
        _adCanvas.SetActive(false);
        _navogatorCanvas.SetActive(true);
    }
}
