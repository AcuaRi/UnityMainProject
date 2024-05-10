using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 distance;
        [SerializeField] private float damping = 5f;
        
        private void Awake()
        {
            distance = transform.position - target.position;
        }

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, target.position + distance, damping * Time.deltaTime);
            
        }
    }
    
}

