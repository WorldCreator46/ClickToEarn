using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageController : MonoBehaviour
{
    public GameObject[] Pages;
    public GameObject NextButton;
    public GameObject BackButton;
    public Text PageNumber;
    public int idx = 0;
    private void Start()
    {
        idx = 0;
        Cheking();
    }
    public void Cheking()
    {
        ButtonCheck();
        PageNumbering();
    }
    public void PageNumbering()
    {
        PageNumber.text = Pages[idx].name;
    }
    public void ButtonCheck()
    {
        if(Pages[idx].name == "1")
        {
            BackButton.SetActive(false);
            NextButton.SetActive(true);
        }
        else if(Pages[idx].name == Pages.Length.ToString())
        {
            BackButton.SetActive(true);
            NextButton.SetActive(false);
        }
        else
        {
            BackButton.SetActive(true);
            NextButton.SetActive(true);
        }
    }
    public void Next()
    {
        if(idx < Pages.Length-1)
        {
            Pages[idx].SetActive(false);
            Pages[++idx].SetActive(true);
            Cheking();
        }
    }
    public void Back()
    {
        if (idx > 0)
        {
            Pages[idx].SetActive(false);
            Pages[--idx].SetActive(true);
            Cheking();
        }
    }
}
