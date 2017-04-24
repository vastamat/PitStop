using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// A singleton class for data persistence between scenes and game startups
/// </summary>
public class GlobalControl : MonoBehaviour
{
		/*
			* the single instance of the class
			*/
		public static GlobalControl m_instance;

		/*
			* data which is saved after the game is closed
			*/
		public SavedData m_savedData = new SavedData();

		void Awake()
		{
				/*
					* check if an instance already exists
					*/
				if (m_instance == null)
				{
						/*
						 * if not, then this must be the first one
							* so do not destroy it on load
						 */
						DontDestroyOnLoad(gameObject);

						/*
						 * and set the static instance variable to this
						 */
						m_instance = this;
				}
				else if (m_instance != this)
				{
						/*
						 * if an instance already exists(and it's not the main one), destroy this one and keep using the original instance
						 */
						Destroy(gameObject);
				}

				//Load the saved data at the start of the game
				LoadData();
		}

		public void SaveData()
		{
				//check if the saves directory exists
				if (!Directory.Exists(Application.persistentDataPath + "/Saves"))
				{
						//if not, then create one
						Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
				}

				//create the binary formatter
				BinaryFormatter formatter = new BinaryFormatter();

				//create the save file in the saves directory
				FileStream saveFile = File.Create(Application.persistentDataPath + "/Saves" + "/save.binary");

				//save the highscores
				formatter.Serialize(saveFile, m_savedData);

				//Close the file
				saveFile.Close();
		}

		public void LoadData()
		{
				//Load if the saves directory exists
				if (Directory.Exists(Application.persistentDataPath + "/Saves"))
				{
						//create the binary formatter
						BinaryFormatter formatter = new BinaryFormatter();

						//open the save file
						FileStream saveFile = File.Open(Application.persistentDataPath + "/Saves" + "/save.binary", FileMode.Open);

						//read the highscore
						m_savedData = (SavedData)formatter.Deserialize(saveFile);

						saveFile.Close();
				}
		}
}
