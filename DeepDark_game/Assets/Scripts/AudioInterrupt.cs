 using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioInterrupt : MonoBehaviour {

        public AudioSource Main_Menu_Demo;
        private float stopTimestamp = 12.5f;
       
        void Update(){
                if (Input.GetKeyDown("i")) {
                        PlayMusicAtBegin();
                }
                if (Input.GetKeyDown("o")) {
                        StopMusic();
                }
                if (Input.GetKeyDown("p")) {
                        PlayMusicAtTime(stopTimestamp);
                }
        }

        public void PlayMusicAtBegin(){
                Main_Menu_Demo.time = 0.0f;
                Main_Menu_Demo.Play();
        }

        public void StopMusic(){
                stopTimestamp = Main_Menu_Demo.time;
                Debug.Log("Stopped audio at: " + stopTimestamp);
                Main_Menu_Demo.Stop();
        }

        public void PlayMusicAtTime(float timeStamp){
                if (timeStamp > Main_Menu_Demo.clip.length){
                        return;
                } else {
                        Main_Menu_Demo.time = timeStamp;
                        Main_Menu_Demo.Play();
                }
        }
}
