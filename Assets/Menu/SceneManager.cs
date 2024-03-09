using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {
    public class GameManager {


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