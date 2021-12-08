using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MovementMenu : MonoBehaviour
{
    float horizontal;
    float vertical;

    public float runSpeed;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        
        if (Input.GetKeyDown(KeyCode.A) && gameObject.transform.rotation.y == 0)
        {
            gameObject.transform.Rotate(0, 180, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.Rotate(0, -180, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Start"))
        {
            FindObjectOfType<SceneLoader>().LoadScene("SnowFare");
        }
    }
}
