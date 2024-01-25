using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BasketSaveData : SaveData
{
    public List<int> ItemsCode { get; set; }
    public List<int> ItemsCount { get; set; }
    public List<int> ItemsSize { get; set; }

    public BasketSaveData(List<int> itemsCode, List<int> itemsCount, List<int> itemsSize)
    {
        ItemsCode = itemsCode;
        ItemsCount = itemsCount;
        ItemsSize = itemsSize;
    }
}
