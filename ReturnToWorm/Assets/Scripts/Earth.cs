using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    List<EarthWorm> worms = new List<EarthWorm>();

    // Update is called once per frame

    public float quit_game_countdown = 333f;
    public bool spawn = true;
    public bool delete = false;
    public GameObject wormSpawInstance;
    public float max_cooldown = 1f;
    public float cooldown = 0f;

    public float accelaration = 0.95f;
    void FixedUpdate()
    {
        if(cooldown > 0f) cooldown -= Time.fixedDeltaTime;

        if(delete){
            foreach (EarthWorm worm in worms){Destroy(worm.gameObject);}
            spawn = false;
        }

        

        if(cooldown <= 0f && spawn){
            cooldown = max_cooldown;
            max_cooldown = max_cooldown * accelaration;
            worms.Add(Instantiate(wormSpawInstance, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f))).GetComponent<EarthWorm>());
        }

        if(quit_game_countdown > 0f){ quit_game_countdown -= Time.fixedDeltaTime;} else {Application.Quit();}
    }
}
