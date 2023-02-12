using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public int head_index = 0;

    public List<Tuple<Swarmite, float>> waitingForSwarm = new List<Tuple<Swarmite, float>>();
    public List<Swarmite> swarm = new List<Swarmite>();

    private List<Swarmite> littleWorm = new List<Swarmite>();
    private List<Swarmite> bigWorm = new List<Swarmite>();
    private List<Swarmite> daddyWorm = new List<Swarmite>();

    public GameObject wormSpawInstance;

    void Start()
    {

    }

    // Update is called once per frame

    public float close_distance = 1f;
    public float very_close_distance = 0.5f;
    public float far_distance = 1.5f;
    public float very_far_distance = 2f;
    public float close_repulsion = 0.1f;
    public float very_close_repulsion = 0.5f;
    public float far_attraction = 0.3f;
    public float very_far_attraction = 0.1f;
    public float head_attraction = 1f;
    void FixedUpdate()
    {
        Swarm_Update_A();
    }

    private void Update()
    {
        for (int i = waitingForSwarm.Count - 1; i >= 0; i--)
        {
            (Swarmite Worm, float t) = waitingForSwarm[i];
            if (Time.time - t > 1)
            {
                Worm.GetComponent<WormMovement>().inSwarm = true;
                swarm.Add(Worm);
                littleWorm.Add(Worm);
                waitingForSwarm.RemoveAt(i);
            }
        }
    }

    public void AddWorm(int n, Vector3 position)
    {
        for (int i = -(n+1)/2; i < n/2; i++)
        {
            GameObject Worm = Instantiate(wormSpawInstance, position + new Vector3(i*0.1f, 0f, 0f), Quaternion.identity);
            Worm.transform.localScale *= 0.4f;
            Worm.GetComponent<WormTail>().circleDiameter *= 0.4f;
            waitingForSwarm.Add(new Tuple<Swarmite, float>(Worm.GetComponent<Swarmite>(), Time.time));

        }
    }

    void Swarm_Update_A()
    {
        for (int i = 1; i < swarm.Count; i++)
        {//skip first element because don't mess with the head

            for (int j = 0; j < swarm.Count; j++)
            {

                if (i == j) continue;

                Vector2 d = swarm[j].rb.position - swarm[i].rb.position;

                if (d.magnitude < very_close_distance)
                {
                    swarm[i].rb.AddForce(-d.normalized * very_close_repulsion, ForceMode2D.Impulse);
                    continue;
                }

                if (d.magnitude < close_distance)
                {
                    swarm[i].rb.AddForce(-d.normalized * close_repulsion, ForceMode2D.Impulse);
                    continue;
                }

                if (d.magnitude > very_far_distance)
                {
                    swarm[i].rb.AddForce(d.normalized * very_far_attraction, ForceMode2D.Impulse);
                    continue;
                }

                if (d.magnitude > far_distance)
                {
                    swarm[i].rb.AddForce(d.normalized * far_attraction, ForceMode2D.Impulse);
                    continue;
                }

                //swarm[i].rb.velocity =  0.99f*swarm[i].rb.velocity + 0.01f*swarm[j].rb.velocity; 
            }

            Vector2 x = swarm[0].rb.position - swarm[i].rb.position;

            if(x.magnitude > close_distance){
                swarm[i].rb.AddForce(x.normalized*head_attraction, ForceMode2D.Impulse);
            }

        }
    }

    /*
    void Repulsion(RigidBody2D s)
    {
        //for s in swram if too close then move away
    }
    void Alignment(RigidBody2D s)
    {
        //for s in swram if neraby then align
    }
    void Attraction(RigidBody2D s)
    {
        for s in swarm
    }
    */
}
