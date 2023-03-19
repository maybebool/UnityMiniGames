using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace TicTacToe.Scripts
{
    public class GameController : MonoBehaviour
    {
        public int hasTurn;
        public int turnCounter;
        public GameObject[] turnIcons;
        public Sprite[] playIcons;
        public Button[] spaces;

        private void Start()
        {
            GameSetup();
        }

        private void GameSetup()
        {
            hasTurn = 0;
            turnCounter = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
            for (int i = 0; i < spaces.Length; i++)
            {
                spaces[i].interactable = true;
                spaces[i].GetComponent<Image>().sprite = null;

            }
        }

        private void Update()
        {
            
        }

        public void Buttons(int whichNumber)
        {
            spaces[whichNumber].image.sprite = playIcons[hasTurn];
            spaces[whichNumber].interactable = false;

            if (hasTurn == 0)
            {
                hasTurn = 1;
                turnIcons[0].SetActive(false);
                turnIcons[1].SetActive(true);
            }
            else
            {
                hasTurn = 0;
                turnIcons[0].SetActive(true);
                turnIcons[1].SetActive(false);
            }
        }
    }
}
