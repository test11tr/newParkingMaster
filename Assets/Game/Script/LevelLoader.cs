using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test11
{
    public class LevelLoader : MonoBehaviour
    {
        public GameObject[] Levels;

        void Start ()
        {
            // First we want to disable all levels
            for (int a = 0; a < Levels.Length; a++)
                Levels [a].SetActive (false);

            // activate level based on selected on main menu
            if (PlayerPrefs.GetInt ("LevelID") <= Levels.Length)
                Levels [PlayerPrefs.GetInt ("LevelID")].SetActive (true);
            else
                Levels [Levels.Length].SetActive (true);
        }
    }
}
