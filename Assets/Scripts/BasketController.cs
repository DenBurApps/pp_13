using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BasketController
{
    public static Action BasketUpdated;

    public static void TryAddToBasket(int code, int size)
    {
        var basket = SaveSystem.LoadData<BasketSaveData>();
        bool hasItem = false;
        for (int i = 0; i < basket.ItemsCode.Count; i++)
        {
            if (basket.ItemsCode[i] == code && basket.ItemsSize[i] == size)
            {
                basket.ItemsCount[i] += 1;
                SaveSystem.SaveData(basket);
                hasItem = true;
                BasketUpdated?.Invoke();
            }
        }
        if (hasItem)
        {
            return;
        }
        else
        {
            basket.ItemsSize.Add(size);
            basket.ItemsCode.Add(code);
            basket.ItemsCount.Add(1);
            SaveSystem.SaveData(basket);
            BasketUpdated?.Invoke();
        }
    }

    public static void DecreseCount(int code, int size)
    {
        var basket = SaveSystem.LoadData<BasketSaveData>();
        for (int i = 0; i < basket.ItemsCode.Count; i++)
        {
            if (basket.ItemsCode[i] == code && basket.ItemsSize[i] == size)
            {
                if(basket.ItemsCount[i] > 1)
                {
                    basket.ItemsCount[i] -= 1;
                }
                SaveSystem.SaveData(basket);
                BasketUpdated?.Invoke();
                return;
            }
        }
    }

    public static void IncreseCount(int code, int size)
    {
        var basket = SaveSystem.LoadData<BasketSaveData>();
        for (int i = 0; i < basket.ItemsCode.Count; i++)
        {
            if (basket.ItemsCode[i] == code && basket.ItemsSize[i] == size)
            {
                if (basket.ItemsCount[i] < 10)
                {
                    basket.ItemsCount[i] += 1;
                }
                SaveSystem.SaveData(basket);
                BasketUpdated?.Invoke();
                return;
            }
        }
    }

    public static void RemoveFromBasket(int code, int size)
    {
        var basket = SaveSystem.LoadData<BasketSaveData>();
        for (int i = 0; i < basket.ItemsCode.Count; i++)
        {
            if (basket.ItemsCode[i] == code && basket.ItemsSize[i] == size)
            {
                Debug.Log(i);
                basket.ItemsSize.RemoveAt(i);
                basket.ItemsCode.RemoveAt(i);
                basket.ItemsCount.RemoveAt(i);
                SaveSystem.SaveData(basket);
                BasketUpdated?.Invoke();
                return;
            }
        }
    }

    public static void ClearBasket()
    {
        var basket = SaveSystem.LoadData<BasketSaveData>();
        basket.ItemsCode.Clear();
        basket.ItemsCount.Clear();
        basket.ItemsSize.Clear();
        SaveSystem.SaveData(basket);
        BasketUpdated?.Invoke();
    }
}
