using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyXRLeftControllerHandler : MonoBehaviour
{
	[SerializeField] private InputActionAsset inputActionAsset;
	[SerializeField] private SceneController SceneControllerRef;

	private InputAction joystickClickAction;

	private void Awake()
	{
		// Ensure inputActionAsset is assigned in the Inspector
		var actionMap = inputActionAsset.FindActionMap("MyLeftHandMapping");
		joystickClickAction = actionMap.FindAction("JoystickClick");
	}

	private void OnEnable()
	{
		joystickClickAction.performed += OnJoystickClick;
		joystickClickAction.Enable();
	}

	private void OnDisable()
	{
		joystickClickAction.performed -= OnJoystickClick;
		joystickClickAction.Disable();
	}

	private void OnJoystickClick(InputAction.CallbackContext context)
	{
		// Call ShowHideMenu
		SceneControllerRef.ToggleSceneSelectMenu();
	}
}
