using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1911 : MonoBehaviour
{
    [SerializeField] private LayerMask wallLayerMask;
    private Rigidbody rb;

        void Start() {
            rb = GetComponent<Rigidbody>();
        }

        void OnTriggerEnter(Collider other) {
            // Check if the collided object is on the "Table" layer
            if (other.gameObject.layer == wallLayerMask) {
                // Stop the pistol from moving
                rb.isKinematic = true;
            }
        }
    
}
