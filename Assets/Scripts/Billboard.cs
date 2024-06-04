using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.UI
{
	public class Billboard : MonoBehaviour
	{

		[SerializeField]
		private bool UseX = false;
		[SerializeField]
		private bool UseY = false;
		[SerializeField]
		private bool UseZ = false;
		[SerializeField]
		private Transform TargetTransform;

		[SerializeField]
		private Camera MainCamera;

		/// <summary>
		/// Keeps the object facing the camera.
		/// </summary>
		private void Update()
		{

			// Get a Vector that points from the target to the main camera.
			Vector3 directionToTarget = TargetTransform.position - transform.position;

			bool useCameraAsUpVector = true;

			if (UseX)
				if (UseY)
					if (UseZ)
					{
						// Nothing to do
					}
					else
					{
						useCameraAsUpVector = false;

					}
				else if (UseZ)
				{
					directionToTarget.x = 0.0f;
				}
				else
				{
					directionToTarget.x = 0.0f;
					useCameraAsUpVector = false;
				}
			else if (UseY)
			{
				if (UseZ)
				{
					directionToTarget.y = 0.0f;
				}
				else
				{
					directionToTarget.y = 0.0f;
					useCameraAsUpVector = false;
				}
			}
			else if (UseZ)
			{
				directionToTarget.x = 0.0f;
				directionToTarget.y = 0.0f;
			}

			// If we are right next to the camera the rotation is undefined. 
			if (directionToTarget.sqrMagnitude < 0.001f)
			{
				return;
			}

			// Calculate and apply the rotation required to reorient the object
			if (useCameraAsUpVector)
			{
				transform.rotation = Quaternion.LookRotation(-directionToTarget, MainCamera.transform.up);
			}
			else
			{
				transform.rotation = Quaternion.LookRotation(-directionToTarget);
			}
		}
	}
}