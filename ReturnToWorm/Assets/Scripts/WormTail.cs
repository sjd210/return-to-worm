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

    private List<Transform> wormTail = new List<Transform>();
    private List<Vector2> positions = new List<Vector2>();

    void Start()
    {
        positions.Add(wormTailGfx.position);
    }

    void Update()
    {

        float distance = ((Vector2)wormTailGfx.position - positions[0]).magnitude;
        
        if (distance > circleDiameter)
        {
            Vector2 direction = ((Vector2)wormTailGfx.position - positions[0]).normalized;
            
            positions.Insert(0, positions[0] + direction * circleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= circleDiameter;
        }

        for (int i = 0; i < wormTail.Count; i++)
        {
            wormTail[i].position = Vector2.Lerp(positions[i + 1], positions[i], distance / circleDiameter);
            wormTail[i].localRotation = Quaternion.Euler(0.0f, 0.0f, parentWorm.transform.rotation.z * -1.0f);
        }
    }
    
    public void AddTail()
    {
        Transform tail = Instantiate(wormTailGfx, positions[positions.Count - 1], wormTailGfx.rotation, transform);
        tail.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -wormTail.Count;
        wormTail.Add(tail);
        positions.Add(tail.position);
    }
}
