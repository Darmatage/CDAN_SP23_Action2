
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Drill : MonoBehaviour{

	public GameHandler gameHandler;
	public GameObject DrillOn;
	public GameObject DrillOff;
	public AudioSource DrillSFX;
	public GameObject damageCollider;

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            DrillOn.SetActive(true);
            DrillOff.SetActive(false);
			damageCollider.SetActive(true);
			DrillSFX.Play();
      }

      public void OnTriggerEnter2D (Collider2D other){
            if(other.gameObject.tag == "Player"){
                  if (GameInventory.item6num > 2) {
						GetComponent<NPCDialogue>().enabled = false;
                        DrillOn.SetActive(false);
                        DrillOff.SetActive(true);
						damageCollider.SetActive(false);
						DrillSFX.Stop();
                        gameHandler.GetComponent<GameInventory>().InventoryRemove("item6", 3);
						
                  }
                  else {
                        Debug.Log("You need 3 keys to shut down the drill.");
                  }
            }
      }

}