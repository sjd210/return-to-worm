using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public int head_index = 0;
    public List<Swarmite> swarm = new List<Swarmite>();
    void Start()
    {
        
    }

    // Update is called once per frame

    public float close_constant = 1.5f;
    public float very_close_constant = 1f;
    public float repulsion_constant = 0.1f;
    public float high_repulsion_constant = 1f;
    public float far_constant = 3f;
    public float attraction_constant = 0.1f;

    public float head_attraction_constant = 1f;
    void FixedUpdate()
    {
        Swarm_Update_A();
    }

    void Swarm_Update_A(){
        for(int i = 1; i < swarm.Count; i++){//skip first element because don't mess with the head

            for(int j = 0; j < swarm.Count; j++){

                if(i == j) continue;

                Vector2 d = swarm[j].rb.position - swarm[i].rb.position;

                if(d.magnitude < very_close_constant){
                    swarm[i].rb.AddForce(-d.normalized*high_repulsion_constant, ForceMode2D.Impulse);
                    continue;
                }

                if(d.magnitude < close_constant){
                    swarm[i].rb.AddForce(-d.normalized*repulsion_constant, ForceMode2D.Impulse);
                    continue;
                }

                if(d.magnitude > far_constant){
                    swarm[i].rb.AddForce(d.normalized*attraction_constant, ForceMode2D.Impulse);
                    continue;
                }

                //swarm[i].rb.velocity =  0.95f*swarm[i].rb.velocity + 0.05f*swarm[j].rb.velocity; 
            }

            //Vector2 x = swarm[0].rb.position - swarm[i].rb.position;

            //if(x.magnitude > close_constant){
            //    swarm[i].rb.AddForce(x.normalized*head_attraction_constant, ForceMode2D.Impulse);
            //}

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
