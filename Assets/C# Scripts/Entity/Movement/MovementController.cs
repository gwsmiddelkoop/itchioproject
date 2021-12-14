using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementTypes
{
    Straight,
    Seeking,
    Path,
}

public class MovementController : MonoBehaviour
{
    private Mover mover;

    private StatGroupMovement stats;

    public void Initialize(StatGroupMovement stats)
    {
        this.stats = stats;

        mover = new Mover();
        mover.Initialize(this, 2);

        mover.SetDisiredVelocity(new Vector2(8, 8).normalized);
        mover.SetAndApplyKnockbackVelocity(new Vector2(8, 8).normalized);
    }
}
