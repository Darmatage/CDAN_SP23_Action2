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
				GetComponent<PlayerEchoReveal>().TurnOffEchoLines();
				GameHandler.torchOn = true;
                torchHand.SetActive(true);
            }else{
                GameHandler.torchOn = false;
                torchHand.SetActive(false);            
            }
        }
		
		
    }
	
	
}
