using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningComicNavigation : MonoBehaviour{
	//this script goes onto the MainCamera in a scene with a series of comic panels
	
	public string nextScene = "level1";
	public GameObject[] panels;
	private int panelsLength;
	private int currentPanel = 0;
	private Vector3 newPos;
	private float camSpeed = 4f;
	public GameObject buttonBack;
	public bool canShake = false;
	public int panelToShake = 3;

    void Start(){
        panelsLength = panels.Length;
		Vector3 initialPos = panels[0].transform.position;
		transform.position = new Vector3 (initialPos.x, initialPos.y, transform.position.z);
		buttonBack.SetActive(false);
    }

	void FixedUpdate () {
            Vector2 pos = Vector2.Lerp ((Vector2)transform.position, (Vector2)newPos, camSpeed * Time.fixedDeltaTime);
            transform.position = new Vector3 (pos.x, pos.y, transform.position.z);
	}


    // Update is called once per frame
    public void PanelNext(){
		if (currentPanel < (panelsLength - 1)){
		currentPanel ++;
		buttonBack.SetActive(true);
		newPos = panels[currentPanel].transform.position;
			if ((canShake==true)&&(currentPanel == (panelToShake-1))){
				GetComponent<CameraShake>().ShakeCamera(1f, 0.3f);
			}
		}
		else {
			SceneManager.LoadScene(nextScene);
		}
    }
	
	public void PanelBack(){
		if (currentPanel > 0){
			currentPanel --;
			newPos = panels[currentPanel].transform.position;
			if ((canShake==true)&&(currentPanel == (panelToShake-1))){
				GetComponent<CameraShake>().ShakeCamera(1f, 0.3f);
			}
			if (currentPanel == 0){
				buttonBack.SetActive(false);
			}
		}
    }
	
	
}
