using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerAnimations : MonoBehaviour{
    private Animator anim;
    void Start(){
        anim = gameObject.GetComponent<Animator>();
    }
    void Update(){
        if (Input.GetAxis("Vertical") < 0){
            anim.Play("farmerIdle");
        }
        else if (Input.GetAxis("Vertical") > 0){
            anim.Play("farmerUp");
        }
        else if (Input.GetAxis("Horizontal") < 0){
            anim.Play("farmerLeft");
        }
        else if (Input.GetAxis("Horizontal") > 0){
            anim.Play("farmerRight");
        }
    }
}
