using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundGenerator : MonoBehaviour
{
    public GameObject bgTile;
    private List<GameObject> bgTileList;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            bgTileList.Add(bgTile);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
