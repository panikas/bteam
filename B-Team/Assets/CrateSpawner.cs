using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    public GameObject crate;
    public GameObject tank;
    private float timer;
    public float timeBetweenDrops;
    public float xOffset, xRandMin, xRandMax, yOffset, yRandMin, yRandMax;
    public int startAmount;
    public float scaleMin, scaleMax;
    // Start is called before the first frame update
    void Start()
    {
        UpdateSpawnerPos();
        for (int i = 0; i < startAmount; i++)
        {
            InstantiateSkyObject();
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpawnerPos();


        if (timer > timeBetweenDrops)
        {
            InstantiateSkyObject();
            timer = 0;
        }
        timer += Time.deltaTime;
    }
    void UpdateSpawnerPos()
    {
        Vector3 newPos;
        newPos = transform.position;
        newPos.x = tank.transform.position.x + xOffset;
        newPos.y = tank.transform.position.y + yOffset;
        transform.position = newPos;
    }
    void InstantiateSkyObject()
    {
        Vector3 v3Rand = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20));
        Instantiate(crate, transform.position + v3Rand, transform.rotation);
    }
}
