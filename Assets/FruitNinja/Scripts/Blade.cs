using System;
using UnityEngine;

namespace FruitNinja.Scripts {
    public class Blade : MonoBehaviour {

        private Camera camera;
        private Collider bladeCollider;
        private TrailRenderer trail;
        private bool sclicing;
        public Vector3 Direction { get; private set; }
        public float minSliceVelocity = 0.01f;

        private void Awake() {
            camera = Camera.main;
            bladeCollider = GetComponent<Collider>();
            trail = GetComponentInChildren<TrailRenderer>();
        }

        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                StartSlicing();
            }else if (Input.GetMouseButtonUp(0)) {
                StopSlicing();
            }else if (sclicing) {
                ContinueSlicing();
            }
        }

        private void OnEnable() {
            StopSlicing();
        }

        private void OnDisable() {
            StopSlicing();
        }

        private void StartSlicing() {
            var newPos = camera.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0f;
            transform.position = newPos;
            
            sclicing = true;
            bladeCollider.enabled = true;

            trail.enabled = true;
            trail.Clear();
        }

        private void StopSlicing() {
            sclicing = false;
            bladeCollider.enabled = false;

            trail.enabled = false;
        }

        private void ContinueSlicing() {
            var newPos = camera.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = 0f;
            Direction = newPos - transform.position;
            var velocity = Direction.magnitude / Time.deltaTime;
            bladeCollider.enabled = velocity > minSliceVelocity;
            transform.position = newPos;
        }
        
    }
}
