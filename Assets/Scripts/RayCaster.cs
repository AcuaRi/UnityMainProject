using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    [SerializeField] private float rayLength = 3f;
    [Tooltip("플레이어가 벽을 밀어내는 힘"), SerializeField] private float pushPower = 50f;
    
    private void Update()
    {
        //RayCastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, rayLength))
        {
            Debug.Log($"Ray가 {hit.collider.name}에 충돌함");
            
        }
        if(hit.rigidbody) hit.rigidbody.AddForce(transform.forward * pushPower);
    }


    //Ray가 보이도록 하는 가상의 광선
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(transform.position, transform.forward*rayLength);
    }
}
