using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
	public float movementSpeed;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		var dx = Input.GetAxis("Horizontal");
		var dy = Input.GetAxis("Vertical");
		var v = new Vector3(dx * movementSpeed, 0, dy * movementSpeed);
		transform.Translate(v, Space.Self);
	}
}
