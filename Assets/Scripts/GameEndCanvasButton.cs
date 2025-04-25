using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClassicTetris 
{
    public class GameEndCanvasButton : MonoBehaviour
    {
        [SerializeField]
        private GameObject rankingCanvas;

        public void ClickTryAgain()
        {
            SceneManager.LoadScene(1);
            Score.ResetScore();
            Block.ResetTime();
        }

        public void ClickRanking()
        {
            rankingCanvas.SetActive(!rankingCanvas.activeSelf);
        }

        public void ClickReturnToMenu()
        {
            SceneManager.LoadScene(0);
            Score.ResetScore();
            Block.ResetTime();
        }

        public void PlaytheSound()
        {
            AudioManager.Instance.PlayClick();
        }

        void Start()
        {

        }

        void Update()
        {

        }
    }
}