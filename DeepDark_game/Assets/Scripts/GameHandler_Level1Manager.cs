using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler_Level1Manager : MonoBehaviour
{
	private Transform player;
	private Transform cameraMain;
	public Transform playerStart_start;
	public Transform playerStart_end;

	public GameObject Level1_Start_Content;
	public GameObject Level1_End_Content;
	
	
	//remove darkness away when mushroom is healed
	public static bool mushroomHealed = false;
	public GameObject TM_GroundBlack;
	public GameObject TM_CollidersBlack;
	public GameObject DarknessFaded;
	
	private Renderer DarknessFadeRend;
	private float fadeAlpha = 0f;
	private bool canTreeDialogue=true;
	
    void Start(){
		player = GameObject.FindWithTag("Player").GetComponent<Transform>();
		cameraMain = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
		TM_GroundBlack.SetActive(true);
		TM_CollidersBlack.SetActive(true);
		DarknessFaded.SetActive(true);
		DarknessFadeRend = DarknessFaded.GetComponent<Renderer>();
		
		if (GameHandler.Level1IsEnd==true){
			//level 1 at end of game, after finishign level 4
			player.position = playerStart_end.position;
			
			Vector3 camPos_end = new Vector3 (playerStart_end.position.x, playerStart_end.position.y, -10f);
			cameraMain.position = camPos_end;
			
			Level1_End_Content.SetActive(true);
			Level1_Start_Content.SetActive(false);	
		}
		else {
			//level 1 at start
			player.position = playerStart_start.position;
			
			Vector3 camPos_start = new Vector3 (playerStart_start.position.x, playerStart_start.position.y, -10f);
			cameraMain.position = camPos_start;
			
			Level1_End_Content.SetActive(false);
			Level1_Start_Content.SetActive(true);	
		}
    }

	void FixedUpdate(){
		//remove darkness
		if (mushroomHealed){
			TM_GroundBlack.SetActive(false);
			TM_CollidersBlack.SetActive(false);
			
			fadeAlpha -= 0.001f;
			DarknessFadeRend.material.color = new Color(0f, 0f, 0f, fadeAlpha);
			if (fadeAlpha <= 0f){
				fadeAlpha=0f;
				if (canTreeDialogue==true){
		GameObject.FindWithTag("GreatMushroom").GetComponent<NPCDialogue>().TreeDialogue();
		canTreeDialogue=false;
				}
				}
		}
	}


}
