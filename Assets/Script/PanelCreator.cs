using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCreator : MonoBehaviour
{
    public GameObject Panel;
    public Text PanelText;
    public void PanelCreate(bool tf)
    {
        if (tf)
        {
            PanelText.text = "구매 성공!";
        }
        else
        {
            PanelText.text = "구매 실패";
        }
        Panel.SetActive(true);
        Invoke("PanelActiveOff", 0.5f);
    }
    public void PanelActiveOff()
    {
        Panel.SetActive(false);
    }
}
