using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassicTetris 
{
    public class GridManager : MonoBehaviour
    {
        public static event System.Action OnAnyClearLine;

        public delegate void OnAllClearLineHandler(int y);
        public static event OnAllClearLineHandler OnAllClearLine;

        private float minX = -2.25f; //����ǰ��ȷ���������С��(0,0)�ǵ�ͼ���ĵ�,����ӳ���������
        private float minY = -4.75f; //����ǰ��ȷ���������С��(0,0)�ǵ�ͼ���ĵ�,����ӳ���������
        private int height = 20;
        private const int width = 10;
        private const int _height = 22; //����ʵ�ʸ߶�

        private float blockFallDistanceInterval = 0.5f;

        private Transform[,] map = new Transform[width, _height];


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

        private void CheckAndClearLines()
        {
            int linesCleared = 0;
            for (int y = 0; y < height; y++)
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

        private void ClearLine(int y)
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
            for (int y = startY; y < height - 1; y++)
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


        // Start is called before the first frame update
        void Start()
        {
            Block.OnAnyBlockSteady += CheckAndClearLines;
        }

        void OnDestroy()
        {
            Block.OnAnyBlockSteady -= CheckAndClearLines;
        }

        // Update is called once per frame
        void Update()   
        {

        }
    }
}

