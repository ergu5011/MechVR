using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownCrystal : MonoBehaviour
{
    [SerializeField] private ParticleSystem _boomParticle;
    [SerializeField] private GameObject _crystalBody;

    private Rigidbody _rb;

    private bool _hasLaunched = false;

    private bool _hasCollided;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_hasLaunched == false)
        {
            _rb.velocity = transform.forward * 15f;

            _hasLaunched = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_hasCollided == false)
        {
            _rb.useGravity = false;
            _rb.constraints = RigidbodyConstraints.FreezeAll;

            _boomParticle.Play();

            _crystalBody.SetActive(false);

            _hasCollided = true;
        }
    }
}
