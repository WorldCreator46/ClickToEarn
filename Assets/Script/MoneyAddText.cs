using UnityEngine;

public class MoneyAddText : MonoBehaviour
{
    private void Start()
    {
        TextMesh tm = GetComponent<TextMesh>();
        tm.text = "+ 100";
    }
}
