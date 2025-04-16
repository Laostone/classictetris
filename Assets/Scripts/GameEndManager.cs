using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassicTetris 
{
    public class GameEndManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject playerInputsName;

        void Start()
        {
            CompareFinalScores();
        }

        private void CompareFinalScores() 
        {
            if(Score.score > ScoreManager.Instance.LoadScores().entries[9].score) 
            {
                playerInputsName.SetActive(!playerInputsName.activeSelf);
            }
        }
    }
}

