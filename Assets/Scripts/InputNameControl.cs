using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassicTetris 
{
    public class InputNameControl : MonoBehaviour
    {
        [SerializeField]
        private GameObject rankingCanvas;
        [SerializeField]
        private GameObject playerInputCanvas;

        public void InputToRanking(string name) 
        {
            ScoreManager.Instance.AddNewScore(name, Score.score);
            rankingCanvas.SetActive(!rankingCanvas.activeSelf);
            playerInputCanvas.SetActive(false);
        }


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

