using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Portal : MonoBehaviour
{
	public bool isRendering;
	private Camera portalCamera;
	public Portal linkedPortal;

	private Dictionary<int, bool> objDict = new Dictionary<int, bool>();
	[HideInInspector]
	public RenderTexture renderTexture;
	public Renderer portalRenderer;
	private MaterialPropertyBlock propBlock;

	private void Awake()
	{
		renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
		propBlock = new MaterialPropertyBlock();
	}

	// Use this for initialization
	void Start ()
	{
		portalCamera = GetComponentInChildren<Camera>();
		if (portalCamera.targetTexture != null)
			portalCamera.targetTexture.Release();

		portalCamera.targetTexture = renderTexture;

		if (isRendering)
			StartRendering();
		else
			StopRendering();
	}	

	public void StartRendering()
	{
		isRendering = false;
		portalCamera.gameObject.SetActive(true);
		portalRenderer.gameObject.SetActive(false);
	}

	public void StopRendering()
	{
		isRendering = true;
		portalCamera.gameObject.SetActive(false);
		portalRenderer.gameObject.SetActive(true);
	}

	// Update is called once per frame
	void Update ()
	{
		var playerCamera = Camera.main.transform;
		var localOffset = linkedPortal.transform.InverseTransformPoint(playerCamera.position);
		portalCamera.transform.localPosition = localOffset;
		var localDir = linkedPortal.transform.InverseTransformDirection(playerCamera.forward);
		portalCamera.transform.forward = transform.TransformDirection(localDir);

		portalRenderer.GetPropertyBlock(propBlock);
		propBlock.SetTexture("_MainTex", linkedPortal.renderTexture);
		portalRenderer.SetPropertyBlock(propBlock);
	}
}