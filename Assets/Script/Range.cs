using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Range : MonoBehaviour
{
    public GameObject center;
    public float playerRange;
    public float rayLength;
    public LayerMask layer;

    void Update()
    {
        foreach(Enemy enemy in Enemy.GetEnemyList())
        {
            if(enemy != null)
            {
                if(Vector3.Distance(transform.position, enemy.transform.position) <= playerRange)
                {
                    transform.LookAt(enemy.transform.position);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, playerRange);
        Gizmos.DrawRay(transform.position, Vector3.forward * rayLength);
    }
}
