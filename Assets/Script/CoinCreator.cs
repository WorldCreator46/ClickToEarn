using UnityEngine;

public class CoinCreator : MonoBehaviour
{
    public GameObject Money;
    public void Create(Transform transform)
    {
        GameObject MoneyView = Instantiate(Money);
        MoneyView.transform.SetParent(transform);
        MoneyView.GetComponent<RectTransform>().sizeDelta = new Vector2(1400,0);
        Destroy(MoneyView, 0.2f);
    }
}
