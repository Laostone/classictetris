using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClassicTetris
{
    public class SettingManager : MonoBehaviour
    {
        private static SettingManager _instance;
        private FullScreenMode mode;
        public KeyCode leftKey;
        public KeyCode rightKey;
        public KeyCode downKey;
        public KeyCode rotateKey;


        public static SettingManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<SettingManager>();
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
        }

        void Start()
        {
            InitializationSettings();
        }

        private void InitializationSettings()
        {
            int displayModeIndex = PlayerPrefs.GetInt("DisplayMode", 0);
            SetDisplayMode(displayModeIndex);

            int resolutionIndex = PlayerPrefs.GetInt("Resolution", 0);
            SetResolution(resolutionIndex);

            float volume = PlayerPrefs.GetFloat("Volume", 1.0f);
            SetVolume(volume);

            int languageIndex = PlayerPrefs.GetInt("Language", 0);
            SetLanguage(languageIndex);

            string rightString = PlayerPrefs.GetString("Right", "RightArrow");
            SetRight(rightString);

            string leftString = PlayerPrefs.GetString("Left", "LeftArrow");
            SetLeft(leftString);

            string downString = PlayerPrefs.GetString("Down", "DownArrow");
            SetDown(downString);

            string rotateString = PlayerPrefs.GetString("Rotate", "UpArrow");
            SetRotate(rotateString);

        }

        public void SetLanguage(int index)
        {
            // 保存语言设置
            PlayerPrefs.SetInt("Language", index);
            PlayerPrefs.Save();

            switch(index)
            {
                case 0:
                    break;
                case 1:
                    break;
            }
        }

        public void SetVolume(float value)
        {
            PlayerPrefs.SetFloat("Volume", value);
            PlayerPrefs.Save();

            AudioManager.Instance.SetVolume(value);
        }

        public void SetResolution(int index)
        {
            // 保存分辨率设置
            PlayerPrefs.SetInt("Resolution", index);
            PlayerPrefs.Save();

            switch(index)
            {
                case 0:
                    Screen.SetResolution(1024, 768, mode);
                    break;
                case 1:
                    Screen.SetResolution(1152, 864, mode);
                    break;
                case 2:
                    Screen.SetResolution(1280, 768, mode);
                    break;
                case 3:
                    Screen.SetResolution(1280, 800, mode);
                    break;
                case 4:
                    Screen.SetResolution(1280, 960, mode);
                    break;
                case 5:
                    Screen.SetResolution(1360, 768, mode);
                    break;
                case 6:
                    Screen.SetResolution(1366, 768, mode);
                    break;
                case 7:
                    Screen.SetResolution(1440, 900, mode);
                    break;
                case 8:
                    Screen.SetResolution(1440, 1080, mode);
                    break;
                case 9:
                    Screen.SetResolution(1600, 900, mode);
                    break;
                case 10:
                    Screen.SetResolution(1600, 1024, mode);
                    break;
                case 11:
                    Screen.SetResolution(1600, 1200, mode);
                    break;
                case 12:
                    Screen.SetResolution(1680, 1050, mode);
                    break;
                case 13:
                    Screen.SetResolution(1920, 1080, mode);
                    break;
                case 14:
                    Screen.SetResolution(1920, 1200, mode);
                    break;
            }
        }

        public void SetDisplayMode(int index)
        {
            // 保存显示模式设置
            PlayerPrefs.SetInt("DisplayMode", index);
            PlayerPrefs.Save();

            switch(index)
            {
                case 0:
                    mode = FullScreenMode.Windowed;
                    Screen.fullScreenMode = FullScreenMode.Windowed;
                    break;
                case 1:
                    mode = FullScreenMode.FullScreenWindow;
                    Screen.fullScreenMode = mode;
                    break;
                case 2:
                    mode = FullScreenMode.ExclusiveFullScreen;
                    Screen.fullScreenMode = mode;
                    break;  
            }
        }

        public void SetLeft(string keyName)
        {
            PlayerPrefs.SetString("Left", keyName);
            PlayerPrefs.Save();
            //使用System.Enum.Parse(Type enumType, string value)这个方法，把存在“Left“里的字符串转换成typeof(KeyCode)枚举类型里的值，然后用(KeyCode)强制转换成KeyCode类型
            leftKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "LeftArrow"));
        }

        public void SetRight(string keyName)
        {
            PlayerPrefs.SetString("Right", keyName);
            PlayerPrefs.Save();
            rightKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "RightArrow"));
        }

        public void SetDown(string keyName)
        {
            PlayerPrefs.SetString("Down", keyName);
            PlayerPrefs.Save();
            downKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "DownArrow"));
        }

        public void SetRotate(string keyName)
        {
            PlayerPrefs.SetString("Rotate", keyName);
            PlayerPrefs.Save();
            rotateKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Rotate", "UpArrow"));
        }

        


    }
}