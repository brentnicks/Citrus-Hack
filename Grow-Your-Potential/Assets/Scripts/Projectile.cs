using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public bool disappearOnHit;
    public Vector3 direction;
    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Player"){
            Debug.Log("Projectile hit player");
        }
        if (disappearOnHit && coll.gameObject.tag != "Enemy"){
            Destroy(this.gameObject);
        }
    }

    public void SetDirection(Vector3 newDirection){
        direction = newDirection;
        rb.velocity = direction.normalized * speed;
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg);
    }

    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * speed;
        // transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.Euler(rb.velocity.normalized);
    }
}
