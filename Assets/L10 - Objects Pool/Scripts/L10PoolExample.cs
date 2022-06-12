using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L10PoolExample : MonoBehaviour
{
    [SerializeField] private int poolCount = 3;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private L10Cube cubePrefab;

    private PoolMono<L10Cube> pool;

    private void Start()
    {
        this.pool = new PoolMono<L10Cube>(this.cubePrefab, this.poolCount, this.transform);
        this.pool.autoExpand = this.autoExpand;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            this.CreateCube();
        }
    }

    private void CreateCube()
    {
        var rX = Random.Range(-5f, 5f);
        var rZ = Random.Range(-5f, 5f);
        var rY = 0;

        var rPos = new Vector3(rX, rY, rZ);
        
        var cube = this.pool.GetFreeElement();
        cube.transform.position = rPos;
    }
}
