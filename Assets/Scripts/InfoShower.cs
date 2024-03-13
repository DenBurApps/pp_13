using Assets.SimpleLocalization.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoShower : MonoBehaviour
{
    [SerializeField] private Image _photo;
    [SerializeField] private TMP_Text _priseText;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private List<Button> _sizeButtons;
    [SerializeField] private List<Image> _sizeImages;
    [SerializeField] private List<Sprite> _sizeSprites;
    [SerializeField] private Button _addToFavoriteButton;
    [SerializeField] private Button _addToBasketButton;
    [SerializeField] private LocalizedTMPText _nameLText;
    [SerializeField] private LocalizedTMPText _deskLText;
    [SerializeField] private FavoriteButton _favoriteButton;
    private int _currentSize = 0;
    private ClothesSO _clothes;

    public void Init()
    {
        InfoController.InfoShowed += ShowInfo;
    }

    private void OnDestroy()
    {
        InfoController.InfoShowed -= ShowInfo;
    }

    public void HideInfo()
    {
        gameObject.SetActive(false);
    }

    public void ShowInfo(ClothesSO clothes)
    {
        
        gameObject.SetActive(true);
        _clothes = clothes;
        _photo.sprite = clothes.Sprite;
        _priseText.text = clothes.Cost + "$";
        _nameLText.LocalizationKey = clothes.Name;
        _deskLText.LocalizationKey = clothes.Description;
        _addToBasketButton.onClick.RemoveAllListeners();
        _addToFavoriteButton.onClick.RemoveAllListeners();
        foreach (var item in _sizeButtons)
        {
            item.onClick.RemoveAllListeners();
        }
        _sizeButtons[0].interactable = clothes.HasSize[0];
        _sizeButtons[0].onClick.AddListener(() => SetCurrentSize(0));
        _sizeButtons[1].interactable = clothes.HasSize[1];
        _sizeButtons[1].onClick.AddListener(() => SetCurrentSize(1));
        _sizeButtons[2].interactable = clothes.HasSize[2];
        _sizeButtons[2].onClick.AddListener(() => SetCurrentSize(2));
        _sizeButtons[3].interactable = clothes.HasSize[3];
        _sizeButtons[3].onClick.AddListener(() => SetCurrentSize(3));
        _sizeButtons[4].interactable = clothes.HasSize[4];
        _sizeButtons[4].onClick.AddListener(() => SetCurrentSize(4));
        _currentSize = clothes.HasSize.FindIndex(x => x.Equals(true));
        _favoriteButton.Init(clothes.Code, _currentSize);
        _favoriteButton.RefreshButton();
        Debug.Log(_currentSize);
        SetCurrentSize(_currentSize);
        _addToFavoriteButton.onClick.AddListener(OnFavotiteClick);
        _addToBasketButton.onClick.AddListener(OnBasketClick);
        var local = SaveSystem.LoadData<LocalizationSaveData>();
        LocalizationManager.Language = local.Language;
    }

    public void OnFavotiteClick()
    {
        FavoritesController.TryAddToFavorites(_clothes.Code, _currentSize);
    }

    public void OnBasketClick()
    {
        BasketController.TryAddToBasket(_clothes.Code, _currentSize);
    }

    public void SetCurrentSize(int index)
    {
        _currentSize = index;
        foreach (var item in _sizeImages)
        {
            item.sprite = _sizeSprites[0];
        }
        _sizeImages[_currentSize].sprite = _sizeSprites[1];
        _favoriteButton.Init(_clothes.Code, _currentSize);
        _favoriteButton.RefreshButton();
    }
}
