using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnSpawn : MonoBehaviour
{
    [SerializeField] private float _timeToWait = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _timeToWait);
    }
}
