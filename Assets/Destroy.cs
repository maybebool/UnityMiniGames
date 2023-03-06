using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Destroy : MonoBehaviour {

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject platform;
    private GameObject myPlat;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        myPlat = Instantiate(platform, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (1 + Random.Range(0.5f, 1f))), Quaternion.identity);
        Destroy(col.gameObject);
    }
}
