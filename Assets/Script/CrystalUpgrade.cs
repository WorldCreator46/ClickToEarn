using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class CrystalUpgrade : MonoBehaviour
{
    public Image Crystal;
    public Sprite[] Crystals;
    public GameObject TryUpgradePanel;
    public GameObject ResultPanel;
    public Text ResultText;
    public Text Explanation;
    public Text UpgradeOrEvolution;
    public Button TryButton;
    private static Dictionary<string, int> CrystalGrade = new Dictionary<string, int>()
    {
        { "아쿠아마린", 0 },
        { "페리도트", 1 },
        { "토파즈", 2 },
        { "시트린", 3 },
        { "가넷", 4 },
        { "자수정", 5 },
        { "사파이어", 6 },
        { "루비", 7 },
        { "에메랄드", 8 },
        { "다이아몬드", 9 }
    };
    private static Dictionary<string, string> CrystalState = new Dictionary<string, string>()
    {
        {"Name", "아쿠아마린" },
        {"Class", "0" },
        {"Performance", "" }
    };
    private void Start()
    {
        OffTryUpgradePanel();
        SetCrystal();
    }
    public static void SetGrade(string grade)
    {
        CrystalState = JsonConvert.DeserializeObject<Dictionary<string,string>>(grade);
    }
    public static string GetGrade()
    {
        return JsonConvert.SerializeObject(CrystalState);
    }
    public void SetCrystal()
    {
        Crystal.sprite = Crystals[GetCrystalGrade()];
        SetExplanation();
    }
    public static int GetCrystalGrade()
    {
        return CrystalGrade[CrystalState["Name"]];
    }
    public static string GetCrystalClass()
    {
        return CrystalState["Class"];
    }
    public void OnTryUpgradePanel()
    {
        TryUpgradePanel.SetActive(true);
        SetExplanation();
    }
    public void OffTryUpgradePanel()
    {
        TryUpgradePanel.SetActive(false);
    }
    public void TryUpgrade()
    {
        Property.SubtractMoney(System.Numerics.BigInteger.Parse(MoneyCalculation.GetEnhanceCost()));
        System.Random rand = new System.Random();
        int Probability = rand.Next()%10;
        if(GetCrystalClass() == "10")
        {
            TryEvolution();
        }
        if(Probability < GetProbability() / 10)
        {
            CrystalUpgradeSuccess();
        }
        else
        {
            ResultsPanel(false);
        }
        SetExplanation();
    }
    public void TryEvolution()
    {
        Debug.Log("진화!");
    }
    public void CrystalUpgradeSuccess()
    {
        CrystalState["Class"] = (int.Parse(GetCrystalClass()) + 1).ToString();
        ResultsPanel(true);
    }
    public void CrystalEvolutionSuccess()
    {
        ResultsPanel(true);
    }
    public void ResultsPanel(bool result)
    {
        if (result)
        {
            ResultText.text = "성공!";
        }
        else
        {
            ResultText.text = "실패";
        }
        ResultPanel.SetActive(true);
    }
    public int GetProbability()
    {
        return (100 - (int.Parse(GetCrystalClass()) * 10));
    }
    public static string GetPerformance()
    {
        CrystalState["Performance"] = ((GetCrystalGrade() + 1) * (int.Parse(GetCrystalClass()) + 1) * 10).ToString();
        return CrystalState["Performance"];
    }
    public void SetExplanation()
    {
        /*
         * 현재 등급 : ?
         * 현재 성능 : ?배
         * 강화 단계 : 0~10단계
         * 강화 비용 : ?
         * 강화 확률 : ?%
         */
        StringBuilder explanation = new StringBuilder();
        explanation.Append("현재 등급 : ");
        explanation.AppendLine(CrystalState["Name"]);
        explanation.Append("현재 성능 : ");
        explanation.AppendLine(GetPerformance() + "배");
        explanation.Append("강화 단계 : ");
        explanation.AppendLine(GetCrystalClass() + "단계");
        explanation.Append("강화 비용 : ");
        explanation.AppendLine(MoneyCalculation.Convert(MoneyCalculation.GetEnhanceCost()));
        explanation.Append("강화 확률 : ");
        explanation.Append(GetProbability()+"%");
        Explanation.text = explanation.ToString();
        if (MoneyCalculation.CostComparison())
        {
            UpgradeOrEvolution.text = "강화";
            TryButton.interactable = true;
            if (GetCrystalClass() == "10")
            {
                UpgradeOrEvolution.text = "진화!";
            }
        }
        else
        {
            TryButton.interactable = false;
            UpgradeOrEvolution.text = "돈 없음";
        }
    }
}
