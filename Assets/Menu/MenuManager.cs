using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu {
    public class MenuManager : MonoBehaviour {

        [SerializeField] private Button asteroidsButton;
        [SerializeField] private Button breakoutButton;
        [SerializeField] private Button bubbleShooterButton;
        [SerializeField] private Button doodleJumpButton;
        [SerializeField] private Button flappyBirdButton;
        [SerializeField] private Button fruitNinjaButton;
        [SerializeField] private Button mineSweeperButton;
        [SerializeField] private Button pongButton;
        [SerializeField] private Button snakeButton;
        [SerializeField] private Button spaceInvadersButton;
        [SerializeField] private Button spaceWarsButton;
        [SerializeField] private Button tetrisButton;
        [SerializeField] private Button ticTacToeButton;
        [SerializeField] private Button wimmelbildButton;


        private void OnEnable() {
            asteroidsButton.onClick.AddListener(() => LoadScene(Scenes.Asteroids));
            breakoutButton.onClick.AddListener(() => LoadScene(Scenes.Breakout));
            bubbleShooterButton.onClick.AddListener(() => LoadScene(Scenes.BubbleShooter));
            doodleJumpButton.onClick.AddListener(() => LoadScene(Scenes.DoodleJump));
            flappyBirdButton.onClick.AddListener(() => LoadScene(Scenes.FlappyBird));
            fruitNinjaButton.onClick.AddListener(() => LoadScene(Scenes.FruitNinja));
            mineSweeperButton.onClick.AddListener(() => LoadScene(Scenes.MineSweeper));
            pongButton.onClick.AddListener(() => LoadScene(Scenes.Pong));
            snakeButton.onClick.AddListener(() => LoadScene(Scenes.Snake));
            spaceInvadersButton.onClick.AddListener(() => LoadScene(Scenes.SpaceInvaders));
            spaceWarsButton.onClick.AddListener(() => LoadScene(Scenes.SpaceWars));
            tetrisButton.onClick.AddListener(() => LoadScene(Scenes.Tetris));
            ticTacToeButton.onClick.AddListener(() => LoadScene(Scenes.TicTacToe));
            wimmelbildButton.onClick.AddListener(() => LoadScene(Scenes.Wimmelbild));
        }

        private void OnDisable() {
            asteroidsButton.onClick.RemoveListener(() => LoadScene(Scenes.Asteroids));
            breakoutButton.onClick.RemoveListener(() => LoadScene(Scenes.Breakout));
            bubbleShooterButton.onClick.RemoveListener(() => LoadScene(Scenes.BubbleShooter));
            doodleJumpButton.onClick.RemoveListener(() => LoadScene(Scenes.DoodleJump));
            flappyBirdButton.onClick.RemoveListener(() => LoadScene(Scenes.FlappyBird));
            fruitNinjaButton.onClick.RemoveListener(() => LoadScene(Scenes.FruitNinja));
            mineSweeperButton.onClick.RemoveListener(() => LoadScene(Scenes.MineSweeper));
            pongButton.onClick.RemoveListener(() => LoadScene(Scenes.Pong));
            snakeButton.onClick.RemoveListener(() => LoadScene(Scenes.Snake));
            spaceInvadersButton.onClick.RemoveListener(() => LoadScene(Scenes.SpaceInvaders));
            spaceWarsButton.onClick.RemoveListener(() => LoadScene(Scenes.SpaceWars));
            tetrisButton.onClick.RemoveListener(() => LoadScene(Scenes.Tetris));
            ticTacToeButton.onClick.RemoveListener(() => LoadScene(Scenes.TicTacToe));
            wimmelbildButton.onClick.RemoveListener(() => LoadScene(Scenes.Wimmelbild));
        }


        public void LoadScene(Scenes sceneIndex) {
            switch (sceneIndex) {
                case Scenes.Asteroids:
                    SceneManager.LoadScene((int)Scenes.Asteroids);
                    break;
                case Scenes.Breakout:
                    SceneManager.LoadScene((int)Scenes.Breakout);
                    break;
                case Scenes.BubbleShooter:
                    SceneManager.LoadScene((int)Scenes.BubbleShooter);
                    break;
                case Scenes.DoodleJump:
                    SceneManager.LoadScene((int)Scenes.DoodleJump);
                    break;
                case Scenes.FlappyBird:
                    SceneManager.LoadScene((int)Scenes.FlappyBird);
                    break;
                case Scenes.FruitNinja:
                    SceneManager.LoadScene((int)Scenes.FruitNinja);
                    break;
                case Scenes.MainMenu:
                    SceneManager.LoadScene((int)Scenes.MainMenu);
                    break;
                case Scenes.MineSweeper:
                    SceneManager.LoadScene((int)Scenes.MineSweeper);
                    break;
                case Scenes.Pong:
                    SceneManager.LoadScene((int)Scenes.Pong);
                    break;
                case Scenes.Snake:
                    SceneManager.LoadScene((int)Scenes.Snake);
                    break;
                case Scenes.SpaceInvaders:
                    SceneManager.LoadScene((int)Scenes.SpaceInvaders);
                    break;
                case Scenes.SpaceWars:
                    SceneManager.LoadScene((int)Scenes.SpaceWars);
                    break;
                case Scenes.Tetris:
                    SceneManager.LoadScene((int)Scenes.Tetris);
                    break;
                case Scenes.TicTacToe:
                    SceneManager.LoadScene((int)Scenes.TicTacToe);
                    break;
                case Scenes.Wimmelbild:
                    SceneManager.LoadScene((int)Scenes.Wimmelbild);
                    break;
                default:
                    Debug.LogError("Invalid scene index");
                    throw new ArgumentOutOfRangeException(nameof(sceneIndex), sceneIndex, null);
            }
        }
    }
}