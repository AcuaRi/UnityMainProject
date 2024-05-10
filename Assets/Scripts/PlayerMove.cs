using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 540f;
    
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position +=  moveSpeed * Time.deltaTime * vertical * transform.forward;
        transform.rotation *= Quaternion.Euler(0, horizontal*rotationSpeed*Time.deltaTime,0);
    }
}
