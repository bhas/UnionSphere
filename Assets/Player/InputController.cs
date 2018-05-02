using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
	public CameraController camera;
	public PlayerMovement playerMovement;
	public bool isEnabled = true;


	// Update is called once per frame
	void Update ()
	{
		if (!isEnabled)
			return;

		UpdateCameraRotation();
		UpdatePlayerMovement();
	}

	private void UpdatePlayerMovement()
	{
		var dx = 0;
		var dy = 0;
		// player movement
		if (Input.GetKey(KeyCode.W))
			dy += 1;
		if (Input.GetKey(KeyCode.S))
			dy -= 1;
		if (Input.GetKey(KeyCode.D))
			dx += 1;
		if (Input.GetKey(KeyCode.A))
			dx -= 1;
		playerMovement.Move(new Vector2(dx, dy));
	}

	private void UpdateCameraRotation()
	{
		if (Input.GetKey(KeyCode.RightArrow))
			camera.RotateRight();
		if (Input.GetKey(KeyCode.LeftArrow))
			camera.RotateLeft();
	}
}
