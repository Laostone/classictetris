using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ClassicTetris
{
    public class FinalLevel : MonoBehaviour
    {
        public TMP_Text level;

        // Update is called once per frame
        void Update()
        {
            level.text = "" + Score.level;
        }
    }
}