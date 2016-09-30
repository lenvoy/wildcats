using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 movementVector;
    private Vector3 rotationVector;
    private float movementSpeed = 4;
    public int joystickNum;
    private float rotSpeed = 180;
    private float gravity = 9.81f;
    
    // Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        string joystickString = joystickNum.ToString();
        movementVector.x = Input.GetAxis("L_XAxis_" + joystickString) * movementSpeed;
        movementVector.z = Input.GetAxis("L_YAxis_" + joystickString) * movementSpeed;
        movementVector.y -= gravity * Time.deltaTime;
        transform.Rotate(0, Input.GetAxis("R_XAxis_" + joystickString) * rotSpeed * Time.deltaTime, 0);
        transform.Translate(movementVector.x * Time.deltaTime, 0, movementVector.z * Time.deltaTime);

    }

    void onCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "egg")
        {
            Destroy(other.gameObject);
        }
    }
}
