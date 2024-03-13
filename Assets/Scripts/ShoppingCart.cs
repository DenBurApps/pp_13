using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class ShoppingCart : MonoBehaviour
{
    [SerializeField] private GameObject _popup;
    [SerializeField] private TMP_Text _itemsCountText;

    private void OnEnable()
    {
        BasketController.BasketUpdated += OnBasketUpdated;
    }

    private void OnDisable()
    {
        BasketController.BasketUpdated -= OnBasketUpdated;
    }

    private void Start()
    {
        OnBasketUpdated();
    }

    private void OnBasketUpdated()
    {
        var basket = SaveSystem.LoadData<BasketSaveData>();
        if (basket.ItemsCode.Count > 0)
        {
            _popup.SetActive(true);
            _itemsCountText.text = basket.ItemsCode.Count.ToString();
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
