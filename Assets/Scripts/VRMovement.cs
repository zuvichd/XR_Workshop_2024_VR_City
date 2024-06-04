using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using Unity.XR.CoreUtils;

public class VRMovement : MonoBehaviour
{
	public XRNode inputSource;
	public float speed = 1.0f;
	private Vector2 inputAxis;
	private XROrigin rig;
	private CharacterController character;


	// Start is called before the first frame update
	void Start()
	{
		character = GetComponent<CharacterController>();
		rig = GetComponent<XROrigin>();
	}

	// Update is called once per frame
	void Update()
	{
		InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
		device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
	}

	void FixedUpdate()
	{
		Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
		Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
		character.Move(direction * Time.fixedDeltaTime * speed);
	}

}
