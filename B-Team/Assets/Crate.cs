using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public TankController tankC;
    // Start is called before the first frame update
    void Start()
    {
        tankC = FindObjectOfType<TankController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x + 30 < tankC.transform.position.x)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "TankBody")
        {
            tankC.ammo += 2;
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "Terrain")
        {
            Destroy(this.gameObject);
        }
        
    }
}
