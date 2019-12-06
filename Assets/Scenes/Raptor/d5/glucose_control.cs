using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glucose_control : MonoBehaviour
{
    public GameObject glucose_stick;

    public void glucose_animation()
    {
        glucose_stick.GetComponent<Animator>().Play("glucose_color_change");
    }
}
