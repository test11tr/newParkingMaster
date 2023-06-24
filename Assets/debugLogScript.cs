using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace test11
{
    public class debugLogScript : MonoBehaviour
    {
        private void Awake() {
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene("00-MainMenu");
        }
    }
}
