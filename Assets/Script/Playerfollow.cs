using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Playerfollow : MonoBehaviour
{
    //Player Tracking
    public Transform Playerpos;
    UnityEngine.AI.NavMeshAgent agent;

    //Range Calculations
    [SerializeField] float EnemyRange = 20f;
    private float distanceBetweenTarget;

    //Projectile
    [SerializeField] private Transform projectileSpawnPoint;
     [SerializeField] private GameObject projectilePrefab;
     private float countdownBetweenFire = 0f;
     [SerializeField] private float FireRate = 2f;     
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        distanceBetweenTarget = Vector3.Distance(Playerpos.position, transform.position);

        if(distanceBetweenTarget <= EnemyRange)
        {
            agent.destination = Playerpos.position;
        }

        // if the distance between target is less then or equal to navmesh stopping distance then shoot [Currently Broken]
        if(distanceBetweenTarget <= agent.stoppingDistance)
        {
            if(countdownBetweenFire <= 0f)
            {
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);

                countdownBetweenFire = 1f/FireRate;
            }
            countdownBetweenFire -= Time.deltaTime;
        }
    }
}
