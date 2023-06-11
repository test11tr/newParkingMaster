using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace test11.Managers
{
    public class UIManager : MonoBehaviour
    {
        public void ReloadScene(){
            string currentScene = SceneManager.GetActiveScene ().name; 
            SceneManager.LoadScene(currentScene);
        }

        public void LoadMainMenuScene(){
            string currentScene = SceneManager.GetActiveScene ().name; 
            SceneManager.LoadScene(currentScene);
        }
    }
}
