using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Pong.Scripts
{
    public class ScoringZone : MonoBehaviour
    {
        public EventTrigger.TriggerEvent scoreTrigger;
        private void OnCollisionEnter2D(Collision2D other)
        {
            Ball ball = other.gameObject.GetComponent<Ball>();
            if (ball != null)
            {
                var eventData = new BaseEventData(EventSystem.current);
                scoreTrigger.Invoke(eventData);
            }
        }
    }
}
