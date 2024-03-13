using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FavoriteButton : MonoBehaviour
{
    private int _itemCode;
    private int _size;
    private Image _image;
    private Color _unfavoriteColor  = Color.white;
    private Color _favoriteColor = Color.red;

    private void Awake()
    {
        _image = GetComponent<Image>();
        FavoritesController.FavoritesAdded += RefreshButton;
        FavoritesController.FavorivesRemoved += RefreshButton;
    }

    private void OnDestroy()
    {
        FavoritesController.FavoritesAdded -= RefreshButton;
        FavoritesController.FavorivesRemoved -= RefreshButton;
    }

    public void Init(int code, int size)
    {
        _itemCode = code;
        _size = size;
        RefreshButton();
    }

    public void RefreshButton()
    {
        var fav = SaveSystem.LoadData<FavoritesSaveData>();
        bool hasItem = false;
        for (int i = 0; i < fav.Items.Count; i++)
        {
            if (fav.Items[i] == _itemCode && fav.ItemsSize[i] == _size)
            {
                hasItem = true;
            }
        }
        if (hasItem)
        {
            _image.color = _favoriteColor;
        }
        else
        {
            _image.color = _unfavoriteColor;
        }
    }
}
