using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCounter : MonoBehaviour
{
    int keyAmount = 0;
    public int KeyAmount{get{return keyAmount;}}

    public void IncreaseKeyAmount()
    {
        keyAmount += 1;
    }
}
