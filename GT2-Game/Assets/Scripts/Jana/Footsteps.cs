using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    //Soundeffect for walking
    [SerializeField] private AudioSource steps;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D))
        {
            steps.enabled = true;
            steps.volume = 100;
        }
        else
        {
            steps.enabled = false;
        }
    }
}
