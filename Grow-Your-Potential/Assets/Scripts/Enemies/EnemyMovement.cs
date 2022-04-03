using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed;
    public float targetDistance;
    private Rigidbody2D rb;
    private GameObject player;
    private bool isLocked = false;
    private Vector3 direction;

    void move(){
        if (!isLocked){
            Vector3 posDiff = player.transform.position - gameObject.transform.position;
            rb.velocity = posDiff.normalized * movementSpeed;
        }
        else{
            rb.velocity = direction.normalized * movementSpeed;
        }
    }

    public IEnumerator LockDirection(float time){
        Debug.Log("Locked direction is called");
        direction = rb.velocity;
        isLocked = true;
        yield return new WaitForSeconds(time);
        Debug.Log("End lock");
        isLocked = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        isLocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 currPos = gameObject.transform.position;
        Vector3 posDiff = playerPos - currPos;
        if (Mathf.Abs(posDiff.magnitude) < targetDistance){
            move();
        }
        else{
            rb.velocity = Vector2.zero;
        }
    }
}
