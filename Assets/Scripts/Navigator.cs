using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Navigator : MonoBehaviour
{
    [SerializeField] private InfoShower _infoShower;
    [SerializeField] private GameObject _navigatorPanel;
    [SerializeField] private GameObject _searchPanel;
    [SerializeField] private GameObject _filterPanel;
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _clothesPanel;
    [SerializeField] private GameObject _adPanel;
    [SerializeField] private GameObject _favoritePanel;
    [SerializeField] private GameObject _basketPanel;
    [SerializeField] private GameObject _infoCanvas;
    [SerializeField] private GameObject _cashoutCanvas;
    [SerializeField] private GameObject _deliveryCanvas;
    [SerializeField] private GameObject _privacyCanvas;
    [SerializeField] private GameObject _termsCanvas;
    [SerializeField] private GameObject _settingsCanvas;

    [SerializeField] private Image _homeImage;
    [SerializeField] private Image _searchImage;
    [SerializeField] private Image _favoriteImage;
    [SerializeField] private Image _basketImage;
    [SerializeField] private Image _settingsImage;


    [SerializeField] private List<Sprite> _homeSprites;
    [SerializeField] private List<Sprite> _searchSprites;
    [SerializeField] private List<Sprite> _favoriteSprites;
    [SerializeField] private List<Sprite> _basketSprites;
    [SerializeField] private List<Sprite> _settingsSprites;

    private void Awake()
    {
        _infoShower.Init();
        OpenMain();
    }
    public void OpenSearch()
    {
        _filterPanel.SetActive(false);
        _mainPanel.SetActive(false);
        _clothesPanel.SetActive(false);
        _adPanel.SetActive(false);
        _favoritePanel.SetActive(false);
        _basketPanel.SetActive(false);
        _infoCanvas.SetActive(false);
        _cashoutCanvas.SetActive(false);
        _searchPanel.SetActive(true);
        _deliveryCanvas.SetActive(false);
        _privacyCanvas.SetActive(false);
        _termsCanvas.SetActive(false);
        _settingsCanvas.SetActive(false);

        _homeImage.sprite = _homeSprites[0];
        _searchImage.sprite = _searchSprites[1];
        _favoriteImage.sprite = _favoriteSprites[0];
        _basketImage.sprite = _basketSprites[0];
        _settingsImage.sprite = _settingsSprites[0];
    }

    public void OpenFavorites()
    {
        _filterPanel.SetActive(false);
        _mainPanel.SetActive(false);
        _clothesPanel.SetActive(false);
        _adPanel.SetActive(false);
        _favoritePanel.SetActive(true);
        _basketPanel.SetActive(false);
        _infoCanvas.SetActive(false);
        _searchPanel.SetActive(false);
        _cashoutCanvas.SetActive(false);
        _deliveryCanvas.SetActive(false);
        _privacyCanvas.SetActive(false);
        _termsCanvas.SetActive(false);
        _settingsCanvas.SetActive(false);

        _homeImage.sprite = _homeSprites[0];
        _searchImage.sprite = _searchSprites[0];
        _favoriteImage.sprite = _favoriteSprites[1];
        _basketImage.sprite = _basketSprites[0];
        _settingsImage.sprite = _settingsSprites[0];
    }

    public void OpenMain()
    {
        _filterPanel.SetActive(false);
        _mainPanel.SetActive(true);
        _clothesPanel.SetActive(false);
        _adPanel.SetActive(false);
        _favoritePanel.SetActive(false);
        _basketPanel.SetActive(false);
        _infoCanvas.SetActive(false);
        _searchPanel.SetActive(false);
        _cashoutCanvas.SetActive(false);
        _deliveryCanvas.SetActive(false);
        _privacyCanvas.SetActive(false);
        _termsCanvas.SetActive(false);
        _settingsCanvas.SetActive(false);

        _homeImage.sprite = _homeSprites[1];
        _searchImage.sprite = _searchSprites[0];
        _favoriteImage.sprite = _favoriteSprites[0];
        _basketImage.sprite = _basketSprites[0];
        _settingsImage.sprite = _settingsSprites[0];
    }

    public void OpenBasket()
    {
        _filterPanel.SetActive(false);
        _mainPanel.SetActive(false);
        _clothesPanel.SetActive(false);
        _adPanel.SetActive(false);
        _favoritePanel.SetActive(false);
        _basketPanel.SetActive(true);
        _infoCanvas.SetActive(false);
        _searchPanel.SetActive(false);
        _cashoutCanvas.SetActive(false);
        _deliveryCanvas.SetActive(false);
        _privacyCanvas.SetActive(false);
        _termsCanvas.SetActive(false);
        _settingsCanvas.SetActive(false);

        _homeImage.sprite = _homeSprites[0];
        _searchImage.sprite = _searchSprites[0];
        _favoriteImage.sprite = _favoriteSprites[0];
        _basketImage.sprite = _basketSprites[1];
        _settingsImage.sprite = _settingsSprites[0];
    }

    public void OpenSettings()
    {
        _filterPanel.SetActive(false);
        _mainPanel.SetActive(false);
        _clothesPanel.SetActive(false);
        _adPanel.SetActive(false);
        _favoritePanel.SetActive(false);
        _basketPanel.SetActive(false);
        _infoCanvas.SetActive(false);
        _searchPanel.SetActive(false);
        _cashoutCanvas.SetActive(false);
        _deliveryCanvas.SetActive(false);
        _privacyCanvas.SetActive(false);
        _termsCanvas.SetActive(false);
        _settingsCanvas.SetActive(true);

        _homeImage.sprite = _homeSprites[0];
        _searchImage.sprite = _searchSprites[0];
        _favoriteImage.sprite = _favoriteSprites[0];
        _basketImage.sprite = _basketSprites[0];
        _settingsImage.sprite = _settingsSprites[1];
    }
}
