using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using test11;

namespace test11
{
    public class ScriptableObjectsChanger : MonoBehaviour
    {
        [SerializeField] private ScriptableObject[] _scriptableObjects;
        [SerializeField] private WorldDisplay _worldDisplay;

        private void Awake() {
            _worldDisplay.DisplayWorld((World)_scriptableObjects[0]);
        }
    }
}
