using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ShootBullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;

    void Start()
    {
        StartCoroutine(ShootDelay());
    }
    
    private IEnumerator ShootDelay()
    {
        while(true)
        {  
            yield return new WaitForSeconds(2f);
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.transform.rotation);
        }
    }
}
