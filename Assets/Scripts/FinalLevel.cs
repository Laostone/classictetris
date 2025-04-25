using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ClassicTetris
{
    public class FinalLevel : MonoBehaviour
    {
        public TMP_Text level;

        void Update()
        {
            level.text = "" + Score.level;
        }
    }
}