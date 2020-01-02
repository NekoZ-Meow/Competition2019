﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ES01_Attack : MonoBehaviour
{
    private GameObject E_Bullet = null;

    private GameObject Player;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Player_Status>().Hp -= 10;
        }
    }
    public void Init(float bullet_speed, float shot_delay)
    {
        StartCoroutine(Sniper(bullet_speed, shot_delay));
    }

    IEnumerator Sniper(float bullet_speed, float shot_delay)
    {
        Player = GameObject.Find("Player");
        E_Bullet = (GameObject)Resources.Load("E_Bullet");
        while (true)
        {
            double distance_x = Player.transform.position.x - this.gameObject.transform.position.x;
            double distance_y = Player.transform.position.y - this.gameObject.transform.position.y;
            double rad = Math.Atan2(distance_y, distance_x);
            GameObject new_obj = Instantiate(E_Bullet, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
            new_obj.GetComponent<E_Bullet_Status>().Init((float)Math.Cos(rad) * bullet_speed, (float)Math.Sin(rad) * bullet_speed);
            yield return new WaitForSeconds(shot_delay);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}