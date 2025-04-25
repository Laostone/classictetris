using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassicTetris
{
    public class BirthPoint : MonoBehaviour
    {
        private static BirthPoint _instance;
        public static BirthPoint Instance 
        {
            get
            {
                if (_instance == null) 
                {
                    _instance = FindObjectOfType<BirthPoint>();
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


        [SerializeField]
        private GameObject[] blockPrefabs;

        private void BlockRandomBorn()
        {
            int randomIndex = Random.Range(0, blockPrefabs.Length);
            if (blockPrefabs.Length == 0)
            {
                Debug.LogError("No block prefabs are assigned. Please assign block prefabs in the Inspector.");
                return;
            }
            if (blockPrefabs[randomIndex].name == "BlockO")
            {
                Vector3 spawnPosition = this.transform.position;
                spawnPosition += new Vector3(-0.25f, -0.25f, 0);
                Instantiate(blockPrefabs[randomIndex], spawnPosition, Quaternion.identity);
                Score.oCount = Score.oCount + 1;
            }
            if (blockPrefabs[randomIndex].name == "BlockZ") 
            {
                Vector3 spawnPosition = this.transform.position;
                spawnPosition += new Vector3(0, -0.5f, 0);
                Instantiate(blockPrefabs[randomIndex], spawnPosition, Quaternion.identity);
                Score.zCount = Score.zCount + 1;
            }
            if (blockPrefabs[randomIndex].name == "BlockI")
            {
                Instantiate(blockPrefabs[randomIndex], this.transform.position, Quaternion.identity);
                Score.iCount = Score.iCount + 1;
            }
            if (blockPrefabs[randomIndex].name == "BlockJ")
            {
                Instantiate(blockPrefabs[randomIndex], this.transform.position, Quaternion.identity);
                Score.jCount = Score.jCount + 1;
            }
            if (blockPrefabs[randomIndex].name == "BlockL")
            {
                Instantiate(blockPrefabs[randomIndex], this.transform.position, Quaternion.identity);
                Score.lCount = Score.lCount + 1;
            }
            if (blockPrefabs[randomIndex].name == "BlockS")
            {
                Instantiate(blockPrefabs[randomIndex], this.transform.position, Quaternion.identity);
                Score.sCount = Score.sCount + 1;
            }
            if (blockPrefabs[randomIndex].name == "BlockT")
            {
                Instantiate(blockPrefabs[randomIndex], this.transform.position, Quaternion.identity);
                Score.tCount = Score.tCount + 1;
            }
        }

        public void BlockGenerateNext() 
        {
            string nextBlockName = NextPoint.Instance.ReturnNextBlockName();
            if (nextBlockName == "NBlockI(Clone)")
            {
                Instantiate(blockPrefabs[0], this.transform.position, Quaternion.identity);
                Score.iCount = Score.iCount + 1;
            }
            if (nextBlockName == "NBlockJ(Clone)")
            {
                Instantiate(blockPrefabs[1], this.transform.position, Quaternion.identity);
                Score.jCount = Score.jCount + 1;
            }
            if (nextBlockName == "NBlockL(Clone)") 
            {
                Instantiate(blockPrefabs[2], this.transform.position, Quaternion.identity);
                Score.lCount = Score.lCount + 1;
            }
            if (nextBlockName == "NBlockO(Clone)") 
            {
                Vector3 spawnPosition = this.transform.position;
                spawnPosition += new Vector3(-0.25f, -0.25f, 0);
                Instantiate(blockPrefabs[3], spawnPosition, Quaternion.identity);
                Score.oCount = Score.oCount + 1;
            }
            if (nextBlockName == "NBlockS(Clone)")
            {
                Instantiate(blockPrefabs[4], this.transform.position, Quaternion.identity);
                Score.sCount = Score.sCount + 1;
            }
            if (nextBlockName == "NBlockT(Clone)") 
            {
                Instantiate(blockPrefabs[5], this.transform.position, Quaternion.identity);
                Score.tCount = Score.tCount + 1;
            }
            if (nextBlockName == "NBlockZ(Clone)")
            {
                Vector3 spawnPosition = this.transform.position;
                spawnPosition += new Vector3(0, -0.5f, 0);
                Instantiate(blockPrefabs[6], spawnPosition, Quaternion.identity);
                Score.zCount = Score.zCount + 1;
            }
        }


        // Start is called before the first frame update
        void Start()
        {
            BlockRandomBorn();
        }

        void OnDestroy()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

