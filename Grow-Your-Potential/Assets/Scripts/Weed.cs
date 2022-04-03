using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weed : MonoBehaviour
{
    public GameObject coin;
    public void RemoveWeed(){
        Instantiate(coin, gameObject.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
