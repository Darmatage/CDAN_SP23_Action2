using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTorch : MonoBehaviour{
	
	public GameObject torchHand;
	public GameObject minerHelmet;
	private GameHandler gameHandler;
	
	void Start(){
		if (GameHandler.torchOn == false){
        torchHand.SetActive(false); 
		} else {torchHand.SetActive(true);} 
		
		if (GameHandler.helmetOn == false){
        minerHelmet.SetActive(false); 
		} else {minerHelmet.SetActive(true);} 
		
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		
	}
	
    void Update(){
		if (Input.GetKeyDown("t")){
            if (GameHandler.torchOn == false){
				ActivateTorch();
            }else{
                SnuffTorch();           
            }
        }
		
		if (Input.GetKeyDown("m")){
            if (GameHandler.helmetOn == false){
				HelmetTurnOn();
            }else{
                HelmetTurnOff();           
            }
        }
		
    }
	
	//torch functions
	public void ActivateTorch(){
		GetComponent<PlayerEchoReveal>().TurnOffEchoLines();
		GameHandler.torchOn = true;
        torchHand.SetActive(true);
		gameHandler.TorchTimer();
	}
	
	public void SnuffTorch(){
		GameHandler.torchOn = false;
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
		GameHandler.helmetOn = true;
        minerHelmet.SetActive(true);
		gameHandler.HelmetTimer();
	}
	
	public void HelmetTurnOff(){
		GameHandler.helmetOn = false;
        minerHelmet.SetActive(false); 
	}
	
	
}
