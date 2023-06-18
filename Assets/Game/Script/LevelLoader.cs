using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace test11
{
    public class LevelLoader : MonoBehaviour
    {
        public GameObject[] Levels;
        private string  sceneName;
        void Awake()
        {
            sceneName = SceneManager.GetActiveScene().name;
            // First we want to disable all levels
            for (int a = 0; a < Levels.Length; a++)
                Levels [a].SetActive (false);

            // activate level based on selected on main menu
            if (PlayerPrefs.GetInt (sceneName + "LevelID") <= Levels.Length)
                Levels [PlayerPrefs.GetInt (sceneName + "LevelID")].SetActive (true);
            else
                Levels [Levels.Length].SetActive (true);
        }
    }
}
