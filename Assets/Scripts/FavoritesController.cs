using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FavoritesController
{
    public static Action FavorivesRemoved;
    public static Action FavoritesAdded;

    public static void TryAddToFavorites(int code, int size)
    {
        var fav = SaveSystem.LoadData<FavoritesSaveData>();
        bool hasItem = false;
        for (int i = 0; i < fav.Items.Count; i++)
        {
            if (fav.Items[i] == code && fav.ItemsSize[i] == size)
            {
                hasItem = true;
            }
        }
        if (hasItem)
        {
            return;
        }
        else
        {
            fav.ItemsSize.Add(size);
            fav.Items.Add(code);
            SaveSystem.SaveData(fav);
            FavoritesAdded?.Invoke();
        }
    }

    public static void RemoveFromFavorites(int code, int size)
    {
        var fav = SaveSystem.LoadData<FavoritesSaveData>();
        for (int i = 0; i < fav.Items.Count; i++)
        {
            if(fav.Items[i] == code && fav.ItemsSize[i] == size)
            {
                Debug.Log(i);
                fav.ItemsSize.RemoveAt(i);
                fav.Items.RemoveAt(i);
                SaveSystem.SaveData(fav);
                FavorivesRemoved?.Invoke();
                return;
            }
        }
    }
}
