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
        "아쿠아마린",
        "페리도트",
        "토파즈",
        "시트린",
        "가넷",
        "자수정",
        "사파이어",
        "루비",
        "에메랄드",
        "다이아몬드"
    };
    private static Dictionary<string, string> CrystalState = new Dictionary<string, string>()
    {
        {"Name", "아쿠아마린" },
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
        explanation.AppendLine(CrystalState["Name"] + "배");
        explanation.Append("강화 단계 : ");
        explanation.AppendLine(CrystalState["Name"] + "단계");
        explanation.Append("강화 비용 : ");
        explanation.AppendLine(CrystalState["Name"]);
        explanation.Append("강화 확률 : ");
        explanation.Append(CrystalState["Name"] + "%");
        Explanation.text = explanation.ToString();
    }
}
