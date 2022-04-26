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
    public Text Explanation;
    string[] CrystalNames =
    {
        "����Ƹ���",
        "�丮��Ʈ",
        "������",
        "��Ʈ��",
        "����",
        "�ڼ���",
        "�����̾�",
        "���",
        "���޶���",
        "���̾Ƹ��"
    };
    private static Dictionary<string, string> CrystalState = new Dictionary<string, string>()
    {
        {"Name", "����Ƹ���" },
        {"Grade", "0" },
        {"Class", "0" }
    };
    private void Start()
    {
        SetCrystal();
        SetExplanation();
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
        int grade = int.Parse(CrystalState["Grade"]);
        CrystalState["Name"] = CrystalNames[grade];
        Crystal.sprite = Crystals[grade];
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
        explanation.AppendLine(CrystalState["Name"] + "��");
        explanation.Append("��ȭ �ܰ� : ");
        explanation.AppendLine(CrystalState["Name"] + "�ܰ�");
        explanation.Append("��ȭ ��� : ");
        explanation.AppendLine(CrystalState["Name"]);
        explanation.Append("��ȭ Ȯ�� : ");
        explanation.Append(CrystalState["Name"] + "%");
        Explanation.text = explanation.ToString();
    }
}
