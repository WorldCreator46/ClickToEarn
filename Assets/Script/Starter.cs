using UnityEngine;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void FirstLoad()
    {
        SceneManager.LoadScene("Ready");
    }
    private void Start()
    {
        SceneManager.LoadScene("Play");
    }
}
