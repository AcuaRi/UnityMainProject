using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Checker : MonoBehaviour
    {
        [SerializeField] private string wallTag = "Wall";
        [SerializeField] private int targetCount = 0;
        [SerializeField] private int pushCount = 0;
        [SerializeField] private float gameOverTime = 10f;
        [SerializeField] private float remainTime = 0;
        [SerializeField] private bool isGameClear = false;
        
        private void Awake()
        {
            targetCount = GameObject.FindGameObjectsWithTag(wallTag).Length;
            remainTime = gameOverTime;
        }

        private void Update()
        {
            if (isGameClear)
            {
                return;
            }
            
            remainTime -= Time.deltaTime;

            if (remainTime <= 0f)
            {
                isGameClear = true;
                Debug.Log("타임 오버!");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(wallTag))
            {
                ++pushCount;
                if (pushCount == targetCount)
                {
                    Debug.Log("Game Clear!");
                }
            }
        }
    }
}



