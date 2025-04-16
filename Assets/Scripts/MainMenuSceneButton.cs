using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClassicTetris 
{
    public class MainMenuSceneButton : MonoBehaviour
    {
        [SerializeField]
        private GameObject rankingCanvas;

        public void ClickStartButton()
        {
            SceneManager.LoadScene(1);
        }

        public void ClickRankingButton()
        {
            rankingCanvas.SetActive(!rankingCanvas.activeSelf);
        }
        
        public void ClickExitButton()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;  
            #else
                Application.Quit();  
            #endif
        }

        public void PlaytheSound()
        {
            AudioManager.Instance.PlayClick();
        }

    }
}
