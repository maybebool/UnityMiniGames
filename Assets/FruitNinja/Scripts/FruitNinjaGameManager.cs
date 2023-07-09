using System;
using TMPro;
using UnityEngine;

namespace FruitNinja.Scripts {
    public class FruitNinjaGameManager : MonoBehaviour {
        
        
        public TMP_Text scoreText;

        private int _score;


        private void Start() {
            NewGame();
        }

        private void NewGame() {
            _score = 0;
            scoreText.text = _score.ToString();
        }

        public void IncreaseScore(int amount) {
            _score += amount;
            scoreText.text = _score.ToString();
        }
        

    }
}
