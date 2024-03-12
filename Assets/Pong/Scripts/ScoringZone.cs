using UnityEngine;
using UnityEngine.EventSystems;

namespace Pong.Scripts {
    public class ScoringZone : MonoBehaviour {
        
        public EventTrigger.TriggerEvent scoreTrigger;
        
        private void OnCollisionEnter2D(Collision2D other) {
            var ball = other.gameObject.GetComponent<Ball>();
            if (ball == null) {
                return;
            }
            
            var eventData = new BaseEventData(EventSystem.current);
            scoreTrigger.Invoke(eventData);
        }
    }
}