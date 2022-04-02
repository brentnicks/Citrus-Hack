using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed;
    public float targetDistance;
    private Rigidbody2D rb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 currPos = gameObject.transform.position;
        Vector3 posDiff = playerPos - currPos;
        Debug.Log(posDiff.magnitude);
        if (Mathf.Abs(posDiff.magnitude) < targetDistance){
            rb.velocity = posDiff.normalized * movementSpeed;
        }
        else{
            rb.velocity = Vector2.zero;
        }
    }
}