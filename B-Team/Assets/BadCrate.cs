using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCrate : MonoBehaviour
{
    public TankController tankC;
    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        tankC = FindObjectOfType<TankController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x + 30 < tankC.transform.position.x)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "TankBody" && tankC.gracePeriodTimer > 0.1f)
        {
            tankC.TakeDamage(-1);
            tankC.rBody.AddExplosionForce(30, transform.position, 30f,1f,ForceMode.Impulse);
            tankC.gracePeriodTimer = 0f;
            Instantiate(ps,transform.position,transform.rotation);
            ps.Play();
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(ps, transform.position, transform.rotation);
            ps.Play();
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "Terrain")
        {
            Instantiate(ps, transform.position, transform.rotation);
            ps.Play();
            Destroy(this.gameObject);
        }

    }
}
