using UnityEngine;

public class CoinPrefabCreator : MonoBehaviour
{
    public GameObject CoinPrefab;
    public void CreateCoin()
    {
        Vector3 pos = new Vector3((Input.mousePosition.x / 153f) - 7.9f, (Input.mousePosition.y / 150f) - 4.8f, 0);
        GameObject temp = Instantiate(CoinPrefab);
        temp.transform.position = pos;
        Destroy(temp, 0.15f);
    }
}
