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

        
    }

    // Update is called once per frame
    void Update()
    {

        if (shootingLeft == true)
        {
            StartCoroutine(shootLeft());
        }
        if (shootingRight == true)
        {
            StartCoroutine(shootRight());
        }
        if (shootingUp == true)
        {
            StartCoroutine(shootUp());
        }
        if (shootingDown == true)
        {
            StartCoroutine(shootDown());
        }


    }


    private IEnumerator shootLeft()
    {
        while (shootingLeft == true)
        {
            shootingLeft = false;
            Instantiate(projectile, this.transform.position, Quaternion.Euler(0f, 0f, 90f));
            yield return new WaitForSeconds(timeToShoot);
            shootingLeft = true; 
        }

    }

    private IEnumerator shootRight()
    {
        while (shootingRight == true)
        {
            shootingRight = false; 
            Instantiate(projectile, this.transform.position, Quaternion.Euler(0f, 0f, 270f));
            yield return new WaitForSeconds(timeToShoot);
            shootingRight = true;
        }

    }

    private IEnumerator shootUp()
    {
        while (shootingUp == true)
        {
            shootingUp = false;
            Instantiate(projectile, this.transform);
            yield return new WaitForSeconds(timeToShoot);
            shootingUp = true;
        }

    }


    private IEnumerator shootDown()
    {
        while (shootingDown == true)
        {
            shootingDown = false;
            Instantiate(projectile, this.transform.position, Quaternion.Euler(0f, 0f, 180f));
            yield return new WaitForSeconds(timeToShoot);
            shootingDown = true;
        }

    }
    
}
