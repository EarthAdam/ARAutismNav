using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.XR;

public class drive : NetworkBehaviour {

	public float speed = 100.0f;
	public float rotationSpeed = 100.0f;
	public Camera cam;
	public GameObject VRmode;


	void Start()
	{
		cam = GameObject.Find("Camera").GetComponent<Camera>();
	}

	void Update () 
	{
			XRSettings.enabled = false;
			cam.enabled = true;
			float xTranslation = Input.GetAxis("Horizontal") * speed;
			float yTranslation = Input.GetAxis("Vertical") * speed;
			float xRotation = Input.GetAxis("Pitch") * rotationSpeed;
			float yRotation = Input.GetAxis("Yaw") * rotationSpeed;
			xTranslation *= Time.deltaTime;
			yTranslation *= Time.deltaTime;
			xRotation *= Time.deltaTime;
			yRotation *= Time.deltaTime;
			if ((xTranslation > .1 || yTranslation > .1)||(xTranslation < -.1 || yTranslation < -.1))
			{
				transform.Translate (xTranslation, 0, -yTranslation);
			}
			if ((xRotation > .1 || yRotation > .1) ||(xRotation < -.1 || yRotation < -.1)) 
			{
				transform.Rotate(xRotation, -yRotation, 0);
			}
			float z = transform.eulerAngles.z;
			transform.Rotate(0, 0, -z);

		if (!isLocalPlayer)
		{
			cam.enabled = false;
			return;
		}
		if (transform.position.y < -8) 
		{
			transform.position = new Vector3(transform.position.x, -8, transform.position.z);
		}
		if (transform.position.y > 2000) 
		{
			transform.position = new Vector3(transform.position.x, 2000, transform.position.z);
		}
	}

}
