using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SimpleLocalization.Scripts;

public class MultiLanguage : MonoBehaviour
{
    public void Localize()
    {
        LocalizationManager.Read();
        var local = SaveSystem.LoadData<LocalizationSaveData>();
        LocalizationManager.Language = local.Language;
    }
}
