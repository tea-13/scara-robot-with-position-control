using UnityEngine;
using System.Collections;
 
public class FlyCamera : MonoBehaviour 
{

    public float mainSpeed = 10.0f;
    public float camSens = 0.1f;
    public float mouseSens = 100f;
    private float xRot = 0f;
    private float yRot = 0f;
     
    void Update () {
        
        if (Input.GetKey(KeyCode.Mouse2)){
            float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

            xRot -= mouseY;
            //xRot = Mathf.Clamp(xRot, -90f, 90f);
            
            yRot += mouseX;
            //yRot = Mathf.Clamp(yRot, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRot, yRot, 0f);
        }

        transform.Translate(GetBaseInput() * mainSpeed * Time.deltaTime);
       
    }
     
    private Vector3 GetBaseInput() {
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey (KeyCode.W)){
            p_Velocity += new Vector3(0, 0 , 1);
        }
        if (Input.GetKey (KeyCode.S)){
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey (KeyCode.A)){
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey (KeyCode.D)){
            p_Velocity += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.Space)){ 
            p_Velocity += new Vector3(0, 1, 0);
        }
        if (Input.GetKey (KeyCode.LeftShift)){
            p_Velocity += new Vector3(0, -1, 0);
        }

        return p_Velocity;
    }
}