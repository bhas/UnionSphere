using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayerMovement : MonoBehaviour
{
	public CameraController cameraController;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Move(Vector2 dir)
	{
		// update position
		dir = dir.normalized;
		var forward = cameraController.Forward;
		var right = -Vector3.Cross(forward, Vector3.up);
		var dir2 = forward * dir.y + right * dir.x;
		transform.position += speed * dir2;

		// update rotation
		transform.LookAt(transform.position + dir2);
	}
}
