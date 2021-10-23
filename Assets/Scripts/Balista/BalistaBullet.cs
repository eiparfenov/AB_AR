using UnityEngine;
using UnityEngine.Events;

public class BalistaBullet : MonoBehaviour
{
    private LayerMask balistaPlane;
    [SerializeField] private LayerMask BlistaPlane;
    private Camera mainCamera;
    public bool Aiming { get; private set; }
    public Vector3 Position { get { return transform.localPosition; } }
    public UnityEvent OnBalistaBulletDrop = new UnityEvent();
    public UnityEvent OnBalistaBulletMove = new UnityEvent();

    public void OnMouseDown()
    {
        Move();
        Aiming = true;
        OnBalistaBulletMove.Invoke();
    }
    public void OnMouseDrag()
    {
        Move();
        OnBalistaBulletMove.Invoke();
    }
    public void OnMouseUpAsButton()
    {
        Move();
        Aiming = false;
        OnBalistaBulletDrop.Invoke();
    }

    private void Move()
    {
        Ray inputRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit, 10f, balistaPlane))
        {
            transform.position = hit.point;
        }
    }

    private void Start()
    {
        mainCamera = Camera.main;
        balistaPlane = LayerMask.GetMask("ShootingPlane");
    }

    private void OnDestroy()
    {
        OnBalistaBulletDrop.RemoveAllListeners();
        OnBalistaBulletMove.RemoveAllListeners();
    }
}
