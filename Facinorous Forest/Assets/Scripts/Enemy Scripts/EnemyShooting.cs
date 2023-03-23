using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public GameObject projectile;
    private float timeToShoot;
    public bool shootingLeft;
    public bool shootingRight;
    public bool shootingUp;
    public bool shootingDown;

    // Start is called before the first frame update
    void Start()
    {
        timeToShoot = 2f;

        StartCoroutine(shoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator shoot()
    {
        while (shootingLeft == true)
        {
            yield return new WaitForSeconds(timeToShoot);
            Instantiate(projectile, this.transform.position, Quaternion.Euler(0f, 0f, 90f));
        }
        while (shootingRight == true)
        {
            yield return new WaitForSeconds(timeToShoot);
            Instantiate(projectile, this.transform.position, Quaternion.Euler(0f, 0f, 180f));
        }
        while (shootingUp == true)
        {
            yield return new WaitForSeconds(timeToShoot);
            Instantiate(projectile, this.transform);
        }
        while (shootingDown == true)
        {
            yield return new WaitForSeconds(timeToShoot);
            Instantiate(projectile, this.transform.position, Quaternion.Euler(0f, 0f, 90f));
        }

    }
}
