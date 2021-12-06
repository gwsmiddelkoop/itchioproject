using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    [SerializeField] private StatGroup stats;

    public StatTransGroup statTransGroup;

    public void Initialize(StatTransGroup statTransGroup)
    {
        this.statTransGroup = statTransGroup;

        stats = statTransGroup.TransformStatGroup();

        SetUp();

        GetComponent<EventController>().Die();
    }

    private void SetUp()
    {
        // Standard components.
        gameObject.AddComponent(typeof(EventController));
        GetComponent<EventController>().die += Die;


        // Stat releated components.
        if (stats.name.usage)
        {
            gameObject.name = stats.name.name;
        }

        if (stats.sprite.usage && stats.sprite.sprite != null)
        {
            gameObject.AddComponent(typeof(SpriteRenderer));
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();

            renderer.sprite = stats.sprite.sprite;
        }

        if (stats.health.usage)
        {

        }

        if (stats.contact.usage)
        {

        }

        if (stats.movement.usage)
        {

        }

        if (stats.weapon.usage)
        {
            gameObject.AddComponent(typeof(WeaponController));
            WeaponController controller = GetComponent<WeaponController>();

            controller.Initialize(stats);
        }
    }

    private void Die()
    {
        Debug.Log("Death");

        Destroy(gameObject);
    }
}
