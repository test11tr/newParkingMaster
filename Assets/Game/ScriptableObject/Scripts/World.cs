using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test11
{
    [CreateAssetMenu(fileName = "New World", menuName = "ParkingMaster/World")]
    public class World : ScriptableObject
    {
       public int worldIndex;
       public string worldName;
       public string worldDescription;
       public Sprite worldImage;
    }
}
