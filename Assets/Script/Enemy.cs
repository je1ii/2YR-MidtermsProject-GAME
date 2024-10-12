using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemySpawner es;
    private UI ui;
    private float step;
    private Material enemyMat;
    private Material bulletMat;
    private Color enemyColor;
    private Color bulletColor;

    private float scale;
    private float addScale;

    public static List<Enemy> enemyList = new List<Enemy>();
    public static List<Enemy> GetEnemyList()
    {
        return enemyList;
    }

    void Awake()
    {
        ui = GameObject.FindObjectOfType<UI>(); 
        es = GameObject.FindObjectOfType<EnemySpawner>();
        enemyList.Add(this);

        scale = 0.01f;
        addScale = 0.03f;
    }

    void Update()
    {
        transform.localScale = new Vector3(scale,scale,scale);
        if(scale <= 0.6)
        {
            scale += addScale * Time.deltaTime;
        }

        step = es.enemySpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, es.target.position, step);
        transform.Rotate(es.rotation * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            enemyMat = this.GetComponent<MeshRenderer>().material;
            bulletMat = other.transform.GetComponent<MeshRenderer>().sharedMaterial;

            enemyColor = enemyMat.GetColor("_BaseColor");
            bulletColor = bulletMat.GetColor("_BaseColor");

            if(other != null)
            {
                if(enemyColor == bulletColor)
                {
                    ui.AddScore();
                    Destroy(other.gameObject);
                    enemyList.Remove(this);
                    Destroy(this.gameObject);
                }
                else
                {
                    Destroy(other.gameObject);
                }
            }
        }

        if(other.gameObject.CompareTag("Player"))
        {
            ui.PlayerDied();
        }
    }
}
