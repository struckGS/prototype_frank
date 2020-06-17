using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    
	[Range(60, 180)]
	public float mouseSens = 100f;

	public Transform head;

	float headRotation;

    void Start() {
		Cursor.lockState = CursorLockMode.Locked;
    }

	void Update() {
		float mouseX = Input.GetAxisRaw("Mouse X") * mouseSens * Time.deltaTime;
		float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSens * Time.deltaTime;

		headRotation -= mouseY;
		headRotation = Mathf.Clamp(headRotation, -90f, 90f);
		head.localRotation = Quaternion.Euler(headRotation, 0f, 0f);

		transform.Rotate(Vector3.up * mouseX);
    }
}
