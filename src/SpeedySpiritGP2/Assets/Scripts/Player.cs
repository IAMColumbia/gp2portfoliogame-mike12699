using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    public Animator camAnim;
    public GameObject spawner;
    public GameObject gameOver;
    public GameObject stopScore;
    public Text healthDisplay;
    public float Yincrement;
    public float XIncrement;
    public float HorizontalSpeed;
    public float speed;
    public float MaxHeight;
    public float MinHeight;
    public float MinWidth;
    public float MaxWidth;
    public int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = health.ToString();
        //When player collides with an asteroid 3 times the Game Over screen loads
        if (health <= 0)
        {
            spawner.SetActive(false);
            gameOver.SetActive(true);
            Destroy(gameObject);
            Destroy(stopScore);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < MaxHeight)
        {
            camAnim.SetTrigger("shake");
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            transform.position = targetPos;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > MinHeight)
        {
            camAnim.SetTrigger("shake");
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            transform.position = targetPos;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > MinWidth)
        {
            targetPos = new Vector2(transform.position.x - XIncrement, transform.position.y);
            transform.position = targetPos;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < MaxWidth)
        {
            targetPos = new Vector2(transform.position.x + XIncrement, transform.position.y);
            transform.position = targetPos;
        }
    }
}
