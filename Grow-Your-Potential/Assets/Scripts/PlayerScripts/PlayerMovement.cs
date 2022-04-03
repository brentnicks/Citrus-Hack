using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float health = 100;
    public GameObject healthBar;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        healthBar.GetComponent<Text>().text = "Health: " + health;
    }
    private void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
    }
}
