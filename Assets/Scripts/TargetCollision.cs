using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision other){
        if (other.gameObject.name == "Projectile(Clone)"){
            Debug.Log("Hit");
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        }
    }
}
