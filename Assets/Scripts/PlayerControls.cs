using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    GameObject player;
    Rigidbody playerRb;

    public Transform canon;
    public Transform barrelEnd;
    public GameObject projectilePrefab;
    public float forwardForce = 200;
    public float backwardForce = 100;
    public float torque = 30;
    public Vector3 gravity = new Vector3(0, -30f, 0);
    public Transform mainCamera;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerRb = player.GetComponent<Rigidbody>();
        barrelEnd = GameObject.Find("Player Barrel End").transform;
        canon = GameObject.Find("Player Canon").transform;
        mainCamera = GameObject.Find("Main Camera").transform;
    }

    void Update()
    {
        //Gravity
        playerRb.AddForce(gravity * Time.deltaTime, ForceMode.Acceleration);

        //Forward.
        if (Input.GetKey("w"))
        {
            playerRb.AddRelativeForce(Vector3.forward * forwardForce * Time.deltaTime, ForceMode.VelocityChange);
            if (Input.GetKey("d") && playerRb.velocity.magnitude > 0.1f)
            {
                playerRb.AddTorque(Vector3.up * torque * Time.deltaTime, ForceMode.VelocityChange);
            }
            else if (Input.GetKey("a") && playerRb.velocity.magnitude > 0.1f)
            {
                playerRb.AddTorque(Vector3.down * torque * Time.deltaTime, ForceMode.VelocityChange);
            }
        }
        //Back.
        else if (Input.GetKey("s"))
        {
            playerRb.AddRelativeForce(Vector3.back * backwardForce * Time.deltaTime, ForceMode.VelocityChange);
            if (Input.GetKey("d") && playerRb.velocity.magnitude > 0.1f)
            {
                playerRb.AddTorque(Vector3.down * torque * Time.deltaTime, ForceMode.VelocityChange);
            }
            else if (Input.GetKey("a") && playerRb.velocity.magnitude > 0.1f)
            {
                playerRb.AddTorque(Vector3.up * torque * Time.deltaTime, ForceMode.VelocityChange);
            }
        }
        //Fire
        if (Input.GetKeyDown("left ctrl") || Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        Rigidbody projClone = Instantiate(projectilePrefab.GetComponent<Rigidbody>(), barrelEnd.position, canon.rotation);
        //projClone.AddRelativeForce(projectileSpeed * Vector3.up, ForceMode.Impulse);
    }



}
