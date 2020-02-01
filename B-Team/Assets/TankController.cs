using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TankController : MonoBehaviour
{
    public ScaleEyesWhenShoot eyeOne, eyeTwo;
    private CameraShake camShake;
    public Rigidbody rBody;
    public GameObject barrel, tower;
    public Transform bulletFirePoint;
    public float shotForce;
    public TextMeshProUGUI ammoText;
    public int ammo;
    public float cooldownTimer, gracePeriodTimer;
    public float cooldown;
    private Vector3 barrelStartPos, towerStartPos;
    public AnimationCurve recoilCurve;
    public int lives = 3;
    public ParticleSystem ps1, ps2;
    public float forceTimer = 0f;
    public Material tankMat;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        tankMat.color = new Color(1, 1, 1);
        //Time.timeScale = 0.2f;
        barrelStartPos = barrel.transform.localPosition;
        towerStartPos = tower.transform.localPosition;
        camShake = FindObjectOfType<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        //animation curve lerp between startpos and barrel transform.up * recoil length 
        ammoText.text = "Ammo: " + ammo + "\nLives: " + lives;
        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer > cooldown && ammo > 0)
        {
            camShake.shakeDuration = 0.25f;
            forceTimer = 0f;
            ps1.Play();
            ps2.Play();
            ammo--;
            rBody.AddForce(tower.transform.up*shotForce, ForceMode.Impulse);
            GameObject b = Instantiate(bullet, bulletFirePoint.position, bulletFirePoint.rotation);
            b.GetComponent<Rigidbody>().AddForce(-tower.transform.up * shotForce, ForceMode.Impulse);
            StartCoroutine(ShotAnimation());
            eyeOne.StartEyeScaleRoutine();
            eyeTwo.StartEyeScaleRoutine();
            cooldownTimer = 0;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 rot = new Vector3(0, 0, -1);
            tower.transform.Rotate(rot);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 rot = new Vector3(0, 0, 1);
            tower.transform.Rotate(rot);
        }
        forceTimer++;
        //ForceHaxxer();
        cooldownTimer += Time.deltaTime;
        gracePeriodTimer += Time.deltaTime;
    }
    public void TakeDamage(int livesModifier)
    {
        StartCoroutine(AffectLivesAndDisplayEffects(livesModifier));
    }
    IEnumerator AffectLivesAndDisplayEffects(int livesModifier)
    {
        lives += livesModifier;
        float t = 0;
        Color c = new Color(1,1,1);
        
        Color og = tankMat.color;
        if (livesModifier < 0)
        {
            c = new Color(1, 0, 0);
        }
        else if (livesModifier > 0)
        {
            c = new Color(0, 1, 0);
        }
        while (t < 1f)
        {
            tankMat.color = Color.Lerp(c, og, t);
            t += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
    void ForceHaxxer()
    {
        if(forceTimer > 3)
        {
            float f = Mathf.Clamp((forceTimer - 2) * 0.05f, 0, 5);
            rBody.AddForce(Vector3.down * f);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Terrain" && gracePeriodTimer > 1f)
        {
            TakeDamage(-1);
            gracePeriodTimer = 0f;
            rBody.AddForce(collision.contacts[0].normal * 20f, ForceMode.Impulse);
        }
        if(lives == 0)
        {
            Time.timeScale = Mathf.Epsilon;
        }
        if(collision.gameObject.name == "Water")
        {
            Time.timeScale = 0.05f;
            //victoryfunction
        }
        
        //Destroy(this.gameObject);
    }
    IEnumerator ShotAnimation()
    {
        float t = 0;
        Vector3 endPos = barrel.transform.localPosition + barrel.transform.up;
        Vector3 endPos2 = tower.transform.localPosition + tower.transform.up;
        while (t < recoilCurve.keys[recoilCurve.length - 1].time)
        {
            //print("LERPING THAT MADDAFAKKA");
            //barrel.transform.localPosition = Vector3.Lerp(barrelStartPos, endPos, recoilCurve.Evaluate(t));
            tower.transform .localPosition = Vector3.Lerp(towerStartPos, endPos2, recoilCurve.Evaluate(t));
            t += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}
