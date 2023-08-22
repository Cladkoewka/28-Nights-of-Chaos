using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _movementSpeed = 5f;
    [Space(10)]
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform[] _gunPoints;

    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }
    private void Move()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(xMovement, 0, zMovement).normalized;
        _rigidbody.velocity = movementDirection * _movementSpeed;
        if (movementDirection.magnitude  > 0.1f)
        {
            _animator.SetBool("IsRunning", true);
            _player.ChangeGunPositin(_gunPoints[1]);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
            _player.ChangeGunPositin(_gunPoints[0]);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LookToMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y));
        Vector3 directionToMouse = worldMousePosition - transform.position;
        directionToMouse.y = 0;
        Quaternion rotation = Quaternion.LookRotation(directionToMouse);
        transform.rotation = rotation;

    }

    private void Update()
    {
        LookToMousePosition();
    }
}
