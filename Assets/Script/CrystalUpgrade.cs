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
    private static Dictionary<string, string> CrystalState = new Dictionary<string, string>()
    {
        {"Name", "����Ƹ���" },
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
        Debug.Log("��ȭ!");
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
            ResultText.text = "����!";
        }
        else
        {
            ResultText.text = "����";
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
         * ���� ��� : ?
         * ���� ���� : ?��
         * ��ȭ �ܰ� : 0~10�ܰ�
         * ��ȭ ��� : ?
         * ��ȭ Ȯ�� : ?%
         */
        StringBuilder explanation = new StringBuilder();
        explanation.Append("���� ��� : ");
        explanation.AppendLine(CrystalState["Name"]);
        explanation.Append("���� ���� : ");
        explanation.AppendLine(GetPerformance() + "��");
        explanation.Append("��ȭ �ܰ� : ");
        explanation.AppendLine(GetCrystalClass() + "�ܰ�");
        explanation.Append("��ȭ ��� : ");
        explanation.AppendLine(MoneyCalculation.Convert(MoneyCalculation.GetEnhanceCost()));
        explanation.Append("��ȭ Ȯ�� : ");
        explanation.Append(GetProbability()+"%");
        Explanation.text = explanation.ToString();
        if (MoneyCalculation.CostComparison())
        {
            UpgradeOrEvolution.text = "��ȭ";
            TryButton.interactable = true;
            if (GetCrystalClass() == "10")
            {
                UpgradeOrEvolution.text = "��ȭ!";
            }
        }
        else
        {
            TryButton.interactable = false;
            UpgradeOrEvolution.text = "�� ����";
        }
    }
}
