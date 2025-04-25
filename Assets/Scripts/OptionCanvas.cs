using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ClassicTetris
{
    public class OptionCanvas : MonoBehaviour
    {
        [SerializeField]
        private GameObject keyPromptCancas;

        [SerializeField]
        private GameObject optionCanvas;
        [SerializeField]
        private TMP_Dropdown resolutionDropdown; 
        [SerializeField]
        private TMP_Dropdown displayModeDropdown; 
        [SerializeField]
        private TMP_Dropdown languageDropdown; 
        [SerializeField]
        private Slider volumeSlider;
        [SerializeField]
        private TMP_Text leftButtonTextTMP;
        [SerializeField]
        private TMP_Text rightButtonTextTMP;
        [SerializeField]
        private TMP_Text downButtonTextTMP;
        [SerializeField]
        private TMP_Text rotateButtonTextTMP;

        private bool isWaitingForRightInput = false;
        private bool isWaitingForLeftInput = false;
        private bool isWaitingForDownInput = false;
        private bool isWaitingForRotateInput = false;

        void Start()
        {
            UpdateOptionCanvas();
        }

        void OnEnable()
        {
            UpdateOptionCanvas();
        }

        void Update()
        {
            DetectingInputKey();
        }

        public void HideCanvas()
        {
            optionCanvas.SetActive(false);
        }

        public void PlaytheSound()
        {
            AudioManager.Instance.PlayClick();
        }

        public void LanguageDropdownChange(int index)
        {
            SettingManager.Instance.SetLanguage(index);
        }

        public void VolumeSliderChange(float value)
        {
            SettingManager.Instance.SetVolume(value);
        }

        public void ResolutionDropdownChange(int index)
        {
            SettingManager.Instance.SetResolution(index);
        }

        public void DisplayModeDropdownChange(int index)
        {
            SettingManager.Instance.SetDisplayMode(index);
        }

        private void UpdateOptionCanvas()
        {
            resolutionDropdown.value = PlayerPrefs.GetInt("Resolution", 0); 

            displayModeDropdown.value = PlayerPrefs.GetInt("DisplayMode", 0); 

            volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1.0f);

            languageDropdown.value = PlayerPrefs.GetInt("Language", 0);

            leftButtonTextTMP.text = PlayerPrefs.GetString("Left", "LeftArrow");

            rightButtonTextTMP.text = PlayerPrefs.GetString("Right", "RightArrow");

            downButtonTextTMP.text = PlayerPrefs.GetString("Down", "DownArrow");

            rotateButtonTextTMP.text = PlayerPrefs.GetString("Rotate", "UpArrow");
        }

        public void ClickRinghtButton()
        {
            keyPromptCancas.SetActive(!keyPromptCancas.activeSelf);
            isWaitingForRightInput = true;
        }
        public void ClickLefttButton()
        {
            keyPromptCancas.SetActive(!keyPromptCancas.activeSelf);
            isWaitingForLeftInput = true;
        }
        public void ClickDownButton()
        {
            keyPromptCancas.SetActive(!keyPromptCancas.activeSelf);
            isWaitingForDownInput = true;
        }
        public void ClickRotateButton()
        {
            keyPromptCancas.SetActive(!keyPromptCancas.activeSelf);
            isWaitingForRotateInput = true;
        }

        private void DetectingInputKey()
        {
            if (isWaitingForRightInput)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    keyPromptCancas.SetActive(false);
                    isWaitingForRightInput = false;
                }
                else
                {
                    foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
                    {
                        if (Input.GetKeyDown(key))
                        {
                            SettingManager.Instance.SetRight(key.ToString());
                            rightButtonTextTMP.text = key.ToString();
                            keyPromptCancas.SetActive(false);
                            isWaitingForRightInput = false;
                        }
                    }
                    
                }
            }

            if (isWaitingForLeftInput)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    keyPromptCancas.SetActive(false);
                    isWaitingForLeftInput = false;
                }
                else
                {
                    foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
                    {
                        if (Input.GetKeyDown(key))
                        {
                            SettingManager.Instance.SetLeft(key.ToString());
                            leftButtonTextTMP.text = key.ToString();
                            keyPromptCancas.SetActive(false);
                            isWaitingForLeftInput = false;
                        }
                    }
                    
                }
            }

            if (isWaitingForDownInput)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    keyPromptCancas.SetActive(false);
                    isWaitingForDownInput = false;
                }
                else
                {
                    foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
                    {
                        if (Input.GetKeyDown(key))
                        {
                            SettingManager.Instance.SetDown(key.ToString());
                            downButtonTextTMP.text = key.ToString();
                            keyPromptCancas.SetActive(false);
                            isWaitingForDownInput = false;
                        }
                    }
                    
                }
            }

            if (isWaitingForRotateInput)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    keyPromptCancas.SetActive(false);
                    isWaitingForRotateInput = false;
                }
                else
                {
                    foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
                    {
                        if (Input.GetKeyDown(key))
                        {
                            SettingManager.Instance.SetRotate(key.ToString());
                            rotateButtonTextTMP.text = key.ToString();
                            keyPromptCancas.SetActive(false);
                            isWaitingForRotateInput = false;
                        }
                    }
                    
                }
            }
        }
    }
}

