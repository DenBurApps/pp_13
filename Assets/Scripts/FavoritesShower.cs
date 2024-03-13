using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavoritesShower : MonoBehaviour
{
    [SerializeField] private FavoriteItem _clothesItem;
    [SerializeField] private Transform _container;
    [SerializeField] private ItemsContainer _itemsContainer;
    [SerializeField] private GameObject _emptyAllert;
    private List<FavoriteItem> _currentItems = new List<FavoriteItem>();

    private void Awake()
    {
        UpdateFavorites();
        FavoritesController.FavoritesAdded += UpdateFavorites;
        FavoritesController.FavorivesRemoved += UpdateFavorites;
    }

    private void OnDestroy()
    {
        FavoritesController.FavoritesAdded -= UpdateFavorites;
        FavoritesController.FavorivesRemoved -= UpdateFavorites;
    }

    private void ClearItems()
    {
        foreach (var item in _currentItems)
        {
            Destroy(item.gameObject);
        }
        _currentItems.Clear();
    }

    private void UpdateFavorites()
    {
        ClearItems();
        var fav = SaveSystem.LoadData<FavoritesSaveData>();
        for (int i = 0; i < fav.Items.Count; i++)
        {
            FavoriteItem item = Instantiate(_clothesItem, _container);
            _currentItems.Add(item);
            ClothesSO clothes = _itemsContainer.GetClothesSO(fav.Items[i]);
            item.Init(clothes, fav.ItemsSize[i]);
        }
        if (fav.Items.Count <= 0)
        {
            _emptyAllert.SetActive(true);
        }
        else
        {
            _emptyAllert.SetActive(false);
        }
    }
}
