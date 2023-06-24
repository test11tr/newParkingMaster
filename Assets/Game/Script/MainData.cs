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
            //Camera.main.aspect = 16f / 9f;za<as>
            if(PlayerPrefs.GetInt("FirstRun", 0) != 1){
                PlayerPrefs.SetInt("FirstRun", 1);
                PlayerPrefs.SetInt("01-DrivingSchool" + "LevelNum", 1);
                PlayerPrefs.SetInt("LevelXP",1);
                PlayerPrefs.SetInt("Coins", startingCoin);
                PlayerPrefs.SetInt("Diamonds", startingDiamond);
                //unlockableWorlds
                PlayerPrefs.SetInt("World0",1);
                PlayerPrefs.SetInt("CurrentWorld",0);
                PlayerPrefs.SetInt("World1",0);
                PlayerPrefs.SetInt("World2",0);
                PlayerPrefs.SetInt("World3",0);
                //unlockableCars
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

            //Cheat
            if (Input.GetKeyDown (KeyCode.E))
                PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + 1000);

            //Cheat
            if (Input.GetKeyDown (KeyCode.D))
                PlayerPrefs.SetInt ("Diamonds", PlayerPrefs.GetInt ("Diamonds") + 1000);

            //Update Coins UI
            if(PlayerPrefs.GetInt("Coins") > 0){
                totalCoins.text = PlayerPrefs.GetInt("Coins").ToString() + " C";
            }else{
                totalCoins.text = "0 C";
            }
            
            //Update Diamonds UI
            if(PlayerPrefs.GetInt("Diamonds") > 0){
                totalDiamonds.text = PlayerPrefs.GetInt("Diamonds").ToString();
            }else{
                totalDiamonds.text = "0";
            }
        }

        public void AddMoney(){
            PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + 1000);
        }
        
        public void AddDiamond(){
            PlayerPrefs.SetInt ("Diamonds", PlayerPrefs.GetInt ("Diamonds") + 1000);
        }
    }
}
