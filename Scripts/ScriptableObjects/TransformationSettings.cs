using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Containers/Transformation Settings")]
public class TransformationSettings : ScriptableObject
{
    public Avatar avatar;
    public RuntimeAnimatorController controller;
    public float moveSpeed;
}
