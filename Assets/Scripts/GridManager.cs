using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassicTetris 
{
    public class GridManager : MonoBehaviour
    {
        public static event System.Action OnAnyClearLine;
        public static event System.Action OnAllClearLineAction;

        public delegate void OnAllClearLineHandler(int y);
        public static event OnAllClearLineHandler OnAllClearLine;

        private float minX = -2.25f; 
        private float minY = -4.75f; 
        private int visibleHeight = 20;
        private const int width = 10;
        private const int totalHeight = 22; 

        private float blockFallDistanceInterval = 0.5f;

        private Transform[,] map = new Transform[width, totalHeight];

        private static GridManager _instance;
        public static GridManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<GridManager>();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        void Start()
        {
            Block.OnAnyBlockSteady += CheckAndClearLinesCoroutine;
        }

        void OnDestroy()
        {
            Block.OnAnyBlockSteady -= CheckAndClearLinesCoroutine;
        }


        public void LockBlockInGrid(Block block)
        {
            foreach (Transform child in block.transform)
            {
                int x = Mathf.RoundToInt((child.position.x - minX) / blockFallDistanceInterval);
                int y = Mathf.RoundToInt((child.position.y - minY) / blockFallDistanceInterval);
                map[x, y] = child;
            }
        }

        public bool IsValidPos(Block block)
        {
            foreach (Transform child in block.transform)
            {
                int x = Mathf.RoundToInt((child.position.x - minX) / blockFallDistanceInterval);
                int y = Mathf.RoundToInt((child.position.y - minY) / blockFallDistanceInterval);
                if (!(x >= 0 && x < width && y >= 0))
                {
                    return false;
                }
                if (map[x, y] != null)
                {
                    return false;
                }
            }
            return true;
        }
        
        IEnumerator CheckAndClearLines()
        {
            int linesCleared = 0;
            ClearAllLinesAnimation();
            yield return new WaitForSeconds(0.25f);
            for (int y = 0; y < visibleHeight; y++)
            {
                if (IsLineFull(y))
                {
                    ClearLine(y);
                    MoveLinesDown(y);
                    y--;
                    linesCleared++;
                }
            }
            OnAllClearLine?.Invoke(linesCleared);
            OnAllClearLineAction?.Invoke();
        }

        private void CheckAndClearLinesCoroutine()
        {
            StartCoroutine(CheckAndClearLines());
        }
        
        private bool IsLineFull(int y)
        {
            for (int x = 0; x < width; x++)
            {
                if (map[x, y] == null)
                {
                    return false;
                }
            }
            return true;
        }

        public void ClearLine(int y)
        {
            for (int x = 0; x < width; x++)
            {
                Destroy(map[x, y].gameObject);
                map[x, y] = null;
            }
            OnAnyClearLine?.Invoke();
        }

        private void MoveLinesDown(int startY)
        {
            for (int y = startY; y < visibleHeight - 1; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (map[x, y + 1] != null)
                    {
                        map[x, y + 1].gameObject.transform.position += new Vector3(0, -0.5f, 0);
                    }
                    map[x, y] = map[x, y + 1];
                }
            }
        }

        public bool IsHaveFullLine()
        {
            for (int y = 0; y < visibleHeight; y++)
            {
                int count = 0;
                for(int x = 0; x < width; x++)
                {
                    if (map[x, y] == null)
                    {
                        break;
                    }
                    count++;
                    if (count == width)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void ClearAllLinesAnimation()
        {
            List<int> fullLines = new List<int>();

            for (int y = 0; y < visibleHeight; y++)
            {
                bool isFull = true;
                for (int x = 0; x < width; x++)
                {
                    if (map[x, y] == null)
                    {
                        isFull = false;
                        break;
                    }
                }
                if (isFull)
                {
                    fullLines.Add(y);
                }
            }

            foreach (int y in fullLines)
            {
                for (int x = 0; x < width; x++)
                {
                    StartCoroutine(BlockEliminationAnimation(y));
                }
            }
        }

        IEnumerator BlockEliminationAnimation(int y)
        {
            for (int x = 0; x < width; x++)
            {
                map[x, y].gameObject.transform.localScale = new Vector3(0, 0, 0);
                yield return new WaitForSeconds(0.025f);
            }
        }

    }
}

