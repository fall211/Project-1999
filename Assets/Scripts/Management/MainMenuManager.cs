using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> gameButtons = new List<GameObject>();
    private Game currentGame = Game.Puzzle;

    // Start is called before the first frame update
    void Start()
    {
        //HighlightSelectedGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HighlightSelectedGame(){
        foreach (GameObject button in gameButtons){
            button.transform.localScale = Vector3.one;
        }
        gameButtons[(int)currentGame].transform.localScale = Vector3.one * 1.1f;
        gameButtons[(int)currentGame].transform.SetAsLastSibling();
        
        // enable the visual effect

    }


    public void PlayCurrentGame(){
        Debug.Log("Playing " + currentGame);
        MySceneManager.Instance.LoadScene(FromGame(currentGame));
    }
    public void SetCurrentGame(string game){
        currentGame = ToGame(game);
        HighlightSelectedGame();
    }
    private Game ToGame(string game){
        return game switch
        {
            "Puzzle" => Game.Puzzle,
            "Maze" => Game.Maze,
            "CYOA" => Game.CYOA,
            "Runner" => Game.Runner,
            "TopDown" => Game.TopDown,
            _ => Game.Puzzle,
        };
    }
    private string FromGame(Game game){
        return game switch
        {
            Game.Puzzle => "Puzzle",
            Game.Maze => "Maze",
            Game.CYOA => "CYOA",
            Game.Runner => "Runner",
            Game.TopDown => "TopDown",
            _ => "Puzzle",
        };
    }
    public enum Game {
        Puzzle,
        Maze,
        CYOA,
        Runner,
        TopDown,
    }

}
