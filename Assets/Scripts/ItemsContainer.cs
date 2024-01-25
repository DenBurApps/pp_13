using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsContainer : MonoBehaviour
{
    [SerializeField] private List<ClothesSO> _allClothes;

    public List<ClothesSO> AllCloths => _allClothes;

    public ClothesSO GetClothesSO(int code)
    {
        foreach (var item in _allClothes)
        {
            if (item.Code == code)
            {
                return item;
            }
        }
        return null;
    }
}
