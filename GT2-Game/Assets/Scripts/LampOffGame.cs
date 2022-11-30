using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class LampOffGame : MonoBehaviour
{

    public Sprite LampOff;
    private EnergyBar _energyBar;


    private void Start()
    {
        //automatically assign the energy bar
        _energyBar = EnergyBar.FindObjectOfType<EnergyBar>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = LampOff;
            _energyBar.TakeDamage(1);

        }

    }


}
