using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovementController : MonoBehaviour {

	public float speed;
	//public Transform truck;
	float rotX;
	float rotY;
	public float mouseSensitivity = 100.0f;
	public float clampAngle = 80.0f;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Movement ();
		//LookAround ();

	}
	void Movement ()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		Vector3 direction = new Vector3 (horizontal, 0, vertical);
		transform.Translate (direction.normalized * Time.deltaTime * speed);
	}
	void LookAround ()
	{
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = -Input.GetAxis("Mouse Y");

		rotY += mouseX * mouseSensitivity * Time.deltaTime;
		rotX += mouseY * mouseSensitivity * Time.deltaTime;

		rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
		Camera.main.transform.rotation = localRotation;
	}
}
