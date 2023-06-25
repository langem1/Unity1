using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Player_Script>()._items == 3)
            {
                SceneManager.LoadScene(1);
//                GetComponent<Player_Script>().onPlayerWin();
            }

            else
            {
                Debug.Log("You need 3 items!");
            }
            
            if (other.GetComponent<Player_Script>()._items == 6)
            {
                SceneManager.LoadScene(2);
                GetComponent<Player_Script>().onPlayerWin();
            }

        }
        
    }
    
}
