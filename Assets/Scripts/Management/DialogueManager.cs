using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public static DialogueManager instance;
    public GameObject dialoguePanel;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public float[] displayTime;
    private float _timeDisplayed = 0;

    public List<int> dialogueQueue = new();
    private int index;
    public float typingSpeed = 0.02f;
    public bool typing = false;



    private void Awake() {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }
    void Start(){
        textDisplay.text = "";

    }

    private void Update()
    {
        if (dialogueQueue.Count > 0 && TopDownManager.Instance.state == TopDownManager.GameState.Playing)
        {
            dialoguePanel.SetActive(true);
            index = dialogueQueue[0];
            if (textDisplay.text == ""){
                TypeSentence(sentences[index]);
            }
            if (textDisplay.text == sentences[index]){
                _timeDisplayed += Time.deltaTime;
                if (_timeDisplayed >= displayTime[index]){
                    _timeDisplayed = 0;
                    dialogueQueue.RemoveAt(0);
                    textDisplay.text = "";
                    if (dialogueQueue.Count == 0) typing = false;
                }
            }

        }
        else
        {
            textDisplay.text = "";
            dialoguePanel.SetActive(false);
        }
    }

    private async void TypeSentence(string sentence)
    {
        typing = true;
        textDisplay.text = "";
        foreach (char letter in sentence)
        {
            textDisplay.text += letter;
            await System.Threading.Tasks.Task.Delay((int)(typingSpeed * 1000));
        }
    }

    public void AddToDialogueQueue(int i){
        dialogueQueue.Add(i);
    }
}
