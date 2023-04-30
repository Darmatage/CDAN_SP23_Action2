using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class LockedDoor : MonoBehaviour{

      public GameHandler gameHandler;
      public GameObject doorLocked;
      public GameObject doorOpened;
	  public GameObject msg_needKey;
	  private bool isLocked = true; 

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            doorLocked.SetActive(true);
            doorOpened.SetActive(false);
			msg_needKey.SetActive(false);
      }

      public void OnTriggerEnter2D (Collider2D other){
            if((other.gameObject.tag == "Player")&&(isLocked == true)){
                  if (GameInventory.item6num > 0) {
                        doorLocked.SetActive(false);
                        doorOpened.SetActive(true);
						isLocked = false; 
                        gameHandler.GetComponent<GameInventory>().InventoryRemove("item6", 1);
                  }
                  else {
					  msg_needKey.SetActive(true);
                        Debug.Log("You need a key to enter.");
                  }
            }
      }
	  
	  
	   public void OnTriggerExit2D (Collider2D other){
            if(other.gameObject.tag == "Player"){
					  msg_needKey.SetActive(false);
            }
      }

}