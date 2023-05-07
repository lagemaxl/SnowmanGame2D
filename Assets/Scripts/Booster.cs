using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField]
    private Vector3 windDirection = Vector3.right;

    public Vector3 WindDirection => windDirection;

    [SerializeField]
    private float windForce = 1f;

    public float WindForce => windForce;
}
