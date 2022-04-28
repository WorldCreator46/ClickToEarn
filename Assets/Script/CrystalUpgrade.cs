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
    public Text Explanation;
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
        {"Class", "0" }
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
    }
    public void OffTryUpgradePanel()
    {
        TryUpgradePanel.SetActive(false);
    }
    public void TryUpgrade()
    {

    }
    public void ResultsPanel(bool result)
    {
        if (result)
        {

        }
        else
        {

        }
    }
    public int GetProbability()
    {
        return (100 - (int.Parse(GetCrystalClass()) * 10));
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
        int Performance = (GetCrystalGrade() + 1) * (int.Parse(GetCrystalClass()) +1) * 5;
        explanation.Append("���� ���� : ");
        explanation.AppendLine(Performance + "��");
        explanation.Append("��ȭ �ܰ� : ");
        explanation.AppendLine(GetCrystalClass() + "�ܰ�");
        explanation.Append("��ȭ ��� : ");
        explanation.AppendLine(MoneyCalculation.GetEnhanceCost());
        explanation.Append("��ȭ Ȯ�� : ");
        explanation.Append(GetProbability()+"%");
        Explanation.text = explanation.ToString();
    }
}
