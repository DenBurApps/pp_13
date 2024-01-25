using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchShower : MonoBehaviour
{
    [SerializeField] private GameObject _saleMenu;
    [SerializeField] private GameObject _searchMenu;

    public void HideSaleMenu()
    {
        _saleMenu.SetActive(false);
        _searchMenu.SetActive(true);
    }

    public void ShowSaleMenu()
    {
        _saleMenu.SetActive(true);
        _searchMenu.SetActive(false);
    }

}
