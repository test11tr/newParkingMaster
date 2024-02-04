using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

namespace test11
{
    public class Testing : MonoBehaviour
    {
        public VInspectorData vInspectorData;

        [Button("Test Button (func)")]
        void TestButton()
        {
            print("Test Button pressed");
        }

        [Button("Test Button (bool)")]
        [ButtonSize(50)]
        public bool TestBoolButtonBig;

        [Variants("Hava", "Su", "Toprak", "Tahta")]
        public string TestVariant;

        public SerializedDictionary<string, Color> colorDictionary;

        [Foldout("Floats")]
        public float testFloat1;
        public float testFloat2;
        public float testFloat3;
        public float testFloat4;
        public float testFloat5;

        [Foldout("Strings")]
        public string testString1;
        public string testString2;
        public string testString3;
        public string testString4;
        public string testString5;

        [Foldout("Random")]
        public int testIntS1;
        public float testFloatS1;
        public bool testBoolS1;

        [Tab("Floats")]
        public float testFloat11;
        public float testFloat22;
        public float testFloat33;
        public float testFloat44;
        public float testFloat55;

        [Tab("Strings")]
        public string testString11;
        public string testString22;
        public string testString33;
        public string testString44;
        public string testString55;
        
    }
}
