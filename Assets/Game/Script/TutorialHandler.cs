using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test11
{
    public class TutorialHandler : MonoBehaviour
    {
        public GameObject[] _tutorialReferences;

        void Start()
        {
            if(PlayerPrefs.GetInt("01-Mall" + "PassedLevels") < 1)
            {
                _tutorialReferences[0].SetActive(true);
            }
        }

        public void SetTrue(GameObject target)
        {
            target.SetActive(true);
        }

        public void SetFalse(GameObject target)
        {
            target.SetActive(false);
        }
    }
}
