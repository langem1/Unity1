using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Danger_Level1 : MonoBehaviour
{
    [SerializeField]
    private float _dangerSpeed = 3f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
             _dangerSpeed *= -1;
        }
        
        if (other.CompareTag("Obstacle"))
        {
            _dangerSpeed *= -1;
        }

        if (other.CompareTag("Player"))
        {
            _dangerSpeed *= -1;
            other.GetComponent<Player_Script>().Damage();
        }
        
    }
}
