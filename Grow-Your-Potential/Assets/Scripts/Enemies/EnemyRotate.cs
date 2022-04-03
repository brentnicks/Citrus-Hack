using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( rb.velocity.x < 0 )
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else 
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
