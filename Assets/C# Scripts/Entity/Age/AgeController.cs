using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EventController))]
public class AgeController : MonoBehaviour
{
    // Script connections.
    EventController eventController;

    public void Initialize(StatGroup stats)
    {
        eventController = GetComponent<EventController>();

        CancelInvoke("Age");

        Invoke("Age", stats.age.age);
    }

    private void Age()
    {
        eventController.Die();
    }
}
