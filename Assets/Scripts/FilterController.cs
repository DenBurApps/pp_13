using Assets.SimpleLocalization.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FilterController : MonoBehaviour
{
    [SerializeField] private ItemsContainer _itemsContainer;
    [SerializeField] private LocalizedTMPText _localizedTMPText;
    [SerializeField] private TMP_Text _filterText;
    [SerializeField] private ClothesItem _clothesItem;
    [SerializeField] private Transform _container;
    [SerializeField] private GameObject _filterPanel;
    [SerializeField] private List<string> _localizeKeys;
    private List<ClothesItem> _currentItems = new List<ClothesItem>();

    private void Awake()
    {
        SetSaleFilter();
    }

    public void OnFilterButtonClick()
    {
        _filterPanel.SetActive(true);
    }

    public void OnFilterCloseButtonClick()
    {
        _filterPanel.SetActive(false);
    }

    private void ClearItems()
    {
        foreach (var item in _currentItems)
        {
            Destroy(item.gameObject);
        }
        _currentItems.Clear();
    }

    public void SetSaleFilter()
    {
        ClearItems();
        _localizedTMPText.LocalizationKey = _localizeKeys[0];
        var local = SaveSystem.LoadData<LocalizationSaveData>();
        LocalizationManager.Language = local.Language;
        foreach (var item in _itemsContainer.AllCloths)
        {
            if (item.IsSale)
            {
                ClothesItem clothes = Instantiate(_clothesItem, _container);
                clothes.Init(item);
                _currentItems.Add(clothes);
            }
        }
        OnFilterCloseButtonClick();
    }

    public void SetNoveltiesFilter()
    {
        ClearItems();
        _localizedTMPText.LocalizationKey = _localizeKeys[1];
        var local = SaveSystem.LoadData<LocalizationSaveData>();
        LocalizationManager.Language = local.Language;
        foreach (var item in _itemsContainer.AllCloths)
        {
            if (item.IsNew)
            {
                ClothesItem clothes = Instantiate(_clothesItem, _container);
                clothes.Init(item);
                _currentItems.Add(clothes);
            }
        }
        OnFilterCloseButtonClick();
    }

    public void SetShoesFilter()
    {
        ClearItems();
        _localizedTMPText.LocalizationKey = _localizeKeys[2];
        var local = SaveSystem.LoadData<LocalizationSaveData>();
        LocalizationManager.Language = local.Language;
        foreach (var item in _itemsContainer.AllCloths)
        {
            if (item.Type == ClothesTypes.Types.Shoes)
            {
                ClothesItem clothes = Instantiate(_clothesItem, _container);
                clothes.Init(item);
                _currentItems.Add(clothes);
            }
        }
        OnFilterCloseButtonClick();
    }

    public void SetClothesFilter()
    {
        ClearItems();
        _localizedTMPText.LocalizationKey = _localizeKeys[3];
        var local = SaveSystem.LoadData<LocalizationSaveData>();
        LocalizationManager.Language = local.Language;
        foreach (var item in _itemsContainer.AllCloths)
        {
            if (item.Type == ClothesTypes.Types.Clothes)
            {
                ClothesItem clothes = Instantiate(_clothesItem, _container);
                clothes.Init(item);
                _currentItems.Add(clothes);
            }
        }
        OnFilterCloseButtonClick();
    }

    public void SetAccessoriesFilter()
    {
        ClearItems();
        _localizedTMPText.LocalizationKey = _localizeKeys[4];
        var local = SaveSystem.LoadData<LocalizationSaveData>();
        LocalizationManager.Language = local.Language;
        foreach (var item in _itemsContainer.AllCloths)
        {
            if (item.Type == ClothesTypes.Types.Accessories)
            {
                ClothesItem clothes = Instantiate(_clothesItem, _container);
                clothes.Init(item);
                _currentItems.Add(clothes);
            }
        }
        OnFilterCloseButtonClick();
    }
}
