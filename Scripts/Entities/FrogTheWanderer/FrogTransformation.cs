using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogTransformation : MonoBehaviour
{
    private Animator _anim;
    private PlayerMovement _movement;

    //Index 0 is Human, Index 1 is Frog
    [Header("References")]
    [SerializeField] private GameObject[] _forms;
    [SerializeField] private GameObject[] _cameras;
    [SerializeField] private TransformationSettings[] _transformationSettings;

    private bool _inHumanForm;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _movement = GetComponent<PlayerMovement>();
        //Start as a frog
        TransformIntoFrog(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TransformIntoFrog(!_inHumanForm);
        }
    }

    private void TransformIntoFrog(bool value)
    {
        //If _inHumanForm you are becoming a frog
        int human = 0;
        int frog = 1;
        TransformationSettings settings;
        _forms[human].SetActive(!value);
        _forms[frog].SetActive(value);
        _cameras[human].SetActive(!value);
        _cameras[frog].SetActive(value);
        if (value)
        {
            settings = _transformationSettings[frog];
            Debug.Log("Turning into frog");
        }
        else
        {
            settings = _transformationSettings[human];
            Debug.Log("Turning into human");
        }
        _anim.avatar = settings.avatar;
        _anim.runtimeAnimatorController = settings.controller;
        _movement.MoveSpeed = settings.moveSpeed;
        _inHumanForm = !_inHumanForm;
    }
}
