using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to provide a camera that follows (abn object attached to) the player without follwing the players rotation
/// </summary>
public class FixedCamTarget : MonoBehaviour
{
    public Transform target;

    void LateUpdate()
    {
        transform.position = target.position;
    }
}
