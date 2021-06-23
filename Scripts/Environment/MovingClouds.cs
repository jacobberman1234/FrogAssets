using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingClouds : MonoBehaviour
{
    [Range(0f, 30f)]
    [SerializeField] private float _cloudSpeed;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * _cloudSpeed);
    }
}
