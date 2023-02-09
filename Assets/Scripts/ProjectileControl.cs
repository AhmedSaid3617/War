using UnityEngine;

public class ProjectileControl : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explosionForce=100;
    public float explosionRadius=2;

    void OnCollisionEnter(Collision other){
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        if (other.gameObject.tag != "Ground"){
            other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, other.transform.position, explosionRadius);
        }
        Destroy(gameObject);
    }


    
}
