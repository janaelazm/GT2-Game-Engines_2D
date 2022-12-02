using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    // to change color of energy bar depending on points
    public Gradient gradient;
    [SerializeField] private Image fill;
    [SerializeField] private Button start;
    [SerializeField] private CanvasGroup deathScreen;
    [SerializeField] private TextMeshProUGUI youWinText;
    public int currentEnergy;

    // Start is called before the first frame update
    void Start()
    {
        //set max energy value and set current energy to full
        SetMaxEnergy(50000);

    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnergy == 0)
        {
            Time.timeScale = 0;
            deathScreen.alpha = 1;
            deathScreen.interactable = true;
            deathScreen.blocksRaycasts = true;

        }

        //currentEnergy = -1 only when all games are won, use same screen as death but text is changed
        if (currentEnergy == -1)
        {
            Time.timeScale = 0;
            deathScreen.alpha = 1;
            deathScreen.interactable = true;
            deathScreen.blocksRaycasts = true;

        }
        
    }

    //Deduct energy points, called from minigames
    public void TakeDamage(int damage)
    {
        currentEnergy = currentEnergy - damage;
        SetEnergy(currentEnergy);
    }

    private void SetMaxEnergy(int max)
    {
        slider.maxValue = max;
        slider.value = max;
        currentEnergy = max;
        fill.color = gradient.Evaluate(1f);
    }
    
    
    private void SetEnergy(int energy)
    {
        slider.value = energy;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void youWin()
    {
        currentEnergy = -1;
        youWinText.text = "YOU WON";
    }
}
