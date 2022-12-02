using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup[] minigames;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button startGame;
    public int[] wonGames; 
    private EnergyBar _energyBar;
    private PlayerController _controller;

    private void Start()
    {
        _controller = FindObjectOfType<PlayerController>();
        _energyBar = FindObjectOfType<EnergyBar>();
        DisableMinigame();
        startGame.onClick.AddListener(EnableMinigame); 
        closeButton.onClick.AddListener(FinishMinigames);
        wonGames = new[] {0, 0, 0, 0, 0, 0, 0};


    }


    private void Update()
    {
        if (!wonGames.Contains(0))
        {
            _energyBar.youWin();
        }
    }
    
    //completely activate games and close button
    //used after start button is pushed
    private void EnableMinigame()
    {
        foreach (var t in minigames)
        {
            t.gameObject.SetActive(true);
        }
        closeButton.gameObject.SetActive(true);
        FinishMinigames();

    }
    
    //completely deactivate games and close button
    //disable all games before start is clicked to prevent damage to energy bar
    private void DisableMinigame()
    {

        foreach (var t in minigames)
        {
            t.gameObject.SetActive(false);
        }
        closeButton.gameObject.SetActive(false);
    }

    //will start game and prevent the minigame panel from affecting other panels
    public void StartMinigames(int id)
    {
        //disable movment when minigame is opened
        _controller.DisableMovement();
        minigames[id].blocksRaycasts = true;
        minigames[id].alpha = 1;
        closeButton.gameObject.SetActive(true);
    }

    //to close panel of minigame
    private void FinishMinigames()
    {
        for(int i = 0; i < minigames.Length; i++)
        {
            minigames[i].blocksRaycasts = false;
            minigames[i].alpha = 0;
        }
        
        // to start player movement when minigame is finished
        _controller.EnableMovement();
        closeButton.gameObject.SetActive(false);
    }
    
}
