using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassicTetris 
{
    public class NextPoint : MonoBehaviour
    {
        private static NextPoint _instance;
        public static NextPoint Instance 
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<NextPoint>();
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



        [SerializeField] private GameObject[] blockPrefabs;
        public static GameObject currentInstance; 

        public void GenerateRandomNext() 
        {
            if (blockPrefabs.Length == 0)
            {
                Debug.LogError("No block prefabs are assigned. Please assign block prefabs in the Inspector.");
                return;
            }
            int randomIndex = Random.Range(0, blockPrefabs.Length);
            currentInstance = Instantiate(blockPrefabs[randomIndex], this.transform.position, Quaternion.identity);
        }

        public void DestroyNblocks()
        {
            Destroy(currentInstance);
        }

        public string ReturnNextBlockName() 
        {
            return currentInstance.name;
        }

        void Start()
        {
            GenerateRandomNext();
        }

        void OnDestroy()
        {

        }

        void Update()
        {

        }
    }
}

