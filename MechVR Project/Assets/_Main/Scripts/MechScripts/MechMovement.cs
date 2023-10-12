using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class MechMovement : MonoBehaviour, IInteractable
{
    // levers
    [SerializeField] private HingeJoint _turnLever;
    [SerializeField] private HingeJoint _moveLever;

    // Turning
    private float _turnAngle;
    private float _turnSpeed;
    [SerializeField] private float _turnsSpeedMax;
    
    // Moving
    private float _moveAngle;
    private float _moveSpeed;
    [SerializeField] private float _moveSpeedMax;

    private Rigidbody _rb;

    // Animation
    private float _moveState;
    [SerializeField] private GameObject _mech;
    private Animator _mechAnim;

    // Slug
    [SerializeField] private GameObject _slugs;
    private bool _slugged;

    private EventInstance _mechFootsteps;
    private EventInstance _mechTurning;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _mechAnim = _mech.GetComponent<Animator>();

        _mechFootsteps = AudioManager.instance.CreateInstance(FMODEvents.instance.mechFootsteps);
        _mechTurning = AudioManager.instance.CreateInstance(FMODEvents.instance.mechTurning);
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

        UpdateSoundMovement();
        UpdateSoundTurning();
    }

    // Activates slugs
    private void Slugged()
    {
        _moveState = 0f;
        _mechAnim.SetFloat("MoveState", _moveState);

        _moveSpeed = 0f;
        _turnSpeed = 0f;

        _slugged = true;

        _slugs.SetActive(true);

        AudioManager.instance.PlayOneShot(FMODEvents.instance.slugSplat, this.transform.position);

        UpdateSoundMovement();
        UpdateSoundTurning();
    }

    //Deactivates slugs
    public void UnSlugged()
    {
        _slugged = false;

        _slugs.SetActive(false);

        AudioManager.instance.PlayOneShot(FMODEvents.instance.electricShock, this.transform.position);
    }

    //Interface
    public void Interact()
    {
        Slugged();
    }

    private void UpdateSoundMovement()
    {
        if ( _moveState > 0.1f || _moveState < -0.1f)
        {
            PLAYBACK_STATE playbackstate;
            _mechFootsteps.getPlaybackState(out playbackstate);
            if (playbackstate.Equals(PLAYBACK_STATE.STOPPED))
            {
                _mechFootsteps.start();
            }
        }
        else
        {
            _mechFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
        }
    } 
    
    private void UpdateSoundTurning()
    {
        if ( _turnSpeed > 0.1f || _turnSpeed < -0.1f)
        {
            PLAYBACK_STATE playbackstate;
            _mechTurning.getPlaybackState(out playbackstate);
            if (playbackstate.Equals(PLAYBACK_STATE.STOPPED))
            {
                _mechTurning.start();
            }
        }
        else
        {
            _mechTurning.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }
}
