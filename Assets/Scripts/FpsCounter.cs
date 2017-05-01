using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script to calculate the fps and avarage it over certain intervals
/// </summary>
public class FpsCounter : MonoBehaviour
{
		//the displayed text
		private Text m_fpsText;

		//number of frames passed
		private int m_frameCount = 0;
		//delta time accumulator
		private float m_deltaTime = 0.0f;
		//calculated fps
		private float m_fps = 0.0f;
		//number of updates per sec
		private float m_updateRate = 4.0f;

		void Start()
		{
				m_fpsText = GetComponent<Text>();
		}
		void Update()
		{
				//increment the frame counter for this frame
				m_frameCount++;

				//accumulate the deltaTime
				m_deltaTime += Time.deltaTime;

				//check if the deltaTIme has become higher than the desired updates per second
				//and update the fps if it has
				if (m_deltaTime > 1.0f / m_updateRate)
				{
						//calculate the avarage fps
						m_fps = m_frameCount / m_deltaTime;

						//reset the frame counter
						m_frameCount = 0;

						//reset the deltaTIme by the updates per second
						m_deltaTime -= 1.0f / m_updateRate;

						//set the display text
						m_fpsText.text = "FPS: " + ((int)m_fps).ToString();
				}
		}
}
