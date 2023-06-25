using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _livestext;
    
    [SerializeField]
    private Text _itemstext;
    
    [SerializeField]
    private Text _clock;
    
    [SerializeField] 
    private Text _statustext;

    // DEFINE WIN & GAME OVER TEXT
    public void gameOver()
    {
        _statustext.text = "You dead";
        Debug.Log(message: "You dead");
    }
    
    public void win()
    {
        _statustext.text = "YAAYY! Not dead!";
    }
    
    public void UpdateLives(int health)
    {
        _livestext.text = "Lives: " + health;
    }
    
    public void UpdateItems(int collector)
    {
        _itemstext.text = "Items: " + collector;
    }    
    
    public void UpdateTime(float time)
    {
        _clock.text = "Time: " + time;
    }
    
}
