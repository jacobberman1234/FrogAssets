using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private AnimationContainers _container;
    private Animator _anim;
    private AnimatorOverrideController _overrideController;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        if(_anim == null)
        {
            _anim = GetComponentInChildren<Animator>();
        }
    }

    private void Update()
    {
    }

    public void AnimateMovement(float right, float forward)
    {
        _anim.SetFloat("horizontal", right);
        _anim.SetFloat("vertical", forward);
    }

    public void AnimateMovement(bool isMoving)
    {
        _anim.SetBool("isMoving", isMoving);
    }

    public void RandomIdle()
    {
        int randomIdle = Random.Range(0, 3);
        
        _anim.SetFloat("idle", randomIdle);
    }
}
