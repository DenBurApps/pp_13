using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InfoController 
{
    public static Action<ClothesSO> InfoShowed;

    public static void ShowInfo(ClothesSO clothes)
    {
        InfoShowed?.Invoke(clothes);
    }


}
