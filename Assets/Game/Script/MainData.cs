using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace test11
{
    public class MainData : MonoBehaviour
    {
        public GameObject Loading;
        public int startingCoin;
        public int startingDiamond;
        public Object defaultFirstWorld;
        public TMP_Text totalCoins;
        public TMP_Text totalDiamonds;

        private void Awake() {
            // 1 => true, 0 => false
            if(PlayerPrefs.GetInt("FirstRun") != 1){
                PlayerPrefs.SetInt("FirstRun", 1);
                PlayerPrefs.SetInt(defaultFirstWorld.name + "LevelNum", 1);
                PlayerPrefs.SetInt("LevelXP",1);
                PlayerPrefs.SetInt("Coins", startingCoin);
                PlayerPrefs.SetInt("Diamonds", startingDiamond);
                PlayerPrefs.SetInt("Car0",1);
                PlayerPrefs.SetInt("CurrentCar",0);
                PlayerPrefs.SetInt("Car1",0);
                PlayerPrefs.SetInt("Car2",0);
                PlayerPrefs.SetInt("Car3",0);
                PlayerPrefs.SetInt("Car4",0);
                PlayerPrefs.SetInt("Car5",0);
                PlayerPrefs.SetInt("Car6",0);
                PlayerPrefs.SetInt("Car7",0);
                PlayerPrefs.SetInt("Car8",0);
                PlayerPrefs.SetInt("Car9",0);
            }
        }

        private void Update() {
            if (Input.GetKeyDown (KeyCode.H)) {
			PlayerPrefs.DeleteAll ();
			Debug.Log ("PlayerPrefs.DeleteAll ();");
            }

            if (Input.GetKeyDown (KeyCode.E))
                PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + 1000);

            totalCoins.text = PlayerPrefs.GetInt("Coins").ToString() + " C";
            totalDiamonds.text = PlayerPrefs.GetInt("Diamonds").ToString();
        }
    }
}
