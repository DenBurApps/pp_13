using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class FavoritesSaveData : SaveData
{
    public List<int> ItemsSize { get; set; }
    public List<int> Items {get; set;}

    public FavoritesSaveData(List<int> itemsSize, List<int> items)
    {
        ItemsSize = itemsSize;
        Items = items;
    }

}
