using UnityEngine;

/// <summary>
/// Makes an object rotate to create a spinning effect;
/// </summary>
public class WheelSpinner : MonoBehaviour
{
		/** How many degrees per sec should the saw spin at */
		public float degreePerSec = 100.0f;
		// Update is called once per frame
		void Update()
		{
				transform.Rotate(0.0f, 0.0f, -degreePerSec * Time.deltaTime);
		}
}
