using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float mouseX;
    float mouseY;
    bool yOutOfRange;
    Vector3 freeAimAngle;
    Vector3 freeAimPos;
    public Transform mainCamera; 
    public float mouseSensitivityX = 100;
    public float mouseSensitivityY = 50;
    public GameObject barrelStart;
    

    void Start(){
        barrelStart = GameObject.Find("Barrel Start");
        freeAimAngle = mainCamera.localEulerAngles;
        freeAimPos = mainCamera.localPosition;
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

        if (Input.GetMouseButtonDown(1)){
            Aim();
        }
        else if (Input.GetMouseButtonUp(1)){
            UnAim();
        }
        
    }

    void Aim(){
        mainCamera.localPosition = new Vector3(0,-0.94f,-3.19f);
        mainCamera.localEulerAngles = new Vector3(276.174f,188.24f,171.73f);
    }

    void UnAim(){
        mainCamera.localPosition = freeAimPos;
        mainCamera.localEulerAngles = freeAimAngle;
    }
}
