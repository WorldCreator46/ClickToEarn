using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class CrystalUpgrade : MonoBehaviour
{
    public Image Crystal;
    public Image CrystalIMG;
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
    private static List<string> CrystalNames = new List<string>(CrystalGrade.Keys);
    private static Dictionary<string, string> CrystalState = new Dictionary<string, string>()
    {
        {"Name", "아쿠아마린" },
        {"Class", "0" }
    };
    private void Start()
    {
        OffTryUpgradePanel(); 
        SetExplanation();
    }
    public static void SetCrystalState(string grade)
    {
        CrystalState = JsonConvert.DeserializeObject<Dictionary<string,string>>(grade);
    }
    public static string GetCrystalState()
    {
        return JsonConvert.SerializeObject(CrystalState);
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
        Property.SubtractMoney(System.Numerics.BigInteger.Parse(MoneyCalculation.GetUpgradeCost()));
        System.Random rand = new System.Random();
        int Probability = rand.Next()%10;
        if(GetCrystalClass() == "10")
        {
            TryEvolution();
        }
        else
        {
            if (Probability < GetUpgradeProbability() / 10)
            {
                CrystalUpgradeSuccess();
            }
            else
            {
                ResultsPanel(false);
            }
        }
        SetExplanation();
    }
    public void TryEvolution()
    {
        System.Random rand = new System.Random();
        int Probability = rand.Next() % 10;
        if (Probability < GetEvolutionProbability() / 10)
        {
            CrystalEvolutionSuccess();
        }
        else
        {
            ResultsPanel(false);
        }
    }
    public void CrystalUpgradeSuccess()
    {
        CrystalState["Class"] = (int.Parse(GetCrystalClass()) + 1).ToString();
        ResultsPanel(true);
    }
    public void CrystalEvolutionSuccess()
    {
        CrystalState["Class"] = "0";
        CrystalState["Name"] = CrystalNames[GetCrystalGrade() + 1];
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
        Invoke("OffResultPanel", 0.4f);
    }
    public void OffResultPanel()
    {
        ResultPanel.SetActive(false);
    }
    public int GetUpgradeProbability()
    {
        return 100 - (int.Parse(GetCrystalClass()) * 10);
    }
    public int GetEvolutionProbability()
    {
        return 100 - GetCrystalGrade() * 10;
    }
    public static string GetPerformance()
    {
        string Temp = (GetCrystalGrade() * 200 + (int.Parse(GetCrystalClass()) * 10)).ToString();
        if(Temp == "0") Temp = "1";
        if (CrystalState["Name"] == "다이아몬드" && GetCrystalClass() == "10")
        {
            Temp = "10000";
        }
        return Temp;
    }
    public bool TheLast()
    {
        bool result = false;
        if(CrystalState["Name"] == "다이아몬드" && GetCrystalClass() == "10") result = true;
        return result;
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
        Crystal.sprite = Crystals[GetCrystalGrade()];
        CrystalIMG.sprite = Crystals[GetCrystalGrade()];

        StringBuilder explanation = new StringBuilder();
        explanation.Append("현재 등급 : ");
        explanation.AppendLine(CrystalState["Name"]);
        explanation.Append("현재 성능 : ");
        explanation.AppendLine(GetPerformance() + "배");
        explanation.Append("강화 단계 : ");
        explanation.AppendLine(GetCrystalClass() + "단계");

        if (TheLast())
        {
            TryButton.interactable = false;
            UpgradeOrEvolution.text = "끝";
        }
        else
        {
            if (GetCrystalClass() == "10")
            {
                explanation.Append("진화 비용 : ");
                explanation.AppendLine(MoneyCalculation.Convert(MoneyCalculation.GetEvolutionCost()));
                explanation.Append("진화 확률 : ");
                explanation.Append(GetEvolutionProbability() + "%");

                UpgradeOrEvolution.text = "진화!";
            }
            else
            {
                explanation.Append("강화 비용 : ");
                explanation.AppendLine(MoneyCalculation.Convert(MoneyCalculation.GetUpgradeCost()));
                explanation.Append("강화 확률 : ");
                explanation.Append(GetUpgradeProbability() + "%");

                UpgradeOrEvolution.text = "강화";
            }
            if (MoneyCalculation.CostComparison())
            {
                TryButton.interactable = true;
            }
            else
            {
                TryButton.interactable = false;
                UpgradeOrEvolution.text = "돈 없음";
            }
        }
        Explanation.text = explanation.ToString();
    }
}
