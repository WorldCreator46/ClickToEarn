using UnityEngine;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void FirstLoad()
    {
        SceneManager.LoadScene("Play");
    }
}
