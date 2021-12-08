using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    // Delegates and their events.
    public delegate void EmptyDelegate();
    public event EmptyDelegate die;

    public delegate void GameObjectDelegate(GameObject gameObject);

    public void Die()
    {
        if (die != null)
            die();
    }
}
