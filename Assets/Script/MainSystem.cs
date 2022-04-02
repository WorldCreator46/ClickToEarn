using UnityEngine;

public class MainSystem : MonoBehaviour
{
    private static MainSystem instance;
    public static MainSystem Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType(typeof(MainSystem)) as MainSystem;
                if (instance == null)
                    Debug.Log("no Singleton obj");
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
