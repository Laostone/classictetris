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

        // 通过场景索引加载
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
                UnityEditor.EditorApplication.isPlaying = false;  // 编辑器模式下退出运行
            #else
                Application.Quit();  // 打包后退出应用程序
            #endif
        }

        public void PlaytheSound()
        {
            AudioManager.Instance.PlayClick();
        }

    }
}
