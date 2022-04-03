using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private GameObject enemy; 
    public GameObject sword; 
    public float slashTime = 0.5f; 

    public void takeDamage(){

    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    //public void takeDamage(); 

    // Update is called once per frame
    void Update()
    {
        // Vector3 mousePos = Input.mousePosition;
        // //Debug.Log(Input.mousePosition);         
        // //Vector3 objectPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
        // mousePos.z = Camera.main.nearClipPlane;
        // Vector2 direction = (Vector2)((mousePos - transform.position));
        // direction.Normalize(); 
        // Vector3 worldPosition = Camera.main.ScreenToWorldPoint(direction);
        // if ( Input.GetKeyDown("p") )
        // {
        //     Instantiate(testObject, worldPosition, Quaternion.identity);
        //     Destroy(testObject, 2f);
        // }
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (Vector2)((worldMousePos - transform.position));
            direction.Normalize();
            Instantiate(sword, transform.position + (Vector3)(direction * 0.5f), Quaternion.identity);
        }
    }
}
