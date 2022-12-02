using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BarGame : MonoBehaviour
{
    [SerializeField] private Image slider; //Position Indicator moves left and right
    [SerializeField] private Button hit; // when clicked makes slider stop
    // to manipulate target area and slider position
    [SerializeField] private RectTransform _rectTransformSlider; 
    [SerializeField] private RectTransform _rectTransformTarget;

    //game manger for Win screen checks
    private MinigameManager _minigameManager;
    
    //to deal damage to energy bar
    private EnergyBar _energyBar;
    
    //booleans for checks
    private bool targetHit;
    public bool takeDamage;
    private bool reachedEnd;
    
    private float currentPos;
    private float targetPos;
    private float _minPos = 0;
    private float _maxPos = 100;


    // Start is called before the first frame update
    void Start()
    {
        _energyBar = FindObjectOfType<EnergyBar>();
        hit.onClick.AddListener(SetTarget);
        Init();
        _minigameManager = FindObjectOfType<MinigameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (takeDamage)
        {
            _energyBar.TakeDamage(1);
        }
        
        
        switch (targetHit)
        {
            //if target isn't set slider moves right to left at using speed and deltaTime
            //reached end to start decrement after slider has reached end of bar
            case false:
            {
                float oldPos = _rectTransformSlider.anchoredPosition.x;
                float speed = 125;
                if (reachedEnd)
                {
                    _rectTransformSlider.anchoredPosition = new Vector2(oldPos-Time.deltaTime*speed, 0);
                    if (_rectTransformSlider.anchoredPosition.x <= _minPos)
                    {
                        reachedEnd = false;
                    }
                }
                
                if (!reachedEnd)
                {
                    _rectTransformSlider.anchoredPosition = new Vector2(oldPos+Time.deltaTime*speed, 0);
                    if (_maxPos <= _rectTransformSlider.anchoredPosition.x)
                    {
                        reachedEnd = true;
                    }
                }
                
                
                break;
            }
            
            //if target is hit check if slide is within target area if yes stop taking damage otherwise repeat init()
            case true:
                float targetPosMin = targetPos - 7;
                float targetPosMax = targetPos + 7;

                if (targetPosMax > _maxPos)
                {
                    targetPosMax = _maxPos;
                }

                if (targetPosMin < _minPos )
                {
                    targetPosMax = _minPos;
                }
                
                if (currentPos >= targetPosMin && targetPosMax >= currentPos)
                {
                    takeDamage = false;
                    _minigameManager.wonGames[2] = 1;
                }
                else
                {
                    Init();
                    Debug.Log("try again");
                }
                break;
        }
    }

    private void SetTarget()
    {
        currentPos = _rectTransformSlider.anchoredPosition.x;
        targetHit = true;
    }

    //get random position for target
    //initialize all other variables 
    private void Init()
    {
        Debug.Log("init");
        takeDamage = true;
        targetHit = false;
        reachedEnd = false;
        currentPos = 0;
        targetPos = Random.Range(0f, 100f);
        _rectTransformTarget.anchoredPosition = new Vector2(targetPos, 0);
        _rectTransformSlider.anchoredPosition = new Vector2(0,0);
    }
}

