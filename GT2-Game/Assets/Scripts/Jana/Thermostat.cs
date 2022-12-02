using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Thermostat : MonoBehaviour
{
    [SerializeField] private Button up;
    [SerializeField] private Button down;
    [SerializeField] private TextMeshProUGUI temprature;
    private int degrees;
    private EnergyBar _energyBar;
    public bool takeDamage;
    private MinigameManager _minigameManager;

    // Start is called before the first frame update
    void Start()
    {
        takeDamage = true;
        degrees = 25;
        temprature.text = degrees + "°  C  ";
        _energyBar = FindObjectOfType<EnergyBar>();
        up.onClick.AddListener(UpClicked);
        down.onClick.AddListener(DownClicked);
        _minigameManager = FindObjectOfType<MinigameManager>();
    }

    //Deal damage if degrees is more than 16C
    private void Update()
    {
        if (takeDamage)
        {
            _energyBar.TakeDamage(1);
        }

        if (16 >= degrees)
        {
            takeDamage = false;
            _minigameManager.wonGames[1] = 1;
        }
    }

    //reduce temp if bigger than zero
    private void DownClicked()
    {
        Debug.Log("clicked down");
        if (degrees > 0)
        {
            degrees -= 1;
            temprature.text = degrees + "°  C  ";
        }
    }
    
    
    //increase temp if smaller than 30
    private void UpClicked()
    {
        Debug.Log("clicked up");
        if (30 > degrees)
        {
            degrees += 1;
            temprature.text = degrees + "°  C  ";
        }
    }
}
