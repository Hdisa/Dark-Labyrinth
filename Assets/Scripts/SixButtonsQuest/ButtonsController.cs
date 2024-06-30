using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonsController : MonoBehaviour
{
    private int buttonsPressed = 0;
    
    [SerializeField] private RockDoor door; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonPressed()
    {
        buttonsPressed++;
        
        if (buttonsPressed == 1 )
        {
            door.enabled = true;
        }
    }
    public void ButtonReleased()
    {
        buttonsPressed--;
        
    }
}
