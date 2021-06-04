using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Containers/Transformation Settings")]
public class TransformationSettings : ScriptableObject
{
    [Header("Components")]
    public Avatar avatar;
    public RuntimeAnimatorController controller;

    [Header("Value Settings")]
    public float moveSpeed;

    [Header("Collider Settings")]
    public Vector3 colliderCenter;
    public float colliderRadius;
    public float colliderHeight;

}
