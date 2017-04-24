using UnityEngine;
using UnityEngine.UI;

public class CarLapCounter : MonoBehaviour
{
		public TrackCheckpoint m_first;
		public Text m_lapsText;

		private TrackCheckpoint m_next;
		private int m_numLaps;

		void Start()
		{
				m_numLaps = 0;
				SetNextCheckpoint(m_first);
				UpdateText();
		}

		public void OnReachCheckpoint(TrackCheckpoint _checkpoint)
		{
				if (_checkpoint == m_next)
				{
						if (m_first == m_next)
						{
								m_numLaps++;
								UpdateText();
						}
						SetNextCheckpoint(_checkpoint);
				}
		}

		public TrackCheckpoint GetNextCheckpoint()
		{
				return m_next;
		}

		private void UpdateText()
		{
				if (m_lapsText)
				{
						m_lapsText.text = "Laps: " + m_numLaps.ToString();
				}
		}

		private void SetNextCheckpoint(TrackCheckpoint _checkpoint)
		{
				m_next = _checkpoint.m_next;
		}
}