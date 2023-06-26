using System;
using UnityEngine;

namespace FruitNinja.Scripts {
    public class Blade : MonoBehaviour {
        private bool sclicing;
        
        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                StartSlicing();
            }else if (Input.GetMouseButtonUp(0)) {
                StopSlicing();
            }else if (sclicing) {
                ContinueSlicing();
            }
        }

        private void StartSlicing() {
            sclicing = true;
        }

        private void StopSlicing() {
            sclicing = false;
        }

        private void ContinueSlicing() {
            
        }
        
    }
}
