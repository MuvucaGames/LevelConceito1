using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour {


	public List<string> levels;

	public GameObject buttonPrefab;

	public GameObject ButtonHolder;
	// Use this for initialization
	public void Start(){
		int i = 1;
		/*
		foreach(EditorBuildSettingsScene ebss in EditorBuildSettings.scenes){
			print(ebss.path);
		}
		*/

		foreach (string name in levels) {
			if(name == "") continue;
			GameObject button = Instantiate(buttonPrefab) as GameObject;
			button.transform.SetParent(ButtonHolder.transform);
			button.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -40*i, 0);
			button.GetComponentInChildren<Text>().text = name;
			string capturedName = name;
			button.GetComponentInChildren<Button>().onClick.AddListener(() => {
				Application.LoadLevel(capturedName);
			});
			i++;
		}
	}
}
