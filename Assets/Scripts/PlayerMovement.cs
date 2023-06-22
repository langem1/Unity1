using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
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

    int counter;
    
    void FixedUpdate()
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

        // TELEPORT - if player falls down, bring him pack to the start position, count the times he had fallen        
        if(transform.position.y < -10)
        {
            transform.position = new Vector3(0f, 2f, 0f);
            counter += 1;
        }

        // End the game when player had fallen down three times
        //if(counter == 3)
        //{

        //}
    }
}
