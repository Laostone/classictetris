using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassicTetris 
{
    public class Score : MonoBehaviour
    {
        private static Score _instance;
        public static Score Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<Score>();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        public static int score = 0;
        public static int Eliminate = 0;
        public static int level = 0;

        public static int iCount = 0;
        public static int jCount = 0;
        public static int lCount = 0;
        public static int oCount = 0;
        public static int sCount = 0;
        public static int tCount = 0;
        public static int zCount = 0;


        private void UpGrade()
        {
            int i = level;
            Eliminate++;
            level = Eliminate / 10;
            if (level - i == 1)
            {
                Block.UpgradeDetection();
            }
        }

        private void IncreaseScore(int y)
        {
            switch(y)
            {
                case 0:
                    break;
                case 1:
                    score += (40 * (level + 1));
                    break;
                case 2:
                    score += (100 * (level + 1));
                    break;
                case 3:
                    score += (300 * (level + 1));
                    break;
                case 4:
                    score += (1200 * (level + 1));
                    break;
            }
        }

        public static void ResetScore() 
        {
            score = 0;
            Eliminate = 0;
            level = 0;
            iCount = 0;
            jCount = 0;
            lCount = 0;
            oCount = 0;
            sCount = 0;
            tCount = 0;
            zCount = 0;
        }

        public bool IsBreakRecord()
        {
            if(score > ScoreManager.Instance.LoadScores().entries[9].score)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            GridManager.OnAnyClearLine += UpGrade;
            GridManager.OnAllClearLine += IncreaseScore;
        }

        void OnDestroy()
        {
            GridManager.OnAnyClearLine -= UpGrade;
            GridManager.OnAllClearLine -= IncreaseScore;
        }



        // Update is called once per frame
        void Update()
        {
            
        }
    }
}

