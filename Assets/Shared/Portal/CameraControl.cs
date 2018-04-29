using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
	public float rotationSpeed;
	public Transform anchor;

	// Use this for initialization
	void Start ()
	{
		transform.LookAt(anchor);
	}

	// Update is called once per frame
	void Update ()
	{
		var dx = Input.GetAxis("Horizontal");
		if (dx != 0)
		{
			transform.RotateAround(anchor.position, Vector3.up, -dx * rotationSpeed);
		}
	}
}
