using UnityEngine;
using System.Collections;

public class timebar : MonoBehaviour {
	
	public Texture2D maxHpBar;
	public Texture2D hpBar;
	public Texture2D mpBar;
	public Texture2D expBar;
	public Vector2 maxHpBarPosition = new Vector2(20,20);
	public Vector2 hpBarPosition = new Vector2(152,48);
	public Vector2 mpBarPosition = new Vector2(152,71);
	public Vector2 expBarPosition = new Vector2(152,94);
	public Vector2 levelPosition = new Vector2(24,86);
	public int maxHpBarWidth = 310;
	public int maxHpBarHeigh = 115;
	public int barHeight = 19;
	public int expBarHeight = 8;
	public GUIStyle textStyle;
	public GUIStyle hpTextStyle;
	
	public float barMultiply = 1.6f;
	
	public GameObject player;
	public GameObject map;
	private float hptext = 100;
	float lv;
	
	void  Awake (){
		if(!map){
			player = GameObject.FindWithTag("Player");
			map = GameObject.FindWithTag("Map");
		}
		hptext = 100 * barMultiply;
		lv = player.GetComponent<StatusC>().level;
	}
	
	void  OnGUI (){
		if(!player){
			return;
		}
		float maxHp = player.GetComponent<StatusC>().maxHealth;
		float hp = player.GetComponent<StatusC>().health * 100 / maxHp *barMultiply;
		float maxMp = player.GetComponent<StatusC>().maxMana;
		float mp = player.GetComponent<StatusC>().mana * 100 / maxMp *barMultiply;
		float maxExp = player.GetComponent<StatusC>().maxExp;
		float exp = player.GetComponent<StatusC>().exp * 100 / maxExp *barMultiply;
		
		int currentHp = player.GetComponent<StatusC>().health;
		int currentMp = player.GetComponent<StatusC>().mana;
		string timer = map.GetComponent<Timer>().Tic;

		if (map.GetComponent<Timer>().seconds == 29 || map.GetComponent<Timer>().seconds == 59) {
			lv++;
		}

		
		GUI.DrawTexture( new Rect(maxHpBarPosition.x ,maxHpBarPosition.y ,maxHpBarWidth,maxHpBarHeigh), maxHpBar);
		
		GUI.Label ( new Rect(levelPosition.x, levelPosition.y, 50, 50), lv.ToString() , textStyle);
		GUI.Label ( new Rect(hpBarPosition.x, hpBarPosition.y, hptext, barHeight), timer , hpTextStyle);
	}
	
}
