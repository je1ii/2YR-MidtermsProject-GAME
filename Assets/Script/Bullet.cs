using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletRange;

    private Vector3 player;

    void Awake()
    {
        player = new Vector3(0,0,0);
    }
    void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);

        if(Vector3.Distance(player, transform.position) > bulletRange)
        {
            Destroy(this.gameObject);
        }
    }
}