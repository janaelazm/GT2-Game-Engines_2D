using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shirt : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI click;
    private EnergyBar _energyBar;
    private RectTransform _rectTransform;
    private int numOfClicks;
    private bool takeDamage;
    [SerializeField] private SpriteRenderer shirtSprite;

    // Start is called before the first frame update
    void Start()
    {
        _energyBar = FindObjectOfType<EnergyBar>();
        takeDamage = true;
        numOfClicks = 0;
        _rectTransform = GetComponent<RectTransform>();
        click.alpha = 0;

    }

    private void Update()
    {
        if (takeDamage)
        {
            _energyBar.TakeDamage(1);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (numOfClicks == 0)
        {
            click.alpha = 255;
        }

        if (numOfClicks % 2 == 0)
        {
            Vector3 shakeLeft = new Vector3(_rectTransform.position.x - 5, _rectTransform.position.y,
                _rectTransform.position.z);
            _rectTransform.transform.position = shakeLeft;
        }

        if (numOfClicks % 2 != 0)
        {
            Vector3 shakeRight = new Vector3(_rectTransform.position.x + 5, _rectTransform.position.y,
                _rectTransform.position.z);
            _rectTransform.transform.position = shakeRight;
        }

        numOfClicks += 1;

        if (numOfClicks > 15)
        {
            Destroy(shirtSprite);
            Destroy(gameObject);
        }

    }
}
