using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // https://github.com/herbou/Tuto_DrawTrajectory/blob/master/Assets/Scripts/

    public static GameManager Instance;

    private Camera cam;

    [SerializeField] private Player player;
    [SerializeField] private Trajectory trajectory;
    [SerializeField] private float pushForce = 10f;
    [SerializeField] private float scaleFactor = 0.1f;
    [SerializeField] private float maxShootDistance = 5f;


    private float totalDistanceTraveled = 0f;
    private bool isDragging = false;

    private Vector2 startPoint;
    private Vector2 endPoint;
    private Vector2 direction;
    private Vector2 force;
    private float distance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        cam = Camera.main;
        player.DeactivateRb();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            OnDragStart();
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            OnDragEnd();
        }

        if (isDragging)
        {
            OnDrag();
        }
        else
        {
            float distanceTraveledThisFrame = player.PlayerVelocity.magnitude * Time.deltaTime;
            totalDistanceTraveled += distanceTraveledThisFrame;
            UpdatePlayerScale();
        }
    }

    void OnDragStart()
    {
        player.DeactivateRb();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        trajectory.Show();
    }

    void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        distance = Mathf.Clamp(distance, 0, maxShootDistance);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;

        trajectory.UpdateDots(player.Pos, force);
    }

    void OnDragEnd()
    {
        player.ActivateRb();
        player.Push(force);

        trajectory.Hide();

    }

    void StopPlayer()
    {
        player.DeactivateRb();
    }

    void UpdatePlayerScale()
    {
        float scaleValue = 1 + scaleFactor * totalDistanceTraveled;
        scaleValue = Mathf.Clamp(scaleValue, 1, 2);
        player.transform.localScale = new Vector3(scaleValue, scaleValue, 1);
    }
    
    public void ReducePlayerScale(float scale)
    {
        totalDistanceTraveled /= scale;
    }
}
