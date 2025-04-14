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

        /*
        public void ToggleCanvas()
        {
            // 切换 Canvas 的激活状态
            rankingCanvas.SetActive(!rankingCanvas.activeSelf);
            UpdateRanking();
        }
        */

        void OnEnable()
        {
            UpdateRanking(); // 每次激活时刷新数据
        }

        // Start is called before the first frame update
        void Start()
        {
            UpdateRanking();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

