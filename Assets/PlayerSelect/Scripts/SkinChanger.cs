using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

class Skin
{
	public string name;
	public string spritesheet;

	public Skin(string newName, string newSpriteSheet){
		name = newName;
		spritesheet = newSpriteSheet;
	}

}

public class SkinChanger : MonoBehaviour {

	public ReSkinAnimation skinner;
	public Text textName;

	[Range(0,4)]
	public int currentSkin = 0;

	Skin[] skins;

	// Use this for initialization
	void Start () {
		skins = new Skin [4];
		skins [0] = new Skin ("Huguinho", "character1");
		skins [1] = new Skin ("Zezinho", "character2");
		skins [2] = new Skin ("Luizinho", "character3");
		skins [3] = new Skin ("Pateta", "character4");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			currentSkin -= 1;
			if( currentSkin < 0 )
				currentSkin = skins.Length - 1;
			ChangeSkin(currentSkin);
		}
		else if(Input.GetKeyDown(KeyCode.RightArrow)) {
			currentSkin += 1;
			currentSkin %= skins.Length;
			ChangeSkin(currentSkin);
		}
	}

	void ChangeSkin(int n)
	{
		textName.text = skins [n].name;
		skinner.spriteSheetName = skins [n].spritesheet;
	}
}
