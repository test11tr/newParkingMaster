using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test11
{
    public class Checkpoint : MonoBehaviour
    {
        CheckpointManager _checkpointManager;

        void Awake()
        {
            _checkpointManager = GetComponentInParent<CheckpointManager> ();
        }

        void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag ("Player")) {
                _checkpointManager.NextCheckpoint ();
                gameObject.SetActive (false);
            }
        }
    }
}
