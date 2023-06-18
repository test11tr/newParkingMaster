using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test11
{
    public class MainData : MonoBehaviour
    {
        public GameObject Loading;
        public int startingCoin;

        private void Awake() {
            // 1 => true, 0 => false
            if(PlayerPrefs.GetInt("FirstRun") != 1){
                PlayerPrefs.SetInt("FirstRun", 1);
                PlayerPrefs.SetInt("LevelNum", 1);
                PlayerPrefs.SetInt("LevelXP",1);
                PlayerPrefs.SetInt("Coins", startingCoin);
                PlayerPrefs.SetInt("Car0",1);
            }
        }

        private void Update() {
            if (Input.GetKeyDown (KeyCode.H)) {
			PlayerPrefs.DeleteAll ();
			Debug.Log ("PlayerPrefs.DeleteAll ();");
            }

            if (Input.GetKeyDown (KeyCode.E))
                PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + 1000);
        }
    }
}
