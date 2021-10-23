using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootingPlane : MonoBehaviour
{
    [SerializeField] private LayerMask shootingPlane;
    public Vector3 TargetPosition { get; private set; }
    private bool isTargeting = false;
    public bool IsTargeting
    {
        get 
        {
            return isTargeting; 
        }
        private set
        {
            if (isTargeting && !value)
                OnStopTargeting.Invoke();
            isTargeting = value;
        }
    }
    public UnityEvent OnLaunch;
    public UnityEvent OnStopTargeting;

    private Camera mainCamera;
    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        SetTargetPosition();
    }
    private void OnMouseDrag()
    {
        SetTargetPosition();
    }
    private void OnMouseExit()
    {
        IsTargeting = false;
    }
    private void OnMouseUpAsButton()
    {
        OnLaunch.Invoke();
        IsTargeting = false;
    }


    private void SetTargetPosition()
    {
        IsTargeting = true;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, shootingPlane))
        {
            TargetPosition = transform.InverseTransformPoint(raycastHit.point);
        }
        else
        {
            IsTargeting = false;
        }
    }
    private void OnDestroy()
    {
        OnLaunch.RemoveAllListeners();
        OnStopTargeting.RemoveAllListeners();
    }
}
