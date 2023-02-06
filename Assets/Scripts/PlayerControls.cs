using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    GameObject player; 
    Rigidbody playerRb; 
    public GameObject projectilePrefab;
    public Transform canon;
    public Transform barrelEnd;
    public float projectileSpeed = 20;
    public float forwardForce = 200;
    public float backwardForce = 100;
    public float torque = 30;
    public Vector3 gravity = new Vector3(0, -30f, 0);
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerRb = player.GetComponent<Rigidbody>();
        barrelEnd = GameObject.Find("Barrel End").transform;
        canon = GameObject.Find("Canon").transform;
    }

    void Update()
    {
        //Gravity
        if (transform.position.y > 1.533) {
            playerRb.AddForce(gravity, ForceMode.Acceleration);
        }
        //Forward.
        if (Input.GetKey("w")){
            playerRb.AddRelativeForce(Vector3.forward * forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        //Back.
        else if (Input.GetKey("s")){
            playerRb.AddRelativeForce(Vector3.back * backwardForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        //Rotate right.
        if (Input.GetKey("d")){
            playerRb.AddTorque(Vector3.up * torque * Time.deltaTime, ForceMode.VelocityChange);
        }
        else if (Input.GetKey("a")){
            playerRb.AddTorque(Vector3.down * torque * Time.deltaTime, ForceMode.VelocityChange);
        }
        
        //Fire.
        if (Input.GetKeyDown("left ctrl")){
            Fire();
        }
    }

    void Fire(){
        Rigidbody projClone = Instantiate(projectilePrefab.GetComponent<Rigidbody>(), barrelEnd.position, canon.rotation);
        projClone.AddRelativeForce(projectileSpeed * Vector3.up, ForceMode.Impulse);
    }
}
