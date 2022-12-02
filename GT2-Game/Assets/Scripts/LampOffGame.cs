using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LampOffGame : MonoBehaviour
{

    public Sprite LampOff;
    private EnergyBar _energyBar;
    public bool takeDamage;
    [SerializeField] private Button start;
    [SerializeField] private int ID;
    private MinigameManager _minigameManager;


    private void Start()
    {
        start.onClick.AddListener(StartGame);
        _minigameManager = FindObjectOfType<MinigameManager>();
    }

    private void Update()
    {
        if (takeDamage)
        {
            _energyBar.TakeDamage(1);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = LampOff;
            takeDamage = false;
            _minigameManager.wonGames[ID] = 1;

        }

    }


    private void StartGame()
    {
        takeDamage = true;
        //automatically assign the energy bar
        _energyBar = EnergyBar.FindObjectOfType<EnergyBar>();
    }
    
}
