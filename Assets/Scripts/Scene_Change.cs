using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change : MonoBehaviour
{
    // if player has collected three items, sent to level 2
    // if player has collected six items, sent to level 3
    // if player has collected nine items, won and game over
    // in all levels - if player has not selected three items, reminder to do so
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Player_Script>()._items == 3)
            {
                SceneManager.LoadScene(1);
            }
            
            if (other.GetComponent<Player_Script>()._items == 6)
            {
                SceneManager.LoadScene(2);
            }
            
            if (other.GetComponent<Player_Script>()._items == 9)
            {
                GetComponent<Player_Script>().OnPlayerWin();
            }
            
            else
            {
                GetComponent<UI_Manager>().Reminder();
            }
        }
        
    }
    
}
