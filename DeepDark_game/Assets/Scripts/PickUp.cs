using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour{

      private GameHandler gameHandler;
      //public playerVFX playerPowerupVFX;
	  
	  public bool isTorch = true;
      public bool isHelmet = false;
      public bool isBattery = false;
      public bool isHealth = false;
	  public bool isSpore = false;
	  public bool isKey = false;

	  
	  public int healthBoost = 10;
	  public AudioSource pickup;


      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
      }

	public void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player"){
			GetComponent<Collider2D>().enabled = false;
			//GetComponent<AudioSource>().Play();
			StartCoroutine(DestroyThis());

			if (isTorch == true) {
				gameHandler.GetComponent<GameInventory>().InventoryAdd("item1");
				pickup.Play();
			}

			else if (isHelmet == true) {
				//only one helmet:
				if ((GameInventory.item2num == 0)&&(GameHandler_Lights.helmetOnHead==false)){
					gameHandler.GetComponent<GameInventory>().InventoryAdd("item2");
					pickup.Play();
				}
			}
			
			else if (isBattery == true) {
					gameHandler.GetComponent<GameInventory>().InventoryAdd("item3");
					pickup.Play();
			}

			else if (isHealth == true) {
				if (GameHandler.playerHealth < gameHandler.StartPlayerHealth){
					gameHandler.playerGetHit(healthBoost * -1);
				} else {
					gameHandler.GetComponent<GameInventory>().InventoryAdd("item4");
					pickup.Play();
				}
				
				//playerPowerupVFX.powerup();
			}

			else if (isSpore == true) {
				gameHandler.GetComponent<GameInventory>().InventoryAdd("item5");
				pickup.Play();
			}
			 if (isKey == true) {
                        //Add the key to the inventory. Touch a door to remove a key and open the door.
                        gameHandler.GetComponent<GameInventory>().InventoryAdd("item6");
                  }
			
			else {Debug.Log("This pickup gave you nothing!");}

		}
	}

	IEnumerator DestroyThis(){
		yield return new WaitForSeconds(0.3f);
		Destroy(gameObject);
	}

}