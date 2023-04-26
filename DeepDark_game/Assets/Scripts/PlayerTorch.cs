using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTorch : MonoBehaviour{
	
	public GameObject torchHand;
	public GameObject minerHelmet;
	public AudioSource torch_turnOn;
	public AudioSource miner_hat_onOff;
	//private GameHandler gameHandler;
	
	void Start(){
		if (GameHandler_Lights.torchOn == false){
        torchHand.SetActive(false); 
		} else {torchHand.SetActive(true);} 
		
		
		if (GameHandler_Lights.helmetOn == false){
        minerHelmet.SetActive(false); 
		} else {minerHelmet.SetActive(true);} 
		
		
		//gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		
	}
	
    void Update(){
		if (Input.GetKeyDown("t")){
            if (GameHandler_Lights.torchOn == false){
				ActivateTorch();
				torch_turnOn.Play();
            }else{
                SnuffTorch();           
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
		
    }
	
	//torch functions
	public void ActivateTorch(){
		GetComponent<PlayerEchoReveal>().TurnOffEchoLines();
		GameHandler_Lights.torchOn = true;
        torchHand.SetActive(true);
	}
	
	public void SnuffTorch(){
		GameHandler_Lights.torchOn = false;
        torchHand.SetActive(false); 
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Water"){
			SnuffTorch();
		}
	}
	
	//helmet functions
	public void HelmetTurnOn(){
		GetComponent<PlayerEchoReveal>().TurnOffEchoLines();
		GameHandler_Lights.helmetOn = true;
        minerHelmet.SetActive(true);
	}
	
	public void HelmetTurnOff(){
		GameHandler_Lights.helmetOn = false;
        minerHelmet.SetActive(false); 
	}
	
	
}
