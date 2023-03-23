using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{

    private float projectileLifetime;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        projectileLifetime = 5f;
        speed = 2f;
        StartCoroutine(life());
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position += new Vector3(-2f * Time.deltaTime, 0f, 0);
        transform.position += transform.up * speed * Time.deltaTime;

    }

    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator life()
    {
        yield return new WaitForSeconds(projectileLifetime);
        Destroy(this.gameObject);
    }
}
