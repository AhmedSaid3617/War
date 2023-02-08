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
    public GameObject crossHairs;
    

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
        mainCamera.localPosition = new Vector3(0.1f,0.117f,-1.86f);
        mainCamera.localEulerAngles = new Vector3(274.847534f,179.405991f,180.513626f);
        crossHairs.SetActive(true);
    }

    void UnAim(){
        mainCamera.localPosition = freeAimPos;
        mainCamera.localEulerAngles = freeAimAngle;
        crossHairs.SetActive(false);
    }
}
