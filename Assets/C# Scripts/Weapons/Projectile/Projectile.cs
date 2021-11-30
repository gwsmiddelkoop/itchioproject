using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Projectile : MonoBehaviour
{
    [SerializeField] private StatGroupProjectile stats;

    public void Initialize(StatGroupProjectile stats)
    {
        this.stats = stats;

        SetUp();
    }

    public void SetUp()
    {
        if (stats.sprite != null)
        {
            gameObject.AddComponent(typeof(SpriteRenderer));
            SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();

            renderer.sprite = stats.sprite;
        }

        if (stats.moveable)
        {
            gameObject.AddComponent(typeof(Mover));
            Mover mover = gameObject.GetComponent<Mover>();

            if (true)
            {
                gameObject.AddComponent(typeof(MovementProjectileStraight));
                gameObject.GetComponent<MovementProjectileStraight>().Initialize(mover);
            }
        }
    }
}