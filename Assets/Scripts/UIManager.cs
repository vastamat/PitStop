using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
		public void PlayButtonEvent()
		{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		public void ExitButtonEvent()
		{
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
}
