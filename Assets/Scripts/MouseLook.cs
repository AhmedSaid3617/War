using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float mouseX;
    float mouseY;
    bool yInRange;
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
        barrelStart.transform.Rotate(Vector3.left * mouseY);
        Debug.Log(barrelStart.transform.localEulerAngles.x);

        // Stop camera from looking too high.
        if (barrelStart.transform.localEulerAngles.x < 328 && barrelStart.transform.localEulerAngles.x > 180){
            barrelStart.transform.localEulerAngles = new Vector3(-31.999f, 0, 0);
        }

        if (barrelStart.transform.localEulerAngles.x > 32 && 360 - barrelStart.transform.localEulerAngles.x > 180){
            barrelStart.transform.localEulerAngles = new Vector3(31.999f, 0, 0);
        }
        

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
