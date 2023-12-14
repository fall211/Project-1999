using UnityEngine;

public class Buttons : MonoBehaviour
{

    public void ReturnToMenu(){
        MySceneManager.Instance.ReturnToMenu();
    }
    public void StartGame(){
        MySceneManager.Instance.StartGame();
    }
    public void QuitGame(){
        MySceneManager.Instance.QuitGame();
    }

    public void Begin(){
        TopDownManager.Instance.Begin();

    }

}
