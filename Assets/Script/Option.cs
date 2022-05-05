using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Option : MonoBehaviour
{
    public Sprite NoMute;
    public Sprite YesMute;
    public Image Mute;
    private static Dictionary<string, string> Options = new Dictionary<string, string>()
    {
        {"Mute", "No" }
    };
    public void SetMute()
    {
        if (Options["Mute"] == "No")
        {
            Mute.sprite = YesMute;
            Options["Mute"] = "Yes";
        }
        else
        {
            Mute.sprite = NoMute;
            Options["Mute"] = "No";
        }
    }
}
