using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EventController))]
public class AgeController : MonoBehaviour
{
    // Script connections.
    EventController eventController;

    public void Initialize(StatGroupAge stats)
    {
        eventController = GetComponent<EventController>();

        CancelInvoke("Age");

        Invoke("Age", stats.age);
    }

    private void Age()
    {
        eventController.Die();
    }
}
