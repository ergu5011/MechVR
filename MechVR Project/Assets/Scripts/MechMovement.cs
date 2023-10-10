using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechMovement : MonoBehaviour, IInteractable
{
    [SerializeField] private HingeJoint _turnLever;
    [SerializeField] private HingeJoint _moveLever;

    private float _turnAngle;
    private float _turnSpeed;
    [SerializeField] private float _turnsSpeedMax;
    
    private float _moveAngle;
    private float _moveSpeed;
    [SerializeField] private float _moveSpeedMax;

    private Rigidbody _rb;

    // Animation related variables
    private float _moveState;
    [SerializeField] private GameObject _mech;
    private Animator _mechAnim;

    // Slug related variables
    [SerializeField] private GameObject _slugs;
    private bool _slugged;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _mechAnim = _mech.GetComponent<Animator>();
    }

    void Update()
    {
        // Disables movement if the mech has slugs on it
        if (_slugged == true) return;

        // Gets angle of turn lever and converts it to speed
        _turnAngle = _turnLever.angle;
        _turnSpeed = _turnsSpeedMax * (_turnAngle / 35f);

        // Gets angle of move lever and converts it to speed
        _moveAngle = _moveLever.angle;
        _moveSpeed = _moveSpeedMax * (_moveAngle / 35f);

        // Rotation and movement
        transform.Rotate(0f, _turnSpeed * Time.deltaTime, 0f);
        _rb.velocity = transform.forward * _moveSpeed;

        // Activates movement animation depending on current speed
        _moveState = _moveSpeed / _moveSpeedMax;
        if (_moveState < 0) _moveState *= -1f; // Inverses animation value if moving backwards
        _mechAnim.SetFloat("MoveState", _moveState);
    }

    private void Slugged()
    {
        _slugged = true;

        _slugs.SetActive(true);
    }

    public void UnSlugged()
    {
        _slugged = false;

        _slugs.SetActive(false);
    }

    public void Interact()
    {
        Slugged();
    }
}
