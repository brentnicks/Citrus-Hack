using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerAnimations : MonoBehaviour{
    private Animator anim;
    void Start(){
        anim = gameObject.GetComponent<Animator>();
    }
    void Update(){
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // if (Input.GetAxis("Vertical") < 0){
        if (worldMousePos.y < transform.position.y){
            anim.Play("farmerIdle");
        }
        // else if (Input.GetAxis("Vertical") > 0){
        else if (worldMousePos.y > transform.position.y){
            anim.Play("farmerUp");
        }
        // else if (Input.GetAxis("Horizontal") < 0){
        else if (worldMousePos.x < transform.position.x){
            anim.Play("farmerLeft");
        }
        // else if (Input.GetAxis("Horizontal") > 0){
        else if (worldMousePos.x > transform.position.x){
            anim.Play("farmerRight");
        }
    }
}
