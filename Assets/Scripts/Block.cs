using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private void Start()
    {
        GetComponent<SpriteRenderer>().flipX = Random.value > 0.5f;
    }
    private void Update()
    {
        if (GameManager.Single.GameActive)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - GameManager.Single.Speed * Time.deltaTime, transform.position.z);

            if (transform.position.y < -GameManager.Single.RightUpperCorner.y - 5)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Single.Lives--;
        }
        else
        {
            GameManager.Single.Score++;
        }

        Destroy(collision.gameObject);
    }
}
