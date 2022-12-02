using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class StoveSelector : MonoBehaviour, IDropHandler
{
    // to store which eye is being used, assigned from inspector
    [SerializeField] private int eyeID;
    
    //to change color of stove eye when pot is on top
    //DragAndDrop is for the GameObject Pot
    [SerializeField] private Image stoveImage;
    [SerializeField] private DragAndDrop _DragAndDrop;
    private MinigameManager _minigameManager;
    

    // to take damage to energy bar
     private EnergyBar _energyBar;
     public bool takeDamage;

    private void Start()
    {
        //automatically assign the energy bar
        _energyBar = FindObjectOfType<EnergyBar>();
        takeDamage = true;
        _minigameManager = FindObjectOfType<MinigameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if pot is on top of current stove by comparing ideas and change color accordingly
        if (_DragAndDrop.potID == eyeID)
        {
            GetComponent<Image>().color = new Color32(204,57,31,255);
            if (_DragAndDrop.potID == 1 || _DragAndDrop.potID == 0)
            {
                takeDamage = true;
            }
        }

        else
        {
            //if pot is on top of a small oven eye stop damage
            GetComponent<Image>().color = new Color32(59, 75, 75, 255);
            if (_DragAndDrop.potID == 2 || _DragAndDrop.potID == 3)
            {
                takeDamage = false;
                _minigameManager.wonGames[0] = 1;

            }
        }

        if (takeDamage)
        {
            _energyBar.TakeDamage(1);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item Dropped");
        if (eventData.pointerDrag != null)
        {
            //Stick pot to anchored points on eye
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                this.GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<DragAndDrop>().potID = eyeID;
        }
    }
}
