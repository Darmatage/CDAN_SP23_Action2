
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Drill : MonoBehaviour{

      public GameHandler gameHandler;
      public GameObject DrillOn;
      public GameObject DrillOff;
public AudioSource DrillSFX;

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            DrillOn.SetActive(true);
            DrillOff.SetActive(false);
			DrillSFX.Play();
      }

      public void OnTriggerEnter2D (Collider2D other){
            if(other.gameObject.tag == "Player"){
                  if (GameInventory.item6num > 2) {
                        DrillOn.SetActive(false);
                        DrillOff.SetActive(true);
						DrillSFX.Stop();
                        gameHandler.GetComponent<GameInventory>().InventoryRemove("item6", 1);
                  }
                  else {
                        Debug.Log("You need a key to enter.");
                  }
            }
      }

}