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
    
    // to take damage to energy bar
     private EnergyBar _energyBar;

    private void Start()
    {
        //automatically assign the energy bar
        _energyBar = EnergyBar.FindObjectOfType<EnergyBar>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if pot is on top of current stove by comparing ideas and change color accordingly
        if (_DragAndDrop.potID == eyeID)
        {
            GetComponent<Image>().color = new Color32(219, 149, 75, 255);
            if (_DragAndDrop.potID == 1 || _DragAndDrop.potID == 0)
            {
                _energyBar.TakeDamage(1);
            }
        }

        else
        {
            GetComponent<Image>().color = new Color32(59, 75, 75, 255);
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
