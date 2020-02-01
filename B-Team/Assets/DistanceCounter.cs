using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceCounter : MonoBehaviour
{
    private TankController tankC;
    public TextMeshProUGUI text;
    public int distanceRequired = 1500;
    // Start is called before the first frame update
    void Start()
    {
        tankC = FindObjectOfType<TankController>();
    }

    // Update is called once per frame
    void Update()
    {
        float f = distanceRequired -tankC.transform.position.x;
        int i = (int)f;
        if(i > 0)
        {
            text.text = i + "m! ->";
        }
        else
        {
            text.text ="<- "+ i + "m!";
        }
        
    }
}
