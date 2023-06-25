using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour
{
    //Variables
    [SerializeField]
    private Rigidbody RB;
    
    [SerializeField]
    private UI_Manager _uiManager;

    [SerializeField]
    Vector3 playerMovementLR;
    
    [SerializeField]
    Vector3 playerMovementUpDown;

    [SerializeField]
    KeyCode keyRight;
    [SerializeField]
    KeyCode keyLeft;
    [SerializeField]
    KeyCode keyUp;
    [SerializeField]
    KeyCode keyDown;
    [SerializeField]
    KeyCode keyStop;
    
    public int _items;
    private int _lives = 5;
    public float clock = 30f;
    public float seconds;
    private bool _alive = true;
    private bool _win = false;
    
    // Start is called before the first frame update
    
    void Start()
    {
//        _uiManager.UpdateLives(_lives);
//        _uiManager.UpdateItems(_items);
        _uiManager.UpdateTime(clock);
    }
    
    // Update is called once per frame

    void Update()
    {
        // assign keys to movement
        if (Input.GetKey(keyRight))
            GetComponent<Rigidbody>().velocity += playerMovementLR;

        if (Input.GetKey(keyLeft))
            GetComponent<Rigidbody>().velocity -= playerMovementLR;
        
        if (Input.GetKey(keyUp))
            GetComponent<Rigidbody>().velocity += playerMovementUpDown;
        
        if (Input.GetKey(keyDown))
            GetComponent<Rigidbody>().velocity -= playerMovementUpDown;

        if (Input.GetKey(keyStop))
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        
        Teleport();
        
        // Timer
        if (clock >= 0.0f)
        {
            clock -= Time.deltaTime;
            seconds = Mathf.FloorToInt(clock % 60);
            _uiManager.UpdateTime(seconds);
        }
        else
        {
            onPlayerDeath();
            clock = 0;
        }
    }

    // TELEPORT - if player falls down, bring him pack to the start position, count the times he had fallen
    public void Teleport()
    {
        if(transform.position.y < -10)
        {
            transform.position = new Vector3(0f, 2f, 0f);
            _lives -= 1;
            _uiManager.UpdateLives(_lives);

            if(_lives == 0)
            {
                _lives = 0;
                onPlayerDeath();
            }
        }
    }
    
    public void Damage()
    {
        _lives -= 1;
        _uiManager.UpdateLives(_lives);

        if(_lives == 0)
        {
            _lives = 0;
            onPlayerDeath();
        }

    }
    
    // Collecting  Items
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            _items += 1;
            _uiManager.UpdateItems(_items);
        }
        
    }

    // DEFINE WIN & LOOSING STATE
    public void onPlayerDeath()
    {
        _alive = false; 
        _uiManager.gameOver();
    }
    
    public void onPlayerWin()
    {
        _win = true;
        _uiManager.win();
    }
    
}
