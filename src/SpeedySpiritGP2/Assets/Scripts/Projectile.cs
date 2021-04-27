using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    public float cooldownTime = 10;
    private float nextFireTime = 0;
    public int secondsLeft = 10;
    public bool takingAway = false;
    public Transform firePoint;
    public GameObject projectilePrefab;
    //public GameObject countdownDisplay;
    public Text cooldownDisplay;

    private void Start()
    {
        cooldownDisplay.text = "" + secondsLeft;
    }

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (takingAway == false && secondsLeft > 0)
                {
                    StartCoroutine(TimerTake());
                    cooldownDisplay.text = cooldownTime.ToString();
                }
                Shoot();
                nextFireTime = Time.time + cooldownTime;
            }
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        cooldownDisplay.text = "" + secondsLeft;
    }
}
