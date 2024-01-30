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
        [HideInInspector] public ParkingManager _parkingManager;
        public string mainMenu = "00-MainMenu";
        private string levelName;
        [SerializeField] public LevelLoader _levelLoader;
        [SerializeField] public GameObject _continueButton;
        private int currentIndex;

        public TMP_Text buyNewCarText;
        public GameObject notEnoughVehicleLevelMenu;


        void Start()
        {
            levelName = SceneManager.GetActiveScene().name;
            if (_parkingManager == null)
            {
                _parkingManager = GameObject.FindGameObjectWithTag("parkingManager").GetComponent<ParkingManager>();
            }
        }

        // SuccessMenu continue button
        public void Continue()
        {
            if (PlayerPrefs.GetInt(levelName + "LevelID") > 14)
            {
                if (PlayerPrefs.GetInt("CurrentCar") < 3)
                {
                    buyNewCarText.text = "Your vehicle is too old. Please buy the 3rd car or better!";
                    notEnoughVehicleLevelMenu.SetActive(true);
                }
                else
                {
                    LoadingMenu.SetActive(true);
                    if (PlayerPrefs.GetInt(levelName + "LevelID") >= _levelLoader.Levels.Length - 1)
                    {
                        SceneManager.LoadScene(mainMenu);
                        PlayerPrefs.SetInt(levelName + "LevelID", PlayerPrefs.GetInt(levelName + "LevelID"));
                    }
                    else
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        PlayerPrefs.SetInt(levelName + "LevelID", PlayerPrefs.GetInt(levelName + "LevelID") + 1);
                    }
                }
            }
            else if (PlayerPrefs.GetInt(levelName + "LevelID") > 25)
            {
                if (PlayerPrefs.GetInt("CurrentCar") < 4)
                {
                    buyNewCarText.text = "Your vehicle is too old. Please buy the 4th car or better!";
                    notEnoughVehicleLevelMenu.SetActive(true);
                }
                else
                {
                    LoadingMenu.SetActive(true);
                    if (PlayerPrefs.GetInt(levelName + "LevelID") >= _levelLoader.Levels.Length - 1)
                    {
                        SceneManager.LoadScene(mainMenu);
                        PlayerPrefs.SetInt(levelName + "LevelID", PlayerPrefs.GetInt(levelName + "LevelID"));
                    }
                    else
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        PlayerPrefs.SetInt(levelName + "LevelID", PlayerPrefs.GetInt(levelName + "LevelID") + 1);
                    }
                }
            }
            else if (PlayerPrefs.GetInt(levelName + "LevelID") > 35)
            {
                if (PlayerPrefs.GetInt("CurrentCar") < 5)
                {
                    buyNewCarText.text = "Your vehicle is too old. Please buy the 5th car or better!";
                    notEnoughVehicleLevelMenu.SetActive(true);
                }
                else
                {
                    LoadingMenu.SetActive(true);
                    if (PlayerPrefs.GetInt(levelName + "LevelID") >= _levelLoader.Levels.Length - 1)
                    {
                        SceneManager.LoadScene(mainMenu);
                        PlayerPrefs.SetInt(levelName + "LevelID", PlayerPrefs.GetInt(levelName + "LevelID"));
                    }
                    else
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        PlayerPrefs.SetInt(levelName + "LevelID", PlayerPrefs.GetInt(levelName + "LevelID") + 1);
                    }
                }
            }
            else if (PlayerPrefs.GetInt(levelName + "LevelID") > 45)
            {
                if (PlayerPrefs.GetInt("CurrentCar") < 6)
                {
                    buyNewCarText.text = "Your vehicle is too old. Please buy the 6th car or better!";
                    notEnoughVehicleLevelMenu.SetActive(true);
                }
                else
                {
                    LoadingMenu.SetActive(true);
                    if (PlayerPrefs.GetInt(levelName + "LevelID") >= _levelLoader.Levels.Length - 1)
                    {
                        SceneManager.LoadScene(mainMenu);
                        PlayerPrefs.SetInt(levelName + "LevelID", PlayerPrefs.GetInt(levelName + "LevelID"));
                    }
                    else
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        PlayerPrefs.SetInt(levelName + "LevelID", PlayerPrefs.GetInt(levelName + "LevelID") + 1);
                    }
                }
            }
            else
            {
                LoadingMenu.SetActive(true);
                if (PlayerPrefs.GetInt(levelName + "LevelID") >= _levelLoader.Levels.Length - 1)
                {
                    SceneManager.LoadScene(mainMenu);
                    PlayerPrefs.SetInt(levelName + "LevelID", PlayerPrefs.GetInt(levelName + "LevelID"));
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    PlayerPrefs.SetInt(levelName + "LevelID", PlayerPrefs.GetInt(levelName + "LevelID") + 1);
                }
            }
        }

        public void Retry()
        {
            LoadingMenu.SetActive(true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Exit()
        {
            LoadingMenu.SetActive(true);
            SceneManager.LoadScene(mainMenu);
        }
    }
}
