using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class ShopExplanation : MonoBehaviour
{
    public Text ProductName;
    Text ExplanationText;
    void Start()
    {
        ExplanationText = GetComponent<Text>();
        SetExplanation();
    }
    public void SetExplanation()
    {
        string productname = ProductName.text;
        StringBuilder Explanation = new StringBuilder();
        Explanation.Append("���� Ƚ�� : ");
        Explanation.AppendLine(MoneyCalculation.GetNumberOfPurchases(productname));
        Explanation.Append("���� ��ġ : ");
        Explanation.AppendLine(MoneyCalculation.GetIncreaseValue(productname));
        Explanation.Append("���� : ");
        Explanation.Append(MoneyCalculation.Convert(MoneyCalculation.GetPrice(productname)));
        ExplanationText.text = Explanation.ToString();
    }
}
