using System;
using UnityEngine;
using Zenject;

public class Jump : MonoBehaviour
{
    [Inject] private IJumpInputProvider jumpInputProvider;
    Rigidbody myRigidbody;
    public float jumpStrength = 2;
    public event Action Jumped;

    [SerializeField, Tooltip("Prevents jumping when the transform is in mid-air.")]
    GroundCheck groundCheck;


    void Reset()
    {
        // Try to get groundCheck.
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    void Awake()
    {
        // Get rigidbody.
        myRigidbody = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        if (!jumpInputProvider.GetHasJumpInput() || !groundCheck || groundCheck.isGrounded) return;
        myRigidbody.AddForce(Vector3.up * 100 * jumpStrength);
        Jumped?.Invoke();
    }

    public interface IJumpInputProvider
    {
        public bool GetHasJumpInput();
    }
}