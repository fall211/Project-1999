using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this.gameObject);
        else Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void ReturnToMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame(){
        SceneManager.LoadScene("TopDown");
    }

}


