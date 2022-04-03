using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public GameObject enemy;
    public float slashTime = 0.1f;
    public GameObject something; 
    public float knockback = 100f; 
    public int damage; 
    public bool isActive = false;
    private Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        if (isActive){
            Destroy(gameObject, slashTime);
            rb = gameObject.GetComponent<Rigidbody2D>();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "Enemy" )
        {
            collision.gameObject.GetComponent<EnemyCombat>().takeDamage(damage);
            Vector3 direction = collision.transform.position - transform.position;
            direction.y = 0; 
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction.normalized * knockback, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
