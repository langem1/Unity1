using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    [SerializeField]
    Vector3 rotationW;
    [SerializeField]
    Vector3 rotationO;
    [SerializeField]
    Vector3 rotationN;
    [SerializeField]
    Vector3 rotationS;

    [SerializeField]
    KeyCode keyRight;
    [SerializeField]
    KeyCode keyLeft;
    [SerializeField]
    KeyCode keyUp;
    [SerializeField]
    KeyCode keyDown;    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(keyLeft))
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(rotationW);

        if (Input.GetKey(keyRight))
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(rotationO);
        
        if (Input.GetKey(keyUp))
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(rotationN);
        
        if (Input.GetKey(keyDown))
            GetComponent<Rigidbody>().rotation = Quaternion.Euler(rotationS);
    
    }
}
