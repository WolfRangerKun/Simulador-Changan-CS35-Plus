using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour
{
    public Transform changan;
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = changan.position;

        newPosition.y = transform.position.y;

        transform.position = newPosition;
    }
}
