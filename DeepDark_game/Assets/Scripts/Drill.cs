
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Drill : MonoBehaviour{

	public GameHandler gameHandler;
	public GameObject DrillOn;
	public GameObject DrillOff;
	private AudioSource DrillSFX;
	public GameObject damageCollider;
	private bool playerInDrillRange = false;
	private bool isTurnedOff = false;
	private Transform player;
	private float shakeTimer=0;
	private float shakeAmt = 0.2f;
	private float shakeTime = 2f;

	void Start(){
		player = GameObject.FindWithTag("Player").GetComponent<Transform>();
		DrillSFX = GetComponent<AudioSource>();
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		DrillOn.SetActive(true);
		DrillOff.SetActive(false);
		damageCollider.SetActive(true);
	}

	void Update (){
		float playerDist = Vector3.Distance(transform.position, player.position);
		if (playerDist <= 20f){ playerInDrillRange = true; DrillSFX.Play();} 
		//else {playerInDrillRange = false; DrillSFX.Stop();}
		
	}

	void FixedUpdate(){
		if ((playerInDrillRange)&&(!isTurnedOff)){
			shakeTimer += 0.01f;
			if (shakeTimer >= 4f){
				Quake();
				shakeTimer = 0;
			}
		}
	}

	void Quake(){
		GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>().ShakeCamera(shakeTime, shakeAmt);
	}


      public void OnTriggerEnter2D (Collider2D other){
            if(other.gameObject.tag == "Player"){
                  if (GameInventory.item6num > 2) {
						GetComponent<NPCDialogue>().enabled = false;
                        DrillOn.SetActive(false);
                        DrillOff.SetActive(true);
						damageCollider.SetActive(false);
						DrillSFX.Stop();
						isTurnedOff = true;
                        gameHandler.GetComponent<GameInventory>().InventoryRemove("item6", 3);
						
                  }
                  else {
                        Debug.Log("You need 3 keys to shut down the drill.");
                  }
            }
      }

}