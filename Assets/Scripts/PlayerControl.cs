using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;


	private bool moveForward = false;
	private bool moveLeft = false;
	private bool moveBack = false;
	private bool moveRight = false;

	private void moveForwardWithCamera(float speed) {
		transform.localPosition += transform.forward * speed * Time.deltaTime;
	}

	private void moveBackWithCamera(float speed) {
		transform.localPosition -= transform.forward * speed * Time.deltaTime;
	}

	private void moveRightWithCamera(float speed) {
		transform.localPosition += transform.right * speed * Time.deltaTime;
	}

	private void moveLeftWithCamera(float speed) {
		transform.localPosition -= transform.right * speed * Time.deltaTime;
	}

//	public bool ControllerIsConnected {
//		get {
//			OVRInput.Controller controller =OVRInput.GetConnectedControllers () & (OVRInput.controller.LTrackedRemote | OVRInput.Controller.RTrackedRemote);
//			return controller == OVRInput.Controller.LTrackedRemote || controller == OVRInput.Controller.RTrackedRemote;
//		}
//	}
//	public OVRInput.Controller Controller {
//		get {
//			OVRInput.Controller controller = OVRInput.GetconnectedControllers ();
//			if ((controller & OVRInput.Controller.LTrackedRemote) == OVRInput.Controller.LTrackedRemote) {
//				return OVRInput.Controller.LTrackedRemote;
//			} else if ((controller & OVRInput.Controller.RTrackedRemote) == OVRInput.Controller.RTrackedRemote) {
//				return OVRInput.Controller.RTrackedRemote;
//			}
//			return OVRInput.GetActiveController ();
//		}
//	}

	GameObject cam;

    void Start()
    {
       // transformComponent = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        // Get the direction of input from user
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //transformComponent.Translate(new Vector3(moveHorizontal * speed, 0, moveVertical * speed));
        // Have camera go with VR Headset movement
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);

        //WASD Controls Movement
        if (Input.GetKey(KeyCode.W)) moveForward = true;
        if (Input.GetKey(KeyCode.A)) moveLeft = true;
        if (Input.GetKey(KeyCode.S)) moveBack = true;
        if (Input.GetKey(KeyCode.D)) moveRight = true;

        if (moveForward == true)
        {
            moveForwardWithCamera(speed);
            moveForward = false;
        }

        if (moveLeft == true)
        {
            moveLeftWithCamera(speed);
            moveLeft = false;
        }

        if (moveBack == true)
        {
            moveBackWithCamera(speed);
            moveBack = false;
        }

        if (moveRight == true)
        {
            moveRightWithCamera(speed);
            moveRight = false;
        }


		

    }
}
