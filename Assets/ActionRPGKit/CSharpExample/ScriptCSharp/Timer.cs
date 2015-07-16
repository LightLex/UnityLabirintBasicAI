using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public float time=0,seconds=0;
	public bool caught = false;
	public string Tic="";
	int minute=0;
	private bool  menu = false;

	// Use this for initialization
	void Start () {
		caught = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (caught == false) {
			time = time + Time.deltaTime;
			seconds=seconds + Time.deltaTime;
			if (seconds > 60) {
				minute++;
				seconds = 0;
			}
			Tic = minute + ":" + (int)seconds;
		} else {
			menu = true;
			Time.timeScale = 0.0f;
			Screen.lockCursor = false;
		}
	}

	void  OnGUI (){
		if (menu) {
			GUI.Box ( new Rect(Screen.width / 2 - 110,230,220,200), "Menu");
			if (GUI.Button ( new Rect(Screen.width / 2 - 45,285,90,40), "Survived: "+Tic)) {
			}
			
			if (GUI.Button ( new Rect(Screen.width / 2 + 55,235,30,30), "X")) {
				Application.Quit();
			}

		}
	}
}
