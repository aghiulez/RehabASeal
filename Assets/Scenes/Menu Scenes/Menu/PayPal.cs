using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayPal : MonoBehaviour
{
    public void OpenURL()
    {
        Application.OpenURL("https://www.pacificmmc.org/donate");
    }
}
