using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float speed;
    private TankController tankC;
    // Start is called before the first frame update
    void Start()
    {
        tankC = FindObjectOfType<TankController>();
        speed = Random.Range(0.5f, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x + 30 < tankC.transform.position.x)
        {
            Destroy(this.gameObject);
        }
        Vector3 pos = transform.position;
        pos.x -= Time.deltaTime*speed;
        transform.position = pos;
    }
}
