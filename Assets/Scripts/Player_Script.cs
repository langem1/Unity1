using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    //Variables
    [SerializeField]
    private Rigidbody RB;
    
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
/*    
    // Start is called before the first frame update
    void Start()
    {
        
    }
*/
    // Update is called once per frame

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
        Teleport();
    }

    public void Teleport()
    {
        if(transform.position.y < -10)
        {
            transform.position = new Vector3(0f, 2f, 0f);
            _lives -= 1;
            Debug.Log("Gefallen " + _lives);
        }
    }

    public void Damage()
    {
        _lives -= 1;
        Debug.Log("Angegriffen "+ _lives);

        if(_lives == 0)
        {
            Debug.Log("Toooood");
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        // Collect Items
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            _items += 1;
            Debug.Log("Items " + _items);
        }
        
    }
    
}
