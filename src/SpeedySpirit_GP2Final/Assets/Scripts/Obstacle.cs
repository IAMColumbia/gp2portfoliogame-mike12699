using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed = 5;
    //public bool ClockwiseRotation;
    //public float Rotation = 200;
    //private float rotZ;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        /*if (ClockwiseRotation == false)
        {
            rotZ += -Time.deltaTime * Rotation;
        }
        else
        {
            rotZ += Time.deltaTime * Rotation;
        }

        transform.rotation = Quaternion.Euler(0, 0, rotZ);*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().health -= damage;
            Debug.Log(collision.GetComponent<Player>().health);
            Destroy(gameObject);
        }
    }
}
