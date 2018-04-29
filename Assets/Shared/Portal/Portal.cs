using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
	public Transform portalCamera;
	public Transform linkedPortal;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		var playerCamera = Camera.main.transform;
		var localOffset = linkedPortal.InverseTransformPoint(playerCamera.position);
		portalCamera.localPosition = localOffset;

		var localDir = linkedPortal.InverseTransformDirection(playerCamera.forward);
		portalCamera.forward = transform.TransformDirection(localDir);
	}
}

public class TextureSetup
{
	public Material material;
	public Camera camera;
}