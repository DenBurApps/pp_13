using Assets.SimpleLocalization.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FavoriteItem : MonoBehaviour
{
    private ClothesSO _clothesInfo;
    private int _size;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _priseText;
    [SerializeField] private TMP_Text _sizeText;
    [SerializeField] private TMP_Text _deskText;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _deleteButton;
    [SerializeField] private LocalizedTMPText _nameLocalized;

    public void Init(ClothesSO clothesSO, int size)
    {
        _clothesInfo = clothesSO;
        _size = size;
        _image.sprite = _clothesInfo.Sprite;
        _nameLocalized.LocalizationKey = _clothesInfo.Name;
        _priseText.text = _clothesInfo.Cost + "$";
        _sizeText.text = "size " + (SizeTypes.Type)_size;
        _deskText.text = _clothesInfo.ShortDescription;
        _deleteButton.onClick.AddListener(OnDeleteButtonClick);
        _buyButton.onClick.AddListener(OnBuyButtonClick);
    }

    private void OnDeleteButtonClick()
    {
        FavoritesController.RemoveFromFavorites(_clothesInfo.Code, _size);
    }

    private void OnBuyButtonClick()
    {
        BasketController.TryAddToBasket(_clothesInfo.Code, _size);
    }
}
