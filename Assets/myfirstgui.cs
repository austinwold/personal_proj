using UnityEngine;
using System.Collections;
using System.IO;

public class myfirstgui : MonoBehaviour {
	string username = "uninitialized";
	public Texture2D logo;
	
	string usernameFilePath {
		get {
			return Application.persistentDataPath + "/username.txt";
		}
	}
	
	void Start () {
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
			GUILayout.Space(Screen.width - 190);
			GUILayout.Label((1f/ Time.deltaTime) + "FPS");
		} GUILayout.EndHorizontal();
		GUI.DrawTexture(new Rect(0,(Screen.height - (Screen.height* 0.1f)), (Screen.width * 0.1f), (Screen.height * 0.1f)), logo, ScaleMode.ScaleToFit);
		//GUILayout.BeginArea(new Rect(50,(Screen.height - 300), (Screen.width * 0.1f), (Screen.height * 0.1f)), logo);
		//GUILayout.EndArea();
	}
	
	void update() {
		
	}
}
