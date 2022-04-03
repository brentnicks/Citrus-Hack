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

    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * speed;
    }
}
