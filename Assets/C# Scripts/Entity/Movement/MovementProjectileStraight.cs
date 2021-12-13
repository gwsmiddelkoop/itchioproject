using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementProjectileStraight : MonoBehaviour
{
    private Mover mover;

    public void Initialize(Mover mover)
    {
        this.mover = mover;
    }
}
