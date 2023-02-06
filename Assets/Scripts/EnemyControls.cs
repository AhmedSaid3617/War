using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    public Vector3 gravity = new Vector3(0, -30f, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Gravity
        if (transform.position.y > 1.534) {
            gameObject.GetComponent<Rigidbody>().AddForce(gravity, ForceMode.Acceleration);
        }
    }
}
