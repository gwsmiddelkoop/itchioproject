using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MovementMenu : MonoBehaviour
{
    [SerializeField]GameObject[] objectScale;
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
            for (int i = 0; i < objectScale.Length; i++)
            {
                objectScale[i].transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            }
            FindObjectOfType<SceneLoader>().LoadScene("SnowFare");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Start"))
        {
            for (int i = 0; i < objectScale.Length; i++)
            {
                objectScale[i].transform.localScale = new Vector3(1, 1, 1);

            }
        }
    }
}
