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

    void Start(){
		player = GameObject.FindWithTag("Player").GetComponent<Transform>();
		cameraMain = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
		
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


}
