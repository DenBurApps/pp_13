using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FavoritePopup : MonoBehaviour
{
    [SerializeField] private GameObject _popup;
    [SerializeField] private TMP_Text _itemsCountText;

    private void OnEnable()
    {
        FavoritesController.FavoritesAdded += OnFavoritesUpdated;
        FavoritesController.FavorivesRemoved += OnFavoritesUpdated;
    }

    private void OnDisable()
    {
        FavoritesController.FavoritesAdded -= OnFavoritesUpdated;
        FavoritesController.FavorivesRemoved -= OnFavoritesUpdated;
    }

    private void Start()
    {
        OnFavoritesUpdated();
    }

    private void OnFavoritesUpdated()
    {
        var favotires = SaveSystem.LoadData<FavoritesSaveData>();
        if (favotires.Items.Count > 0)
        {
            _popup.SetActive(true);
            _itemsCountText.text = favotires.Items.Count.ToString();
            _popup.transform.DOScale(2f, 0.3f).SetEase(Ease.OutBounce).SetLink(gameObject).OnComplete(() =>
            {
                _popup.transform.DOScale(1f, 0.3f).SetLink(gameObject);
            });
        }
        else
        {
            _popup.SetActive(false);
        }
    }
}
