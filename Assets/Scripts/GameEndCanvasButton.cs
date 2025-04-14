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
        }

        public void PlaytheSound()
        {
            AudioManager.Instance.PlayClick();
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