using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Assets.SimpleLocalization.Scripts;

public class ClothesShower : MonoBehaviour
{
    [SerializeField] private GameObject _clothesCanvas;
    [SerializeField] private ItemsContainer _itemsContainer;
    [SerializeField] private TMP_Text _filterText;
    [SerializeField] private ClothesItem _clothesItem;
    [SerializeField] private Transform _container;
    [SerializeField] private RectTransform _scroll;
    [SerializeField] private LocalizedTMPText _localizedTMPText;
    [SerializeField] private List<string> _localKeys;
    private List<ClothesItem> _currentItems = new List<ClothesItem>();

    public void HideCanvas()
    {
        _clothesCanvas.SetActive(false);
        _scroll.position = new Vector2(_scroll.position.x, 0);
    }

    private void ClearItems()
    {
        foreach (var item in _currentItems)
        {
            Destroy(item.gameObject);
        }
        _currentItems.Clear();
    }

    public void SetSaleClothesFilter()
    {
        ClearItems();
        _filterText.text = "Clothes";
        foreach (var item in _itemsContainer.AllCloths)
        {
            if (item.IsSale && item.Type == ClothesTypes.Types.Clothes)
            {
                ClothesItem clothes = Instantiate(_clothesItem, _container);
                clothes.Init(item);
                _currentItems.Add(clothes);
            }
        }
        _localizedTMPText.LocalizationKey = _localKeys[0];
        var local = SaveSystem.LoadData<LocalizationSaveData>();
        LocalizationManager.Language = local.Language;
        _clothesCanvas.SetActive(true);
    }

    public void SetSaleShoesFilter()
    {
        ClearItems();
        _filterText.text = "Shoes";
        foreach (var item in _itemsContainer.AllCloths)
        {
            if (item.IsSale && item.Type == ClothesTypes.Types.Shoes)
            {
                ClothesItem clothes = Instantiate(_clothesItem, _container);
                clothes.Init(item);
                _currentItems.Add(clothes);
            }
        }
        _localizedTMPText.LocalizationKey = _localKeys[2];
        var local = SaveSystem.LoadData<LocalizationSaveData>();
        LocalizationManager.Language = local.Language;
        _clothesCanvas.SetActive(true);
    }

    public void SetSaleAccessoriesFilter()
    {
        ClearItems();
        _filterText.text = "Shoes";
        foreach (var item in _itemsContainer.AllCloths)
        {
            if (item.IsSale && item.Type == ClothesTypes.Types.Accessories)
            {
                ClothesItem clothes = Instantiate(_clothesItem, _container);
                clothes.Init(item);
                _currentItems.Add(clothes);
            }
        }
        _localizedTMPText.LocalizationKey = _localKeys[3];
        var local = SaveSystem.LoadData<LocalizationSaveData>();
        LocalizationManager.Language = local.Language;
        _clothesCanvas.SetActive(true);
    }

    public void SetNoveltiesFilter()
    {
        ClearItems();
        _filterText.text = "Novelties";
        foreach (var item in _itemsContainer.AllCloths)
        {
            if (item.IsNew)
            {
                ClothesItem clothes = Instantiate(_clothesItem, _container);
                clothes.Init(item);
                _currentItems.Add(clothes);
            }
        }
        _localizedTMPText.LocalizationKey = _localKeys[1];
        var local = SaveSystem.LoadData<LocalizationSaveData>();
        LocalizationManager.Language = local.Language;
        _clothesCanvas.SetActive(true);
    }

    public void SetShoesFilter()
    {
        ClearItems();
        _filterText.text = "Shoes";
        foreach (var item in _itemsContainer.AllCloths)
        {
            if (item.Type == ClothesTypes.Types.Shoes)
            {
                ClothesItem clothes = Instantiate(_clothesItem, _container);
                clothes.Init(item);
                _currentItems.Add(clothes);
            }
        }
        _localizedTMPText.LocalizationKey = _localKeys[2];
        var local = SaveSystem.LoadData<LocalizationSaveData>();
        LocalizationManager.Language = local.Language;
        _clothesCanvas.SetActive(true);
    }

    public void SetClothesFilter()
    {
        ClearItems();
        _filterText.text = "Clothes";
        foreach (var item in _itemsContainer.AllCloths)
        {
            if (item.Type == ClothesTypes.Types.Clothes)
            {
                ClothesItem clothes = Instantiate(_clothesItem, _container);
                clothes.Init(item);
                _currentItems.Add(clothes);
            }
        }
        _localizedTMPText.LocalizationKey = _localKeys[0];
        var local = SaveSystem.LoadData<LocalizationSaveData>();
        LocalizationManager.Language = local.Language;
        _clothesCanvas.SetActive(true);
    }

    public void SetAccessoriesFilter()
    {
        ClearItems();
        _filterText.text = "Accessories";
        foreach (var item in _itemsContainer.AllCloths)
        {
            if (item.Type == ClothesTypes.Types.Accessories)
            {
                ClothesItem clothes = Instantiate(_clothesItem, _container);
                clothes.Init(item);
                _currentItems.Add(clothes);
            }
        }
        _localizedTMPText.LocalizationKey = _localKeys[3];
        var local = SaveSystem.LoadData<LocalizationSaveData>();
        LocalizationManager.Language = local.Language;
        _clothesCanvas.SetActive(true);
    }
}
