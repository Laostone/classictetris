using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ClassicTetris
{
    public class FinalLines : MonoBehaviour
    {
        public TMP_Text lines;

        // Update is called once per frame
        void Update()
        {
            lines.text = "" + Score.Eliminate;
        }
    }
}
