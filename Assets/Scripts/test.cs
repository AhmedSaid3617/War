using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    void OnCollisionEnter(Collision other){
        if (other.gameObject.name == "Projectile(Clone)"){
            Debug.Log("Hit");
        }
    }
}
