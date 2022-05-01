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
        { "����Ƹ���", 0 },
        { "�丮��Ʈ", 1 },
        { "������", 2 },
        { "��Ʈ��", 3 },
        { "����", 4 },
        { "�ڼ���", 5 },
        { "�����̾�", 6 },
        { "���", 7 },
        { "���޶���", 8 },
        { "���̾Ƹ��", 9 }
    };
    private static List<string> CrystalNames = new List<string>(CrystalGrade.Keys);
    private static Dictionary<string, string> CrystalState = new Dictionary<string, string>()
    {
        {"Name", "����Ƹ���" },
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
            ResultText.text = "����!";
        }
        else
        {
            ResultText.text = "����";
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
        if (CrystalState["Name"] == "���̾Ƹ��" && GetCrystalClass() == "10")
        {
            Temp = "10000";
        }
        return Temp;
    }
    public bool TheLast()
    {
        bool result = false;
        if(CrystalState["Name"] == "���̾Ƹ��" && GetCrystalClass() == "10") result = true;
        return result;
    }
    public void SetExplanation()
    {
        /*
         * ���� ��� : ?
         * ���� ���� : ?��
         * ��ȭ �ܰ� : 0~10�ܰ�
         * ��ȭ ��� : ?
         * ��ȭ Ȯ�� : ?%
         */
        Crystal.sprite = Crystals[GetCrystalGrade()];
        CrystalIMG.sprite = Crystals[GetCrystalGrade()];

        StringBuilder explanation = new StringBuilder();
        explanation.Append("���� ��� : ");
        explanation.AppendLine(CrystalState["Name"]);
        explanation.Append("���� ���� : ");
        explanation.AppendLine(GetPerformance() + "��");
        explanation.Append("��ȭ �ܰ� : ");
        explanation.AppendLine(GetCrystalClass() + "�ܰ�");

        if (TheLast())
        {
            TryButton.interactable = false;
            UpgradeOrEvolution.text = "��";
        }
        else
        {
            if (GetCrystalClass() == "10")
            {
                explanation.Append("��ȭ ��� : ");
                explanation.AppendLine(MoneyCalculation.Convert(MoneyCalculation.GetEvolutionCost()));
                explanation.Append("��ȭ Ȯ�� : ");
                explanation.Append(GetEvolutionProbability() + "%");

                UpgradeOrEvolution.text = "��ȭ!";
            }
            else
            {
                explanation.Append("��ȭ ��� : ");
                explanation.AppendLine(MoneyCalculation.Convert(MoneyCalculation.GetUpgradeCost()));
                explanation.Append("��ȭ Ȯ�� : ");
                explanation.Append(GetUpgradeProbability() + "%");

                UpgradeOrEvolution.text = "��ȭ";
            }
            if (MoneyCalculation.CostComparison())
            {
                TryButton.interactable = true;
            }
            else
            {
                TryButton.interactable = false;
                UpgradeOrEvolution.text = "�� ����";
            }
        }
        Explanation.text = explanation.ToString();
    }
}
