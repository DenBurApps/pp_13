using Assets.SimpleLocalization.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasketShower : MonoBehaviour
{
    [SerializeField] private BasketItem _clothesItem;
    [SerializeField] private CashoutShower _cashoutShower;
    [SerializeField] private Transform _container;
    [SerializeField] private ItemsContainer _itemsContainer;
    [SerializeField] private TMP_Text _totalPriseText;
    [SerializeField] private Button _checkoutButton;
    [SerializeField] private GameObject _filler;
    private GameObject _currentFiller;
    private List<BasketItem> _currentItems = new List<BasketItem>();

    private void Awake()
    {
        UpdateBasket();
        BasketController.BasketUpdated += UpdateBasket;
        
    }

    private void OnDestroy()
    {
        BasketController.BasketUpdated -= UpdateBasket;
    }

    private void ClearItems()
    {
        foreach (var item in _currentItems)
        {
            Destroy(item.gameObject);
        }
        _currentItems.Clear();
        Destroy(_currentFiller);
    }

    public void OnCheckoutClicked()
    {
        _cashoutShower.ShowCashout();
    }

    private void UpdateBasket()
    {
        ClearItems();
        int total = 0;
        var basket = SaveSystem.LoadData<BasketSaveData>();
        for (int i = 0; i < basket.ItemsCode.Count; i++)
        {
            BasketItem item = Instantiate(_clothesItem, _container);
            _currentItems.Add(item);
            ClothesSO clothes = _itemsContainer.GetClothesSO(basket.ItemsCode[i]);
            total += basket.ItemsCount[i] * clothes.Cost;
            item.Init(clothes, basket.ItemsSize[i], basket.ItemsCount[i]);
        }
        var local = SaveSystem.LoadData<LocalizationSaveData>();
        LocalizationManager.Language = local.Language;
        GameObject filler = Instantiate(_filler, _container);
        _currentFiller = filler;
        _totalPriseText.text = total + "$";
        if(total <= 0)
        {
            _checkoutButton.interactable = false;
        }
        else
        {
            _checkoutButton.interactable = true;
        }
    }
}
