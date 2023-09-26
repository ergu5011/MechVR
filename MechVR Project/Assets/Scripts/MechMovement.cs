using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechMovement : MonoBehaviour
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

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Gets angle of turn lever and converts it to speed
        _turnAngle = _turnLever.angle;
        _turnSpeed = _turnsSpeedMax * (_turnAngle / 35);

        // Gets angle of move lever and converts it to speed
        _moveAngle = _moveLever.angle;
        _moveSpeed = _moveSpeedMax * (_moveAngle / 35);

        // Rotation and movement
        transform.Rotate(0, _turnSpeed * Time.deltaTime, 0);
        _rb.velocity = transform.forward * _moveSpeed;
    }
}
