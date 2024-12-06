using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    [SerializeField] Transform[] rings = new Transform[2];

    float[] speeds = new float[2];
    Vector3[] directions = new Vector3[2];

    float maxSpeed = 80;
    float minSpeed = 60;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 2; i++)
        {
            speeds[i] = Random.Range(minSpeed, maxSpeed);
            directions[i] = Random.onUnitSphere.normalized;

        }
    }

    // Update is called once per frame
    void Update()
    {
        for( int i = 0; i < 2; i++)
        {
            rings[i].Rotate(directions[i], speeds[i] * Time.deltaTime);
        }
    }
}
