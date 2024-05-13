using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenRayCast : MonoBehaviour
{
    [SerializeField] private Vector3 targetPosition = new Vector3(0, 1, 0);
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 180f;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                targetPosition = hit.point;
                targetPosition.y = transform.position.y;
            }
        }
        
        
        Vector3 direction = targetPosition - transform.position;
        direction.Normalize();
        
        Vector3 moveAmount = moveSpeed * Time.deltaTime * direction;
        //transform.position += moveAmount;

        float rotationAmountY = CalculateRotationY(transform.rotation, direction);
        Quaternion rotationAmount = Quaternion.Euler(0, rotationAmountY * Time.deltaTime ,0);
        transform.rotation *= rotationAmount;
        
        if (direction == Vector3.zero)
        {
            return;
        }
       
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        //Quaternion rotateAmount = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        //transform.rotation = rotateAmount;
    }

    private float CalculateRotationY(Quaternion now, Vector3 targetDirection)
    {
        float seta = (90 - now.eulerAngles.y)/180 * Mathf.PI; 
        float x = Mathf.Cos(seta);
        float z = Mathf.Sin(seta);

        float inner = targetDirection.x * x + targetDirection.z * z;
        float outer = targetDirection.x * z - targetDirection.z * x;

        float delta1 = (Mathf.Acos(inner)*180)/Mathf.PI;
        float delta2 = (Mathf.Asin(outer)*180)/Mathf.PI;
               
        //Debug.Log($" y각도 {now.eulerAngles.y} 내적 {(delta1)} 외적 {delta2}");

        float rotationAmount = (delta2 >= 0) ? delta1 : -delta1;

        return rotationAmount;
    }
    
}