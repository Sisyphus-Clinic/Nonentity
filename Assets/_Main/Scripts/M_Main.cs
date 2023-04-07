using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Main : MonoBehaviour
{
    public GameObject pre_Enemy;
    public float spawnTime;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer<0)
        {
            timer = spawnTime;
            Instantiate(pre_Enemy, new Vector3(Random.Range(-8.5f, 8.5f), 0.25f, Random.Range(-4f, 4f)), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
