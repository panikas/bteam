using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TankController : MonoBehaviour
{
    public Rigidbody rBody;
    public GameObject barrel;
    public Transform forcePoint;
    public float shotForce;
    public TextMeshPro ammoText;
    public int ammo;
    private float cooldownTimer;
    public float cooldown;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "Ammo: " + ammo;
        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer > cooldown && ammo > 0)
        {
            ammo--;
            rBody.AddForce(barrel.transform.up*shotForce, ForceMode.Impulse);
            cooldownTimer = 0;
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
        cooldownTimer += Time.deltaTime;
    }
}
