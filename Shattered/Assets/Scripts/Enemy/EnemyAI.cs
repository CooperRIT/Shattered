using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : BaseEnemyAI
{
    [SerializeField] float amplitude = .05f;
    [SerializeField] float frequency = 2f;

    [SerializeField] Transform mesh;

    float startingY;

    private void Start()
    {
        startingY = mesh.position.y;
    }

    public override void Update()
    {
        base.Update();
        mesh.position = new Vector3 (mesh.position.x, amplitude * Mathf.Sin(frequency * Time.time), mesh.position.z);
    }
}
