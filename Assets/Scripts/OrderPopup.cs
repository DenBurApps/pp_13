using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OrderPopup : MonoBehaviour
{
    [SerializeField] private GameObject _popup;

    private void Awake()
    {
        _popup.transform.localScale = Vector3.zero;
    }

    public void ShowOrderPopup()
    {
        _popup.transform.DOScale(1, 0.5f).SetLink(gameObject).OnComplete(() =>
        {
            _popup.transform.DOScale(0, 0.5f).SetDelay(3f).SetLink(gameObject);
        });
    }
}
