using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField]
    private Vector3 boosterDirection = Vector3.right;

    public Vector3 BoosterDirection => boosterDirection;

    [SerializeField]
    private float windForce = 1f;

    public float WindForce => windForce;
}
