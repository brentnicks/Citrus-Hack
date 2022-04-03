using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public GameObject enemy;
    public float slashTime = 0.5f;
    public GameObject something; 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, slashTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "Enemy" )
        {
            collision.gameObject.GetComponent<EnemyCombat>().takeDamage();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
