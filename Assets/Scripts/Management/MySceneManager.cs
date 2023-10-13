using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager Instance { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

}


