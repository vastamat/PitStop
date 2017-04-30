using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Class to hold all of the UI OnClick functions and other UI-related functions
/// </summary>
public class UIManager : MonoBehaviour
{
		public Slider m_volumeSlider;

		private void Start()
		{
				if (m_volumeSlider)
				{
						// Set the sliders value to the saved volume from previous games
						m_volumeSlider.value = GlobalControl.m_instance.m_savedData.volume;
						// Set the slider to inactive as it should come up when the music button is clicked
						m_volumeSlider.gameObject.SetActive(false);
				}
		}

		public void OnVolumeChanged(float _value)
		{
				// When the value on the slider is changed, save it in the volume global data
				GlobalControl.m_instance.m_savedData.volume = _value;

				// And change the listener volume to it
				AudioListener.volume = _value;
		}

		public void OnVolumeButtonClicked()
		{
				// When the music button is clicked, change it to it's inverse state
				m_volumeSlider.gameObject.SetActive(!m_volumeSlider.gameObject.activeSelf);
		}

		public void PlayButtonEvent()
		{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		public void ExitButtonEvent()
		{
				//save the data
				GlobalControl.m_instance.SaveData();
				//exit the game
				Application.Quit();
		}
		public void BackButtonEvent()
		{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		}
		public void TrainingButtonEvent()
		{
				SceneManager.LoadScene("Training");
		}
		public void TournamentButtonEvent()
		{
				SceneManager.LoadScene("LevelSelector");
		}
		public void Level1Clicked()
		{
				SceneManager.LoadScene("Level1");
		}
		public void Level2Clicked()
		{
				SceneManager.LoadScene("Level2");
		}
		public void Level3Clicked()
		{
				SceneManager.LoadScene("Level3");
		}
		public void Level4Clicked()
		{
				SceneManager.LoadScene("Level4");
		}
		public void Level5Clicked()
		{
				SceneManager.LoadScene("Level5");
		}
		public void Level6Clicked()
		{
				SceneManager.LoadScene("Level6");
		}
		public void Level7Clicked()
		{
				SceneManager.LoadScene("Level7");
		}
		public void Level8Clicked()
		{
				SceneManager.LoadScene("Level8");
		}
		public void Level9Clicked()
		{
				SceneManager.LoadScene("Level9");
		}
		public void Level10Clicked()
		{
				SceneManager.LoadScene("Level10");
		}
		public void OnLevelFinish()
		{
				SceneManager.LoadScene("MainMenu");
		}
}
