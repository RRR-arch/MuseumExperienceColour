using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyTest : MonoBehaviour
{

    public float moveSpeed = 0.25f;
    public float rotationRate = 15f;
    public Transform target;

    private Rigidbody _Rigidbody;

    private Vector3 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out _Rigidbody);
    }


    // FixedUpdate is called once per frame

    private void FixedUpdate()
    {
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        _Rigidbody.position += moveInput * moveSpeed;

        if (moveInput.sqrMagnitude > 0)
        {
            Quaternion rotation = Quaternion.LookRotation(moveInput, Vector3.up);
            _Rigidbody.rotation = Quaternion.Lerp(_Rigidbody.rotation, rotation, Time.fixedDeltaTime * rotationRate);
        }

    }
}
