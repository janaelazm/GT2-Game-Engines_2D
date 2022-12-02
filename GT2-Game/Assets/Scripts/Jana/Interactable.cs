using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private int miniGame_ID;
    private MinigameManager _minigameManager;
    private Color oriColor;


    private void Start()
    {
        _minigameManager = FindObjectOfType<MinigameManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        oriColor = _spriteRenderer.color;
    }

    private void OnMouseEnter()
    {
        _spriteRenderer.color = Color.yellow;
    }

    private void OnMouseExit()
    {
       _spriteRenderer.color = oriColor;
    }

    private void OnMouseDown()
    {
        Debug.Log("mouse clicked!");
        _minigameManager.StartMinigames(miniGame_ID);
    }
}
