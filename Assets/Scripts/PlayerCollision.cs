using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
		PostProcessEffect m_cameraPostProcess;

		void Start()
		{
				m_cameraPostProcess = Camera.main.GetComponent<PostProcessEffect>();
		}
		void OnCollisionEnter2D(Collision2D coll)
		{
				if (!coll.gameObject.CompareTag("Enemy"))
				{
						m_cameraPostProcess.m_intensity = Mathf.Lerp(m_cameraPostProcess.m_intensity, 1.0f, Time.deltaTime);
				}
		}
		void OnCollisionStay2D(Collision2D coll)
		{
				if (!coll.gameObject.CompareTag("Enemy"))
				{
						m_cameraPostProcess.m_intensity = Mathf.Lerp(m_cameraPostProcess.m_intensity, 1.0f, Time.deltaTime);
				}
		}
		void OnCollisionExit2D(Collision2D coll)
		{
				if (!coll.gameObject.CompareTag("Enemy"))
				{
						m_cameraPostProcess.m_intensity = 0.0f;
				}
		}
}
