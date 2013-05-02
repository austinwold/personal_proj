using UnityEngine;
using System.Collections;
using System.IO;

public class myfirstgui : MonoBehaviour {
	string username = "uninitialized";
	
	string usernameFilePath {
		get {
			return Application.persistentDataPath + "/username.txt";
		}
	}
	
	void Start () {
		Debug.Log(Screen.width);
		Debug.Log(Application.persistentDataPath);
		try {
			username = File.ReadAllText(usernameFilePath);
		}
		catch(FileNotFoundException) {
			username = "Enter a username here.";
		}
	}
	
	void OnGUI() {
		GUILayout.BeginHorizontal(); {
			GUILayout.Label ("Username: ");
			GUI.changed = false;
			username = GUILayout.TextField(username);
			if(GUI.changed) {
				File.WriteAllText(usernameFilePath, username);
			}
		} GUILayout.EndHorizontal();
	}
	
	void update() {
		
	}
}
