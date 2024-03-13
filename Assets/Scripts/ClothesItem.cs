using Assets.SimpleLocalization.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClothesItem : MonoBehaviour
{
    private ClothesSO _clothesInfo;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _priseText;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _showInfoButton;
    [SerializeField] private Button _favoriteButton;
    [SerializeField] private GameObject _isSale;
    [SerializeField] private LocalizedTMPText _nameLocalized;
    [SerializeField] private FavoriteButton _favoriteBtn;

    public void Init(ClothesSO clothesSO)
    {
        _clothesInfo = clothesSO;
        _image.sprite = _clothesInfo.Sprite;
        _nameLocalized.LocalizationKey = _clothesInfo.Name;
        _priseText.text = _clothesInfo.Cost + "$";
        _isSale.SetActive(_clothesInfo.IsSale);
        _favoriteBtn.Init(_clothesInfo.Code, _clothesInfo.HasSize.FindIndex(x => x.Equals(true)));
        _favoriteBtn.RefreshButton();
        _buyButton.onClick.AddListener(AddToBasket);
        _favoriteButton.onClick.AddListener(AddToFavorite);
        _showInfoButton.onClick.AddListener(ShowInfo);
    }

    private void AddToFavorite()
    {
        FavoritesController.TryAddToFavorites(_clothesInfo.Code, _clothesInfo.HasSize.FindIndex(x => x.Equals(true)));
    }

    private void AddToBasket()
    {
        BasketController.TryAddToBasket(_clothesInfo.Code, _clothesInfo.HasSize.FindIndex(x => x.Equals(true)));
    }

    private void ShowInfo()
    {
        InfoController.ShowInfo(_clothesInfo);
    }
}
