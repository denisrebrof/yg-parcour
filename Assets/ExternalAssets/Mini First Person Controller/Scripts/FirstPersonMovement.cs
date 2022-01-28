using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FirstPersonMovement : MonoBehaviour
{
    [Inject] private IMovementInputProvider inputProvider;

    public float speed = 5;
    public float speedMultiplier = 1;

    [Header("Running")] public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;

    Rigidbody m_rigidbody;

    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<Func<float>> speedOverrides = new List<Func<float>>();

    void Awake()
    {
        // Get the rigidbody on this.
        m_rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && inputProvider.GetRunningInput();

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        targetMovingSpeed *= speedMultiplier;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        var input = inputProvider.GetInput();
        Vector2 targetVelocity = input * targetMovingSpeed;
        // Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        m_rigidbody.velocity =
            transform.rotation * new Vector3(targetVelocity.x, m_rigidbody.velocity.y, targetVelocity.y);
    }

    public void SetSpeedMul(float mul) => speedMultiplier = mul;

    public interface IMovementInputProvider
    {
        public Vector2 GetInput();
        public bool GetRunningInput();
    }
}