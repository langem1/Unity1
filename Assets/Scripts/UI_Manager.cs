using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    // variables
    [SerializeField]
    private Text _livestext;
    
    [SerializeField]
    private Text _itemstext;
    
    [SerializeField]
    private Text _clock;
    
    [SerializeField] 
    private Text _statustext;
    
    [SerializeField] 
    private Text _reminder;
    
    // number of lives
    public void UpdateLives(int health)
    {
        _livestext.text = "Lives: " + health;
    }
    
    // number of items
    public void UpdateItems(int collector)
    {
        _itemstext.text = "Items: " + collector;
    }

    // reminder to collect three items to get to the next level
    public void Reminder()
    {
        _reminder.text = "You need 3 items!";
    }
    
    // timer
    public void UpdateTime(float time)
    {
        _clock.text = "Time: " + time;
    }
    
    // game over text
    public void GameOver()
    {
        _statustext.text = "Game over!";
    }
        
    // winning text
    public void Winning()
    {
        _statustext.text = "YAY! You won!";
    }
}
