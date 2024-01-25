using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LocalizationSaveData : SaveData
{
    public string Language { get; set; }

    public LocalizationSaveData(string language)
    {
        Language = language;
    }
}
