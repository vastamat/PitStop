using UnityEngine;

/// <summary>
/// Camera script to follow a target game object
/// </summary>
public class CameraFollow : MonoBehaviour
{
		public Transform m_target;

		void LateUpdate()
		{
				transform.position = new Vector3(m_target.position.x, m_target.position.y, transform.position.z);
		}
}
