using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class PortalMirrorClone : MonoBehaviour
{
	private Portal portal;
	private Dictionary<int, bool> initialPosDict = new Dictionary<int, bool>();
	private Dictionary<int, GameObject> clonesDict = new Dictionary<int, GameObject>();

	// Use this for initialization
	void Start ()
	{
		portal = GetComponentInParent<Portal>();
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Portal Clone"))
			return;

		initialPosDict[other.gameObject.GetInstanceID()] = IsInFront(other.transform);

		var clone = CreateClone(other.gameObject);
		MirrorObject(other.gameObject, clone);
		clonesDict[other.gameObject.GetInstanceID()] = clone;
	}

	public void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Portal Clone"))
			return;

		var clone = clonesDict[other.gameObject.GetInstanceID()];
		MirrorObject(other.gameObject, clone);
	}

	public void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Portal Clone"))
			return;

		bool inFront = IsInFront(other.transform);
		var clone = clonesDict[other.gameObject.GetInstanceID()];
		// check if object has passed the portal
		if (initialPosDict[other.gameObject.GetInstanceID()] != inFront)
		{
			var camController = Camera.main.gameObject.GetComponent<CameraController>();
			var deltaAngle = Vector3.SignedAngle(clone.transform.forward, other.transform.forward, Vector3.up);
			camController.rotationAngle -= deltaAngle;
			print(deltaAngle);

			print("Swap " + other.transform.position + " to " + clone.transform.position);
			other.transform.position = clone.transform.position;
			other.transform.forward = clone.transform.forward;

			portal.StartRendering();
			portal.linkedPortal.StopRendering();
		}

		Destroy(clonesDict[other.gameObject.GetInstanceID()]);
		clonesDict.Remove(other.gameObject.GetInstanceID());
	}

	private GameObject CreateClone(GameObject original)
	{
		var clone = Instantiate(original.gameObject);
		clone.tag = "Portal Clone";
		return clone;
	}

	private bool IsInFront(Transform obj)
	{
		return transform.InverseTransformPoint(obj.position).z > 0;
	}

	public void MirrorObject(GameObject original, GameObject clone)
	{
		var localPos = transform.InverseTransformPoint(original.transform.position);
		clone.transform.position = portal.linkedPortal.transform.TransformPoint(localPos);
		var localDir = transform.InverseTransformDirection(original.transform.forward);
		clone.transform.forward = portal.linkedPortal.transform.TransformDirection(localDir);
	}
}
