using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ClassicTetris 
{
    public class FinalScore : MonoBehaviour
    {
        public TMP_Text score;

        // Update is called once per frame
        void Update()
        {
            score.text = "" + Score.score;
        }
    }
}

