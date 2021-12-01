using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private float acceleration;
    [SerializeField] private bool[] blockedAxis = new bool[3];

    private Vector3 disiredVelocity;
    private Vector3 velocity;

    private Transform mytrans;

    private void Awake()
    {
        mytrans = transform;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        velocity += new Vector3(ClampedLerp(velocity.x, disiredVelocity.x, acceleration / disiredVelocity.magnitude), ClampedLerp(velocity.y, disiredVelocity.y, acceleration / disiredVelocity.magnitude), ClampedLerp(velocity.z, disiredVelocity.z, acceleration / disiredVelocity.magnitude));

        velocity.Scale(GetBlockedAxisVector());

        mytrans.position += velocity * Mathf.Clamp(Time.deltaTime, 0, 1);
    }

    public void SetDisiredVelocity(Vector3 iDisiredVelocity)
    {
        disiredVelocity = iDisiredVelocity;
    }

    public void CalAndSetDisiredVelocity(Vector3 iDisiredVelocity, float iMovementSpeed)
    {
        iDisiredVelocity.Scale(GetBlockedAxisVector());

        disiredVelocity = iDisiredVelocity.normalized * iMovementSpeed;
    }

    public void SetAndApplyKnockbackVelocity(Vector3 iKnockback)
    {
        velocity += iKnockback;

        Move();
    }

    // Calculators
    private float ClampedLerp(float a, float b, float time)
    {
        if (time != 0)
        {
            float difference = b - a;
            float distance = Mathf.Abs(difference);
            return Mathf.Clamp(difference * Time.deltaTime / time, -distance, distance);
        }
        else
        {
            return b - a;
        }
    }

    private Vector3 GetBlockedAxisVector()
    {
        Vector3 result = Vector3.one;

        if (blockedAxis[0])
        {
            result.x = 0;
        }

        if (blockedAxis[1])
        {
            result.y = 0;
        }

        if (blockedAxis[2])
        {
            result.z = 0;
        }

        return result;
    }
}
