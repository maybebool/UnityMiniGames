using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Utils : MonoBehaviour {
    public static void BindButtonSingleEvent(Button button, UnityAction action) {
        var evt = new Button.ButtonClickedEvent();
        evt.AddListener(action);
        button.onClick = evt;
    }
}



namespace DoodleJump.Scripts {
    public class UIManager : MonoBehaviour {
        [SerializeField] private Button start;


        private void OnEnable() {
            Utils.BindButtonSingleEvent(start, StartGame);
        }

        private void StartGame() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
}
