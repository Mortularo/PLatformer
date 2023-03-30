using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SAM
{
    public class ScoreManager : MonoBehaviour
    {
        public int score;
        public bool IsActive;
        [SerializeField] private RawImage KeyImage;
        [SerializeField] private TextMeshProUGUI _scoreDisplay;
        private static SceneManager _manager;

        private void Start()
        {
            _manager = GetComponent<SceneManager>();    
        }

        void Update()
        {
            _scoreDisplay.text = "Coins: " + score.ToString();
            if (score >= 10)
            {
                IsActive = true;
                if (IsActive) _manager.PortalOpener();
                //KeySwitch();
            }
        }
        #region Methods
        public void ScoreUpdate()
        {
            score ++;
        }
        public void KeySwitch()
        {
            KeyImage.enabled = !KeyImage.enabled;
        }
        #endregion
    }
}