using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogTransformation : MonoBehaviour
{
    private Animator _anim;
    private PlayerMovement _movement;
    private CharacterController _characterController;

    //Index 0 is Human, Index 1 is Frog
    [Header("References")]
    [SerializeField] private GameObject[] _forms;
    [SerializeField] private GameObject[] _cameras;
    [SerializeField] private TransformationSettings[] _transformationSettings;

    private bool _inHumanForm;
    public bool InHumanForm => _inHumanForm;


    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _movement = GetComponent<PlayerMovement>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        //Start as a frog
        _inHumanForm = true;
        TransformIntoFrog(!_inHumanForm);
    }

    private void Update()
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
        _forms[human].SetActive(value);
        _forms[frog].SetActive(!value);
        _cameras[human].SetActive(value);
        _cameras[frog].SetActive(!value);
        if (!value)
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
        _movement.moveSpeed = settings.moveSpeed;
        _movement.jumpHeight = settings.jumpHeight;
        _characterController.center = settings.colliderCenter;
        _characterController.radius = settings.colliderRadius;
        _characterController.height = settings.colliderHeight;
        _inHumanForm = !_inHumanForm;
        Debug.Log(_inHumanForm);
    }
}
