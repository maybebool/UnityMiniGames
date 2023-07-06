using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace TicTacToe.Scripts
{
    public class GameController : MonoBehaviour
    {
        private int _hasTurn = 1;
        [SerializeField] private Sprite[] icons;
        [SerializeField] private Button[] buttons;
        [SerializeField] private TMP_Text winText;
        private int[] _matchFields = new int[9];


        public void ButtonFieldClick(int number) {
            buttons[number].image.sprite = icons[_hasTurn - 1];
            buttons[number].interactable = false;
            buttons[number].image.color = Color.white;

            _matchFields[number] = _hasTurn;
            if (CheckForWinCondition()) {
                Win();
                return;
            }

            if (_hasTurn == 1) {
                _hasTurn = 2;
                Invoke(nameof(ComputerTurn), 0.5f);
            }
            else {
                _hasTurn = 1;
            }
        }

        private void ComputerTurn() {
            var rand = Random.Range(0, 9);
            while (_matchFields[rand] != 0) {
                rand++;
                if (rand >= 9) {
                    rand = 0;
                }
            }
            ButtonFieldClick(rand);
        }


        private bool CheckForWinCondition() {
            var points = 0;
            for (int i = 0; i < 9; i += 3) {
                for (int j = i; j < i + 3; j++) {
                    if (_matchFields[j] == _hasTurn) {
                        points++;
                    }
                }

                if (points == 3) {
                    return true;
                }

                points = 0;
            }

            for (int i = 0; i < 3; i++) {
                for (int j = i; j < i + 7; j += 3) {
                    if (_matchFields[j] == _hasTurn) {
                        points++;
                    }
                }

                if (points == 3) {
                    return true;
                }

                points = 0;
            }


            for (int i = 0; i < 9; i += 4) {
                if (_matchFields[i] == _hasTurn) {
                    points++;
                }
            }

            if (points == 3) {
                return true;
            }

            points = 0;

            for (int i = 2; i < 7; i += 2) {
                if (_matchFields[i] == _hasTurn) {
                    points++;
                }
            }

            if (points == 3) {
                return true;
            }

            return false;
        }


        private void Win() {
            winText.text = $"Player {_hasTurn} has won";
            for (int i = 0; i < buttons.Length; i++) {
                buttons[i].interactable = false;
            }
        }

        public void RestartTheGame() {
            SceneManager.LoadScene("TicTacToe");
        }
    }
}
