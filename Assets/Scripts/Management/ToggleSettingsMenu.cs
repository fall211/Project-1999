using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSettingsMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [HideInInspector] public bool isSettingsMenuOpen = false;


    private void Update(){
        HandleInput();
    }
    
    private void HandleInput(){
        if (!isSettingsMenuOpen) return;

        if (Input.GetKeyDown(KeyCode.Escape)){
            if (isSettingsMenuOpen){
                CloseSettingsMenu();
            } else {
                OpenSettingsMenu();
            }
        }
    }

    public void OpenSettingsMenu(){
        settingsPanel.SetActive(true);
        isSettingsMenuOpen = true;
    }
    private void CloseSettingsMenu(){
        settingsPanel.SetActive(false);
        isSettingsMenuOpen = false;
    }
}
