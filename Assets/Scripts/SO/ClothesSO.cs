using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Clothes", menuName = "Clothes", order = 1)]

[Serializable]
public class ClothesSO : ScriptableObject
{
    public int Code;
    public string Name;
    public ClothesTypes.Types Type;
    public int Cost;
    public Sprite Sprite;
    public string Description = "Description";
    public string ShortDescription = "Short description";
    public bool IsSale = false;
    public bool IsNew = false;
    public List<bool> HasSize;
}
