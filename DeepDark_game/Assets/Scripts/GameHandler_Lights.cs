using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler_Lights : MonoBehaviour{
	
	public static bool torchOn = false;
	public float timerTorch = 0; // if get a new torch, set = 0 ("full")
	public float timeToNoTorch = 10f;
	public GameObject timerTorchDisplay;
	public Image timerTorchCircle; 
	
	public static bool helmetOn = false;
	public static bool helmetOnHead = false;
	public float timerHelmet = 0; // if get a new battery, set = 0 ("full")
	public float timeToNoHelmet = 10f;
	public GameObject timerHelmetDisplay;
	public Image timerHelmetCircle; 
	
	public static bool canEcho = true;
	private float timerEcho = 0;
	private float timeToNextEcho = 0.5f;
	
	private GameObject player;

    void Start(){
        timerTorchDisplay.SetActive(false);
		timerHelmetDisplay.SetActive(false);
		player = GameObject.FindWithTag("Player");
    }

	void FixedUpdate(){
		//Echo Timer
		if (canEcho == false){
			if (timerEcho < timeToNextEcho){
				timerEcho += 0.01f;
			} else {
				canEcho = true;
				timerEcho = 0;
			}
		}

		//Torch Timer
		if (torchOn == true){
			if (timerTorch < timeToNoTorch){
				timerTorch += 0.01f;
				timerTorchDisplay.SetActive(true);
                timerTorchCircle.fillAmount = (timeToNoTorch - timerTorch) / timeToNoTorch; 
			} else {
				player.GetComponent<PlayerTorch>().SnuffTorch();
				timerTorch = 0;
				timerTorchDisplay.SetActive(false);
			}
		}

		//Helmet Timer
		if (helmetOn == true){
			timerHelmetDisplay.SetActive(true);
			timerHelmetCircle.fillAmount = (timeToNoHelmet - timerHelmet) / timeToNoHelmet;
			if (timerHelmet < timeToNoHelmet){
				timerHelmet += 0.01f;
			} else {
				player.GetComponent<PlayerTorch>().HelmetTurnOff();
				//timerHelmet = 0;
				//timerHelmetDisplay.gameObject.SetActive(false);
				//GetComponent<GameInventory>().ReturnHelmetToInventory();
			}
		}	
		
	}
	
	public void TurnOffTorchDisplay(){
		timerTorchDisplay.SetActive(false);
	}
	
	public void TurnOffHelmetDisplay(){
		timerHelmetDisplay.SetActive(false);
	}
	
}
