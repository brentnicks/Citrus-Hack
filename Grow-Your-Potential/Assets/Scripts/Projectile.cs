using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public bool disappearOnHit;
    public int damage;
    public Vector3 direction;
    private Rigidbody2D rb;
    public GameObject player; 

    private void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Player"){
            Debug.Log("Projectile hit player");
        }
        if (disappearOnHit && coll.gameObject.tag != "Enemy" && coll.gameObject.tag != "Projectile" && coll.gameObject.layer == 0){
            Destroy(this.gameObject);
        }
    }

    public void SetDirection(){
        direction = player.transform.position - gameObject.transform.position; 
        // rb.velocity = direction.normalized * speed;
        // transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg);
        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
    }

    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * speed;
        // transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.Euler(rb.velocity.normalized);
    }
}
