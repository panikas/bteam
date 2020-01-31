using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    public GameObject crate;
    public GameObject tank;
    private float timer;
    public float timeBetweenDrops;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos;
        newPos = transform.position;
        newPos.x = tank.transform.position.x + 20;
        //newPos.y = tank.transform.position.y + 10;
        transform.position = newPos;
        if(timer > timeBetweenDrops)
        {
            Vector3 v3Rand = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5));
            Instantiate(crate,transform.position+v3Rand,transform.rotation);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
