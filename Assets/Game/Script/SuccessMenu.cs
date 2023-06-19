using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using test11.Managers;

namespace test11
{
    public class SuccessMenu : MonoBehaviour
    {
        [Header("Success Menu Manager")]
        public GameObject LoadingMenu;
        [HideInInspector]public ParkingManager _parkingManager;
        public string mainMenu = "00-MainMenu" ;
        private string levelName;

        void Start ()
        {
            levelName = SceneManager.GetActiveScene().name;
             if (_parkingManager == null)
            {
                _parkingManager = GameObject.FindGameObjectWithTag("parkingManager").GetComponent<ParkingManager>();
            }
        }

        // SuccessMenu continue button
        public void Continue ()
        {
            LoadingMenu.SetActive(true);
            PlayerPrefs.SetInt (levelName+"LevelID", PlayerPrefs.GetInt (levelName+"LevelID") + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Retry ()
        {
            LoadingMenu.SetActive(true);
            SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
        }

        public void Exit ()
        {
            LoadingMenu.SetActive(true);
            SceneManager.LoadScene(mainMenu);
        }
    }
}
