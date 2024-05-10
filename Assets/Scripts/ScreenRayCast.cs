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

        CalculateRotation1(transform.rotation, direction);
        // float targetRotationY = MathF.Atan2(direction.y, direction.x)/MathF.PI;
        // float currentRotationY = transform.rotation.eulerAngles.y;
        // float rotateAmountY = targetRotationY-currentRotationY;
        //
        // Quaternion rotateAmount = Quaternion.Euler(0, rotateAmountY*Time.deltaTime,0);
        if (direction == Vector3.zero)
        {
            return;
        }
       
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Quaternion rotateAmount = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        //transform.rotation = rotateAmount;
    }

    private void CalculateRotation1(Quaternion now, Vector3 targetDirection)
    {
        float seta = now.eulerAngles.y + 90; 
        float x = Mathf.Cos(seta);
        float z = Mathf.Sin(seta);

        float inner = targetDirection.x * x + targetDirection.z * z;
        float outer = targetDirection.z * x - targetDirection.x * z;

        float delta1 = (Mathf.Acos(inner)*180)/Mathf.PI;
        float delta2 = (Mathf.Asin(outer)*180)/Mathf.PI;
               
        Debug.Log($"내적 {(delta1)} 외적 {delta2}");
    }
    
}