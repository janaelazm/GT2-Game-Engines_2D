using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Checklist : MonoBehaviour
{
    private Image checklist;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private Button skip;
    
    //Paper flip sound
    private float seconds = 30;
    private AudioSource _audio;

    //when closed = 1 show the checklist if bigger than that destroy object.
    private int _closed;
    
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _closed = 0;
        skip.onClick.AddListener(CloseList);
        if (_closed == 1)
        {
            _text.text = "Memorize the tasks you have " + seconds + "s!!!";
        }
        
    }
    
    void Update()
    {
        if (_closed == 1)
        {
            seconds -= Time.deltaTime;
            _text.text = "Memorize the tasks you have " + (int) seconds + " s!!! \n\n  The temprature shouldn't be more than 16C \n\n Don't place anything on heaters \n\n All devices should be disconnected if not in use \n\n Use the smaller Oven-Eye for cooking \n\n Turn off all lamps (hint: getting close to it is enough)";
        }

        else
        {
            _text.text =
                "We have an energy crisis, yikes!\n\nComplete the set of tasks to help you cut down on your waste or you're toast when the bill comes!\n\n\nGood Luck";
        }
    }

    private void CloseList()
    {

        _audio.PlayOneShot(_audioClip);
        if (_closed == 1)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, seconds);
            _closed += 1;
        }
    }
}

