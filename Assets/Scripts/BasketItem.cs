using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Assets.SimpleLocalization.Scripts;

public class BasketItem : MonoBehaviour
{
    private ClothesSO _clothesInfo;
    private int _size;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _priseText;
    [SerializeField] private TMP_Text _sizeText;
    [SerializeField] private TMP_Text _deskText;
    [SerializeField] private TMP_Text _countText;
    [SerializeField] private Button _deleteButton;
    [SerializeField] private Button _addCount;
    [SerializeField] private Button _removeCount;
    [SerializeField] private LocalizedTMPText _nameLocalized;

    public void Init(ClothesSO clothesSO, int size, int count)
    {
        _clothesInfo = clothesSO;
        _size = size;
        _image.sprite = _clothesInfo.Sprite;
        _nameLocalized.LocalizationKey = _clothesInfo.Name;
        _priseText.text = _clothesInfo.Cost + "$";
        _countText.text = count.ToString();
        _sizeText.text = "size " + (SizeTypes.Type)_size;
        _deskText.text = _clothesInfo.ShortDescription;
        _deleteButton.onClick.AddListener(OnDeleteButtonClick);
        _addCount.onClick.AddListener(OnAddCountClick);
        _removeCount.onClick.AddListener(OnRemoveCountClick);
    }

    private void OnDeleteButtonClick()
    {
        BasketController.RemoveFromBasket(_clothesInfo.Code, _size);
    }

    private void OnAddCountClick()
    {
        BasketController.IncreseCount(_clothesInfo.Code, _size);
    }

    private void OnRemoveCountClick()
    {
        BasketController.DecreseCount(_clothesInfo.Code, _size);
    }

}
