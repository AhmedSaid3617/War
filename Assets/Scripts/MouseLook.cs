using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float mouseX;
    float mouseY;
    bool yOutOfRange;
    public float mouseSensitivityX = 100;
    public float mouseSensitivityY = 50;
    public GameObject barrelStart;

    void Start(){
        barrelStart = GameObject.Find("Barrel Start");
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);
        yOutOfRange = barrelStart.transform.rotation.eulerAngles.x > 0;
        if (yOutOfRange){

        }
        barrelStart.transform.Rotate(Vector3.left * mouseY);
    }
}
