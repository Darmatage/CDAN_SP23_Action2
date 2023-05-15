using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTorch : MonoBehaviour{
	
	private Animator anim;
	public GameObject torchHand;
	public GameObject minerHelmet;
	public AudioSource torch_turnOn;
	public AudioSource torch_turnOff;
	public AudioSource miner_hat_onOff;
	//private GameHandler gameHandler;
	
	void Start(){
		anim = GetComponentInChildren<Animator>();
		
		if (GameHandler_Lights.torchOn == false){
        torchHand.SetActive(false); 
		} else {torchHand.SetActive(true);} 
		
		
		if (GameHandler_Lights.helmetOn == false){
        minerHelmet.SetActive(false); 
		} else {minerHelmet.SetActive(true);} 
		
		
		//gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		
	}
	
    void Update(){
		/*
		if (Input.GetKeyDown("t")){
            if (GameHandler_Lights.torchOn == false){
				ActivateTorch();
				torch_turnOn.Play();
				
            }else{
                SnuffTorch();
            torch_turnOff.Play();				
            }
        }
		
		if (Input.GetKeyDown("m")){
            if (GameHandler_Lights.helmetOn == false){
				HelmetTurnOn();
				miner_hat_onOff.Play();
            }else{
                HelmetTurnOff();           
            }
        }
		*/
    }
	
	//torch functions
	public void ActivateTorch(){
		anim.SetBool ("isHoldingTorch", true);
		GetComponent<PlayerEchoReveal>().TurnOffEchoLines();
		GameHandler_Lights.torchOn = true;
        torchHand.SetActive(true);
		torch_turnOn.Play();
		if (GameHandler_Lights.helmetOn){
			HelmetTurnOff(); // turn off helmet if torch is on
			
		}
	}
	
	public void SnuffTorch(){
		anim.SetBool ("isHoldingTorch", false);
		GameHandler_Lights.torchOn = false;
        torchHand.SetActive(false); 
		torch_turnOff.Play();
	}
	
	void OnTriggerStay2D(Collider2D other){
		if ((other.gameObject.tag == "Water")&&(GameHandler_Lights.torchOn)){
			SnuffTorch();
			GameObject.FindWithTag("GameHandler").GetComponent<GameHandler_Lights>().TurnOffTorchDisplay();
		}
	}
	
	//helmet functions
	public void HelmetTurnOn(){
		anim.SetBool ("isWearingMiner", true);
		GetComponent<PlayerEchoReveal>().TurnOffEchoLines();
		GameHandler_Lights.helmetOn = true;
        minerHelmet.SetActive(true);
		miner_hat_onOff.Play();
		if (GameHandler_Lights.torchOn){
			SnuffTorch(); // turn off torch if helmet is on
		}
	}
	
	public void HelmetTurnOff(){
		anim.SetBool ("isWearingMiner", false);
		GameHandler_Lights.helmetOn = false;
        minerHelmet.SetActive(false); 
		miner_hat_onOff.Play();
	}
	
	
}
