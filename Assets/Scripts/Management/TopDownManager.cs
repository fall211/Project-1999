using UnityEngine;
using TMPro;

public class TopDownManager : MonoBehaviour
{
    public static TopDownManager Instance { get; private set; }
    [HideInInspector] public GameState state = GameState.Paused;
    public Skill skillOne = Skill.Invis;
    public Skill skillTwo = Skill.Heal;
    public float audioScale = 1f;
    public GameObject canvas;
    GameObject gameOverScreen;
    GameObject gameOverText;
    GameObject gameStatusText;
    GameObject replayButton;
    GameObject helpScreen;
    void Awake() {
        if (Instance != null && Instance != this) Destroy(this.gameObject);
        else Instance = this;
    }

    public void Begin(){
        helpScreen.SetActive(false);
        SingularityAI singularity = GameObject.Find("Singularity").GetComponent<SingularityAI>();
        singularity.Begin();
        state = GameState.Playing;

    }
    void Start(){
        canvas = GameObject.Find("Canvas");
        if (canvas == null) return;
        gameOverScreen = canvas.transform.GetChild(4).gameObject;
        gameOverText = gameOverScreen.transform.GetChild(1).gameObject;
        gameStatusText = gameOverScreen.transform.GetChild(2).gameObject;
        replayButton = gameOverScreen.transform.GetChild(3).gameObject;
        helpScreen = canvas.transform.GetChild(5).gameObject;
        gameOverScreen.SetActive(false);
        state = GameState.Paused;
    }

    public void EndGame(bool win){
        state = GameState.GameOver;
        for (int i = 0; i < canvas.transform.childCount; i++){
            if (canvas.transform.GetChild(i).gameObject != gameOverScreen){
                canvas.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        if (!win){
            gameOverScreen.SetActive(true);
            // disable all other panels under canvas
        } else {
            gameOverScreen.SetActive(true);
            gameOverText.GetComponent<TextMeshProUGUI>().text = "You Win!";
            gameStatusText.GetComponent<TextMeshProUGUI>().text = "You have defeated the Singularity! It wasn't as powerful as you were taught to believe.";
            replayButton.GetComponentInChildren<TextMeshProUGUI>().text = "Play Again";
        }
    }


    public enum Skill{
        Invis,
        Heal,
        Hardened,
        Damage,
        Speed,
        WeaponAugment,
    }

    public enum GameState{
        Playing,
        Paused,
        GameOver,
    }

}
