using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace test11.Managers
{
    public class UIManager : MonoBehaviour
    {
        public void SetTrue (GameObject target)
        {
            target.SetActive (true);
        }

        public void SetFalse (GameObject target)
        {
            target.SetActive (false);
        }

        public void ReloadScene(){
            string currentScene = SceneManager.GetActiveScene ().name; 
            SceneManager.LoadScene(currentScene);
        }

        public void LoadMainMenuScene(){
            SceneManager.LoadScene("00-MainMenu");
        }
    }
}
