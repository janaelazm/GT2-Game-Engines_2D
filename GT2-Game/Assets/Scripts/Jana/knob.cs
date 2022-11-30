using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class knob : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image frame;
    [SerializeField] private Sprite[] windowState;
    public float _angle;

    private void Start()
    {
        _angle = 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_angle >= 180)
        {
            _angle -= 90;
        }
        
        else
        {
            _angle += 90;
        }

        frame.sprite = _angle switch
        {
            0 => windowState[0],
            90 => windowState[1],
            180 => windowState[2],
            _ => frame.sprite
        };
    }
}
