using UnityEngine;
using UnityEngine.UI;

namespace Wimmelbild.Scripts {
    public class WBGameManager : MonoBehaviour {

        [SerializeField] private  Image[] pictures;
        [SerializeField] private Text[] texts;
        [SerializeField] private Text wonText;
        
         private int _counter;
        
        public void SelectedImage(int selected) {
            
            pictures[selected].gameObject.SetActive(false);
            texts[selected].color = Color.green;
            _counter++;
            
            if (pictures.Length > _counter) return;
            wonText.gameObject.SetActive(true);
        }
    }
}
