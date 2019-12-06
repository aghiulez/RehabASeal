using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rcontrolDrop : MonoBehaviour
{
    public GameObject drop;

    public void play_drop()
    {
        drop.GetComponent<Animator>().Play("dropAnim");
    }
}
