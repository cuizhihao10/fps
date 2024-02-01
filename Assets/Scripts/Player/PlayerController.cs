using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;      //速度：每秒移动的距离
    private Vector3 yRotation = Vector3.zero;      //旋转角色
    private Vector3 xRotation = Vector3.zero;      //旋转视角
    private Vector3 thrusterForce = Vector3.up * 20f;          //向上的推力

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate(Vector3 _yRotation, Vector3 _xRotation)
    {
        yRotation = _yRotation;
        xRotation = _xRotation;
    }

    public void Thrust(Vector3 _thrusterForce)
    {
        thrusterForce = _thrusterForce;
    }

    private void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
        if (thrusterForce != Vector3.zero)
        {
            rb.AddForce(thrusterForce);    //作用Time.fixedDeltaTime秒
            thrusterForce = Vector3.zero;
        }
    }

    private void PerformRotation()
    {
        if (yRotation != Vector3.zero)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(yRotation));
        }

        if (xRotation != Vector3.zero)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(xRotation));
        }
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }
}
