using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger_forwards : MonoBehaviour
{
    [SerializeField]
    private float _dangerSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (_dangerSpeed * Time.deltaTime));
    }
    
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
