using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public string menuName;

    public void OnEnable()
    {
        if(menuName == "store")
        {
            CurrencyManager.Instance.PackInit();
        }
    }
}
