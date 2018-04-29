using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
	public Transform portalCamera;
	public Transform linkedPortal;
	private float cameraDistance;

	// Use this for initialization
	void Start ()
	{
		cameraDistance = portalCamera.localPosition.magnitude;
		print(cameraDistance);
	}
	
	// Update is called once per frame
	void Update ()
	{
		var dir = (Camera.main.transform.position - linkedPortal.position).normalized;
		portalCamera.localPosition = dir * cameraDistance;
		portalCamera.LookAt(transform);
	}
}
