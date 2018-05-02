using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform target;
	public float rotationSpeed = 2;
	public float height = 0.8f;
	public float distance = 2;
	public float angle = 30;
	public float rotationAngle;

	public Vector3 Forward
	{
		get { return Quaternion.Euler(0, rotationAngle, 0) * Vector3.forward; }
	}

	private void Update () {
		// calculate position
		var offset = -Forward * distance + Vector3.up * height;
		transform.position = target.position + offset;

		// calculate rotation
		var r = Quaternion.LookRotation(-offset, Vector3.up);
		transform.eulerAngles = new Vector3(angle, r.eulerAngles.y, r.eulerAngles.z);
	}

	public void RotateRight()
	{
		rotationAngle += rotationSpeed;
	}

	public void RotateLeft()
	{
		rotationAngle -= rotationSpeed;
	}
}
