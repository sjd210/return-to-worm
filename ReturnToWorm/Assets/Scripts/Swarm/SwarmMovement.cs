using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwarmMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public int head_index = 0;

    public List<Tuple<Swarmite, float>> waitingForSwarm = new List<Tuple<Swarmite, float>>();
    public List<Swarmite> swarm = new List<Swarmite>();

    public List<Swarmite> littleWorm = new List<Swarmite>();
    public List<Swarmite> bigWorm = new List<Swarmite>();
    private List<Swarmite> daddyWorm = new List<Swarmite>();

    public GameObject wormSpawInstance;

    public GameObject bloodSmall;

    public float close_distance = 1f;
    public float very_close_distance = 0.5f;
    public float far_distance = 1.5f;
    public float very_far_distance = 2f;
    public float close_repulsion = 0.1f;
    public float very_close_repulsion = 0.5f;
    public float far_attraction = 0.3f;
    public float very_far_attraction = 0.1f;
    public float head_attraction = 1f;

    private float timeRemaining = 10f;

    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;

    void FixedUpdate()
    {
        Swarm_Update_A();
    }

    private void Update()
    {
        if (littleWorm.Count + bigWorm.Count * 7 > 14)
        {
            wall2.SetActive(false);
        }
        if (littleWorm.Count + bigWorm.Count * 7 > 28)
        {
            wall3.SetActive(false);
        }
        if (littleWorm.Count + bigWorm.Count * 7 > 42)
        {
            wall4.SetActive(false);
            if (timeRemaining > 0f)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene(sceneName: "Earth");
            }
        }

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
        int littlWormToBig = 7;
        if (littleWorm.Count >= littlWormToBig)
        {
            int n = littleWorm.Count / littlWormToBig;
            for (int i = n*littlWormToBig-1; i >= n; i--)
            {
                Instantiate(bloodSmall, littleWorm[i].transform.position, Quaternion.identity);
                Destroy(littleWorm[i].gameObject);
                swarm.Remove(littleWorm[i]);
                littleWorm.RemoveAt(i);
                
            }

            for (int i = n - 1; i >= 0; i--)
            {
                Instantiate(bloodSmall, littleWorm[i].transform.position, Quaternion.identity);
                littleWorm[i].transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                littleWorm[i].GetComponent<WormTail>().circleDiameter /= 0.4f;
                bigWorm.Add(littleWorm[i]);
                littleWorm.RemoveAt(i);
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
