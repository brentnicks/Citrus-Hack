using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "Enemy" )
        {
            Debug.Log("Weapon collided");
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
