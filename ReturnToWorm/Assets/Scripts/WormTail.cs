using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormTail : MonoBehaviour
{
    public Transform wormTailGfx;
    public float circleDiameter;

    private List<Transform> wormTail = new List<Transform>();
    private List<Vector2> positions = new List<Vector2>();
    // Start is called before the first frame update
    void Start()
    {
        positions.Add(wormTailGfx.position);
        
    }

    // Update is called once per frame
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

        }
    }
    
    public void AddTail()
    {
        Transform tail = Instantiate(wormTailGfx, positions[positions.Count - 1], Quaternion.identity, transform);
        wormTail.Add(tail);
        positions.Add(tail.position);
    }
}
