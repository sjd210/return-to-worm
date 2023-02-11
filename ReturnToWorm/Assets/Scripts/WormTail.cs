using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WormTail : MonoBehaviour
{
    public Transform wormTailGfx;
    public float circleDiameter;

    public Sprite tailSprite;
    public Sprite middleSprite;
    public GameObject parentWorm;

    public Transform wormHead;
    private List<Transform> wormTail = new List<Transform>();
    private List<Vector2> positions = new List<Vector2>();
    private List<Vector2> rotations = new List<Vector2>();

    private float timer;

    void Start()
    {
        positions.Add(wormTailGfx.position);
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;

        float distance = ((Vector2)wormTailGfx.position - positions[0]).magnitude;
        
        if (distance > circleDiameter)
        {
            Vector2 direction = ((Vector2)wormTailGfx.position - positions[0]).normalized;
            
            positions.Insert(0, positions[0] + direction * circleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= circleDiameter;
        }

       //  Debug.Log(parentWorm.transform.rotation);

        for (int i = 0; i < wormTail.Count; i++)
        {
            wormTail[i].position = Vector2.Lerp(positions[i + 1], positions[i], distance / circleDiameter);
            wormTail[i].localRotation = Quaternion.Euler(0.0f, 0.0f, parentWorm.transform.rotation.z * -1.0f);
           /*   if (i != 0)
              {
                  Quaternion rotation = Quaternion.LookRotation(wormTail[i - 1].position - wormTail[i].position, wormTail[i].TransformDirection(Vector3.forward));
                  wormTail[i].localRotation = new Quaternion(0, 0, rotation.z, rotation.w);
              }
              else
              {
                  Quaternion rotation = Quaternion.LookRotation(wormHead.position - wormTail[i].position, wormTail[i].TransformDirection(Vector3.forward));
                  wormTail[i].localRotation = new Quaternion(0, 0, rotation.z, rotation.w);
              } */

            /*Debug.Log(parentWorm.transform.rotation);
            wormTail[i].localRotation = Quaternion.Euler(0.0f, 0.0f, parentWorm.transform.rotation.z * -1.0f * 180);
            if (i == 0)
            {
                wormTail[i].localRotation = Quaternion.Euler(0.0f, 0.0f, parentWorm.transform.rotation.z * 180);
            }
            else if (timer > 5)
            {
               // wormTail[i].localRotation *= wormTail[i - 1].localRotation;// * Quaternion.Euler(0.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);
                timer = 0;
            } */
        }
    }
    
    public void AddTail()
    {
        Transform tail = Instantiate(wormTailGfx, positions[positions.Count - 1], wormTailGfx.rotation, transform);
        tail.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -wormTail.Count;
       // tail.gameObject.GetComponent<SpriteRenderer>().sprite = tailSprite;
        if (!(wormTail.Count == 0))
        {
        //    wormTail[wormTail.Count - 1].gameObject.GetComponent<SpriteRenderer>().sprite = middleSprite;
        }
        wormTail.Add(tail);
        positions.Add(tail.position);
    }
}
