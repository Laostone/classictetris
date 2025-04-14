using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassicTetris 
{
    public class GameEndManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject playerInputsName;

        private void CompareFinalScores() 
        {
            if(Score.score > ScoreManager.Instance.LoadScores().entries[9].score) 
            {
                playerInputsName.SetActive(!playerInputsName.activeSelf);
            }
        }



        // Start is called before the first frame update
        void Start()
        {
            CompareFinalScores();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

