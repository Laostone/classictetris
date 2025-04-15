using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassicTetris 
{
    public class Block : MonoBehaviour
    {
        public static event System.Action OnAnyBlockSteady;
        public static event System.Action OnGameOver;

        private static float blockFallTimeInterval = 1f;

        private float blockFallDistanceInterval = 0.5f;
        

        private static float _timer = 0f;
        private static float _timer1 = 0f;


        public void BlockFalling()
        {
            if (Time.time - _timer >= blockFallTimeInterval)
            {
                this.transform.position += new Vector3(0, -blockFallDistanceInterval, 0);
                if (!(GridManager.Instance.IsValidPos(this)))
                {
                    this.transform.position += new Vector3(0, blockFallDistanceInterval, 0);
                    GridManager.Instance.LockBlockInGrid(this);
                    this.enabled = false;
                    OnAnyBlockSteady?.Invoke();
                }
                _timer = Time.time;
            }
        }

        private void BlockMoveLeft() 
        {
            this.transform.position += new Vector3(-blockFallDistanceInterval, 0, 0);
            if(!(GridManager.Instance.IsValidPos(this)))
            {
                this.transform.position += new Vector3(blockFallDistanceInterval, 0, 0);
            }
        }

        private void BlockMoveRight()
        {
            this.transform.position += new Vector3(blockFallDistanceInterval, 0, 0);
            if (!(GridManager.Instance.IsValidPos(this)))
            {
                this.transform.position += new Vector3(-blockFallDistanceInterval, 0, 0);
            }
        }

        private void BlockMoveDown()
        {
            this.transform.position += new Vector3(0, -blockFallDistanceInterval, 0);
            if (!(GridManager.Instance.IsValidPos(this)))
            {
                this.transform.position += new Vector3(0, blockFallDistanceInterval, 0);
            }
        }

        private void BlockRotate()
        {
            this.transform.Rotate(0, 0, 90f);
            if (!(GridManager.Instance.IsValidPos(this)))
            {
                this.transform.Rotate(0, 0, -90f);
            }
        }

        private void BlockMove()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                BlockMoveLeft();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                BlockMoveRight();
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                BlockRotate();
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (Time.time - _timer1 >= 0.05f)
                {
                    BlockMoveDown();
                    _timer1 = Time.time;
                }

            }
        }

        public static void UpgradeDetection()
        {
            blockFallTimeInterval = blockFallTimeInterval * 0.9f;
        }

        public static void ResetTime()
        {
            blockFallTimeInterval = 1f;
            _timer = 0f;
            _timer1 = 0f;
        }

        private void IsGameOver()
        {
            if (!(GridManager.Instance.IsValidPos(this))) 
            {
                Destroy(this.gameObject);
                Debug.Log("��Ϸ����");
                OnGameOver?.Invoke();
            }
        }


        // Start is called before the first frame update
        void Start()
        {
            IsGameOver();
        }

        // Update is called once per frame
        void Update()
        {
            BlockFalling();
            BlockMove();
        }
    }
}

