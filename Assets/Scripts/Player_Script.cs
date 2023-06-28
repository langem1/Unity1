using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour
{
    // Variables
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
    public int _lives = 5;
    public float _clock = 45f;
//    private bool _alive = true;
//    private bool _win = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _uiManager.UpdateTime(_clock);
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
        
        Timer();

    }
    
    // if player falls down, bring him pack to the start position, count the times he had fallen towards damage
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
                OnPlayerDeath();
            }
        }
    }
    
    // countdown in seconds - if clock reaches zero, game over
    public void Timer()
    {
        if (_clock >= 0.0f)
        {
            _clock -= Time.deltaTime;
            float seconds = Mathf.FloorToInt(_clock % 60);
            _uiManager.UpdateTime(seconds);
        }
        else
        { 
            OnPlayerDeath();
            _clock = 0;
        }
    }
    
    // if player contacts danger elements, losing one life
    public void Damage()
    {
        _lives -= 1;
        _uiManager.UpdateLives(_lives);

        if(_lives == 0)
        {
            _lives = 0;
            OnPlayerDeath();
        }

    }
    
    // collecting items
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            _items += 1;
            _uiManager.UpdateItems(_items);
        }
        
    }

    // game over
    public void OnPlayerDeath()
    {
        _uiManager.GameOver();
    }
    
    // winning
    public void OnPlayerWin()
    {
        _uiManager.Winning();
    }
    
}
