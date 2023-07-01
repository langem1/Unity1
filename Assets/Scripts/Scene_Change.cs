using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Change : MonoBehaviour
{
    
    [SerializeField]
    private UI_Manager _uiManager;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // if player has collected three items, sent to level 2
            if (other.GetComponent<Player_Script>()._items == 3)
            {
                SceneManager.LoadScene(1);
            }
            
            // if player has collected six items, sent to level 3
            if (other.GetComponent<Player_Script>()._items == 6)
            {
                SceneManager.LoadScene(2);
            }
            
            // if player has collected nine items, won and game over
            if (other.GetComponent<Player_Script>()._items == 9)
            {
                other.GetComponent<Player_Script>().OnPlayerWin();
            }
            
            // in all levels - if player has not selected three items, reminder to do so
            else
            {
                _uiManager.Reminder();
            }
        }
        
    }
    
}
