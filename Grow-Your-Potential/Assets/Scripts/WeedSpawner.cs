using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedSpawner : MonoBehaviour
{
    public GameObject weed; 
    // Start is called before the first frame update
    void Start()
    {
        spawnWeeds();
    }

    public void spawnWeeds()
    {
        int x = Random.Range(10, 15);
        for ( int i = 0; i < x; i++ )
        {
            transform.position = new Vector2(Random.Range(-11, 11), Random.Range(-12, 1));
            Instantiate(weed, transform.position, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
