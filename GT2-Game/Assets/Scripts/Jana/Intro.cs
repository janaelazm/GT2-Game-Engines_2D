using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    [SerializeField] private Button skip;
    [SerializeField] private AudioSource pageTurn;
    [SerializeField] private GameObject checklist;
    
    // Start is called before the first frame update
    void Start()
    {
        skip.onClick.AddListener(CloseList);
    }

    public void CloseList()
    {
        checklist.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
        
    
}
