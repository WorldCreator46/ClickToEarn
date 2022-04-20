using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalUpdate : MonoBehaviour
{
    public Image Crystal;
    public Sprite[] Crystals;
    private void Start()
    {
        Crystal.sprite = Crystals[0];
    }
}
