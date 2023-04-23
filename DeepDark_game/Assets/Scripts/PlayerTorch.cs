using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTorch : MonoBehaviour{
	
	public GameObject torchHand;
	
	void Start(){
		if (GameHandler.torchOn == false){
        torchHand.SetActive(false); 
		} else {torchHand.SetActive(true);} 
		
	}
	
    void Update(){
		if (Input.GetKeyDown("t")){
            if (GameHandler.torchOn == false){
				ActivateTorch();
            }else{
                SnuffTorch();           
            }
        }
    }
	
	public void ActivateTorch(){
		GetComponent<PlayerEchoReveal>().TurnOffEchoLines();
		GameHandler.torchOn = true;
        torchHand.SetActive(true);
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
	
}
