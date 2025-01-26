using System.Collections.Generic;
using UnityEngine;

public class BubbleTracker : MonoBehaviour
{
    [Header("Bullseye Point Ranges")]

    public List<GameObject> poppedBubbleSpots;
    public GameObject bubbleRemnant;
    void Start()
    {
        poppedBubbleSpots = new List<GameObject>();
    }

    public void RecordPoppedBubble(Transform bubble)
    {
        GameObject newRemnant = Instantiate(bubbleRemnant, bubble.transform.position, Quaternion.identity, transform);
        // newRemnant.transform.localScale = bubble.transform.localScale;
        poppedBubbleSpots.Add(newRemnant);
    }

    private Vector3 GetRemnantPositionAt(int index)
    {
        return poppedBubbleSpots[index].transform.position;
    }

    public void ResetBubbleTracker()
    {
        poppedBubbleSpots.Clear();
        
        Instantiate(bubbleRemnant, transform);
    }


}
