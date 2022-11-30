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
    
    // Start is called before the first frame update
    void Start()
    {
        degrees = 25;
        temprature.text = degrees + "°  C  ";
        //_energyBar = FindObjectOfType<EnergyBar>();
        
        up.onClick.AddListener(delegate { upClicked(); });
        down.onClick.AddListener(delegate { downClicked(); });
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void downClicked()
    {
        degrees -= 1;
        temprature.text = degrees + "°  C  ";
    }
    
    private void upClicked()
    {
        degrees += 1;
        temprature.text = degrees + "°  C  ";
    }
}
