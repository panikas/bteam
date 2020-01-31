using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public Rigidbody rBody;
    public GameObject barrel;
    public Transform forcePoint;
    public float shotForce;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float f = barrel.transform.rotation.z;
        print(f);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            //Vector3 v = new Vector3();
            //print(v);
            rBody.AddForce(barrel.transform.up*shotForce, ForceMode.Impulse);
            //rBody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 rot = new Vector3(0, 0, -1);
            barrel.transform.Rotate(rot);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 rot = new Vector3(0, 0, 1);
            barrel.transform.Rotate(rot);
        }
    }
}
