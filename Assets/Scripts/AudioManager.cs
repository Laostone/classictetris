using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassicTetris 
{
    public class AudioManager : MonoBehaviour
    {
        public AudioClip blockhold;
        public AudioClip click;
        public AudioClip eliminateBlocks;
        private AudioSource audioSource;
        private static AudioManager _instance;
        public static AudioManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<AudioManager>();
                }
                return _instance;
            }
            private set
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
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }

        void Start()
        {
            Block.OnAnyBlockSteady += PlayBlockHoldSound;
            Block.OnAnyBlockSteady += PlayLineClearSound;
        }

        void OnDestroy()
        {
            Block.OnAnyBlockSteady -= PlayBlockHoldSound;
            Block.OnAnyBlockSteady -= PlayLineClearSound;
        }

        private void PlayBlockHoldSound()
        {
            if(!(GridManager.Instance.IsHaveFullLine()))
            {
                audioSource.PlayOneShot(blockhold);
            }
        }

        private void PlayLineClearSound()
        {
            if(GridManager.Instance.IsHaveFullLine())
            {
                audioSource.PlayOneShot(eliminateBlocks);
            }
        }

        public void PlayClick()
        {
            audioSource.PlayOneShot(click);
        }

    }
}

