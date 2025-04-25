using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ClassicTetris
{
    public class StatisticsCanvas : MonoBehaviour
    {
        public TMP_Text iCount;
        public TMP_Text jCount;
        public TMP_Text lCount;
        public TMP_Text oCount;
        public TMP_Text sCount;
        public TMP_Text tCount;
        public TMP_Text zCount;


        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            iCount.text = "x "+Score.iCount;
            jCount.text = "x "+Score.jCount;
            lCount.text = "x "+Score.lCount;
            oCount.text = "x "+Score.oCount;
            sCount.text = "x "+Score.sCount;
            tCount.text = "x "+Score.tCount;
            zCount.text = "x "+Score.zCount;
        }
    }
}

