using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;


public class Option : MonoBehaviour
{
    public Sprite[] Mute;
    public Image AMute;
    public Image BMute;
    public AudioSource Back;
    private static Dictionary<string, int> Options = new Dictionary<string, int>()
    {
        {"A", 1 },
        {"B", 1 }
    };
    private void Start()
    {
        Sets();
    }
    public void SetA()
    {
        Options["A"] = Options["A"] == 1 ? 0 : 1;
        Sets();
    }
    public void SetB()
    {
        Options["B"] = Options["B"] == 1 ? 0 : 1;
        Sets();
    }
    public void Sets()
    {
        AMute.sprite = Mute[Options["A"]];
        AudioListener.volume = Options["A"];
        BMute.sprite = Mute[Options["B"]];
        Back.volume = Options["B"];
    }
    public static void SetOptions(string code)
    {
        Options = JsonConvert.DeserializeObject<Dictionary<string, int>>(code);
    }
    public static string GetOptions()
    {
        return JsonConvert.SerializeObject(Options);
    }
}
