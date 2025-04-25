using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ClassicTetris 
{
    public class RankingControl : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text[] score = new TMP_Text[10];
        [SerializeField]
        private TMP_Text[] playername = new TMP_Text[10];
        [SerializeField]
        private GameObject rankingCanvas;

        private void UpdateRanking()
        {
            for (int i = 0; i < 10; i++)
            {
                score[i].text = "" + ScoreManager.Instance.LoadScores().entries[i].score;
                playername[i].text = "" + ScoreManager.Instance.LoadScores().entries[i].playerName;
            }
        }

        public void HideCanvas()
        {
            rankingCanvas.SetActive(false);
        }

        public void PlaytheSound()
        {
            AudioManager.Instance.PlayClick();
        }

        void OnEnable()
        {
            UpdateRanking();
        }

        void Start()
        {
            UpdateRanking();
        }

        void Update()
        {

        }
    }
}

