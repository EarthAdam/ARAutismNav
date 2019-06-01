/***
 * Author: Yunhan Li 
 * Any issue please contact yunhn.lee@gmail.com
 ***/

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace VRKeyboard.Utils {
    public class KeyboardManager : MonoBehaviour{
        #region Public Variables
        [Header("User defined")]
        [Tooltip("If the character is uppercase at the initialization")]
        public bool isUppercase = false;
        public int maxInputLength;
        
        [Header("UI Elements")]
        public Text inputText;

        [Header("Essentials")]
        public Transform characters;
        #endregion

        #region Private Variables
        private float timer;

	    private bool timeron;


        private GameObject key;
        private string Input {
            get { return inputText.text;  }
            set { inputText.text = value;  }
        }

        private Dictionary<GameObject, Text> keysDictionary = new Dictionary<GameObject, Text>();

        private bool capslockFlag;
        #endregion

        #region Monobehaviour Callbacks
        private void Awake() {
            
            /*for (int i = 0; i < characters.childCount; i++) {
                GameObject key = characters.GetChild(i).gameObject;
                Text _text = key.GetComponentInChildren<Text>();
                keysDictionary.Add(key, _text);

                key.GetComponent<Button>().onClick.AddListener(() => {
                    GenerateInput(_text.text);
                });* 
            }*/

            capslockFlag = isUppercase;
            CapsLock();
        }
        #endregion

        #region Public Methods

        void Update()
        {
            if(timeron)
            {
                timer += .1f;
            }
            if(timer >= 2)
            {
                Input = Input.Remove(Input.Length - 1);
            }
        }
        public void Backspace() {
            timeron = true;
            if (Input.Length > 0) {
                Input = Input.Remove(Input.Length - 1);
            } else {
                return;
            }
        }

        public void Clear() {
            Input = "";
        }

        public void CapsLock() {
            if (capslockFlag) {
                foreach (var pair in keysDictionary) {
                    pair.Value.text = ToUpperCase(pair.Value.text);
                }
            } else {
                foreach (var pair in keysDictionary) {
                    pair.Value.text = ToLowerCase(pair.Value.text);
                }
            }
            capslockFlag = !capslockFlag;
        }

        public void GenerateInput(string s) 
        {
            if (Input.Length > maxInputLength) 
            { 
                return; 
            }
            Input += s;
        }

        public void OnPointerExitBack()
        {
            timeron = false;
            timer = 0;
        }
        #endregion

        #region Private Methods


        private string ToLowerCase(string s) {
            return s.ToLower();
        }

        private string ToUpperCase(string s) {
            return s.ToUpper();
        }
        #endregion
    }
}