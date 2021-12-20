using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 15f;
    [SerializeField]
    private float _gravity = 0.05f;
    [SerializeField]
    private Transform _cameraTransform;
    [SerializeField]
    private float _mouseSense = 0.2f;
    [SerializeField]
    private float _jumpspeed = 3f;

    [SerializeField]
    private Transform _weaponTransform;

    private Vector3 _movement = Vector3.zero;
    private CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; 
    }


    // Update is called once per frame
    void Update()
    {

    }
    public void OnMovement(InputValue ctx)
    {
        Vector2 dir = ctx.Get<Vector2>();
        _movement.x = dir.x;
        _movement.z = dir.y;
    }

    public void OnMouseLook(InputValue ctx)
    {
        Vector2 mouseDelta = ctx.Get<Vector2>();
        float rotX = -mouseDelta.y * _mouseSense;
        float rotZ = mouseDelta.x * _mouseSense;

        transform.Rotate(Vector3.up, rotZ);
        _cameraTransform.Rotate(Vector3.right, rotX);

        if (_cameraTransform.localEulerAngles.x > 60f && _cameraTransform.localEulerAngles.x < 180f)
            _cameraTransform.localRotation = Quaternion.Euler(60f, 0, 0);
        else if (_cameraTransform.localEulerAngles.x < 300f && _cameraTransform.localEulerAngles.x > 180f)
            _cameraTransform.localRotation = Quaternion.Euler(300f, 0, 0);

        transform.Rotate(Vector3.up, rotZ);
        _weaponTransform.Rotate(Vector3.right, rotX);

        if (_weaponTransform.localEulerAngles.x > 60f && _weaponTransform.localEulerAngles.x < 180f)
            _weaponTransform.localRotation = Quaternion.Euler(60f, 0, 0);
        else if (_weaponTransform.localEulerAngles.x < 300f && _weaponTransform.localEulerAngles.x > 180f)
            _weaponTransform.localRotation = Quaternion.Euler(300f, 0, 0);

    }

    public void OnJump(InputValue ctx)
    {
        if (_characterController.isGrounded)
            _movement.y = _jumpspeed;
    }

    private void FixedUpdate()
    {
        if (!_characterController.isGrounded)
            _movement.y -= _gravity;
        var moveDir = transform.TransformDirection(_movement);
        _characterController.Move(moveDir * Time.fixedDeltaTime * _speed);
    }
}

