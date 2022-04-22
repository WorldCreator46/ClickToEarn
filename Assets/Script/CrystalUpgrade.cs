using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class CrystalUpgrade : MonoBehaviour
{
    public Image Crystal;
    public Sprite[] Crystals;
    public GameObject TryUpgradePanel;
    string[] CrystalNames = { };
    private static int CrystalGrade = 0;
    private void Start()
    {
        SetCrystal();
    }
    public static void SetGrade(string grade)
    {
        CrystalGrade = JsonConvert.DeserializeObject<int>(grade);
    }
    public static string GetGrade()
    {
        return JsonConvert.SerializeObject(CrystalGrade);
    }
    public void SetCrystal()
    {
        Crystal.sprite = Crystals[CrystalGrade];
    }
}
