using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClassicTetris 
{
    public class InGameManagement : MonoBehaviour
    {
        private void GenerateSecondBlock()
        {
            BirthPoint.Instance.BlockGenerateNext();
            NextPoint.Instance.DestroyNblocks();
            NextPoint.Instance.GenerateRandomNext();
        }

        private void GameEndSettlement()
        {
            SceneManager.LoadScene(2);
        }

        // Start is called before the first frame update
        void Start()
        {
            GridManager.OnAllClearLineAction += GenerateSecondBlock;
            Block.OnGameOver += GameEndSettlement;
        }

        void OnDestroy()
        {
            GridManager.OnAllClearLineAction -= GenerateSecondBlock;
            Block.OnGameOver -= GameEndSettlement;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

