using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }
    [HideInInspector] public bool hasInvisSkill = false;
    [HideInInspector] public bool hasHealthSkill = false;
    public List<String> unlockedGames = new();
    void Awake() {
        if (Instance != null && Instance != this) Destroy(this.gameObject);
        else Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    void Start() {
        unlockedGames.Add("Puzzle");
    }

    public void UnlockGame(string game){
        if (!unlockedGames.Contains(game)){
            unlockedGames.Add(game);
        }
    }
}
