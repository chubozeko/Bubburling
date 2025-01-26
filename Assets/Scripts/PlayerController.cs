using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Transform bubbleSpawner;
    public Transform bubbleStartPos;
    public GameObject bubblePrefab;
    public Blower blowerL;
    public Blower blowerR;
    // public Slider SL_BubbleInflation;
    public List<GameObject> bubbles;
    bool isInflating = false;
    public bool canBlowBubbles;
    float bubbleScale;
    GameObject newBubble = null;


    void Start()
    {
        // SL_BubbleInflation.value = 0f;
        bubbleScale = 0f;
        bool isInflating = false;
        canBlowBubbles = true;
        
        blowerL.gameObject.SetActive(false);
        blowerR.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canBlowBubbles)
        {
            if (Input.GetButtonDown("Inflate"))
            {
                isInflating = true;
                // SL_BubbleInflation.value += Time.deltaTime;
                newBubble = Instantiate(bubblePrefab, bubbleSpawner);
                newBubble.transform.localScale = Vector3.zero;
            }
            else if (Input.GetButtonUp("Inflate"))
            {
                isInflating = false;
                // SL_BubbleInflation.value -= 0.05f * Time.deltaTime;
                if (newBubble != null)
                {
                    newBubble.transform.position = bubbleStartPos.position;
                    // bubbles.Add(Instantiate(newBubble, bubbleStartPos.position, Quaternion.identity).GetComponent<Bubble>());
                    // bubbles.Add(newBubble);
                    canBlowBubbles = false;
                }
            }
        }
        
        
        if (Input.GetButtonDown("BlowLeft"))
        {
            blowerL.gameObject.SetActive(true);
            // TODO: deduct air capacity
        }
        // else if (Input.GetButtonUp("BlowLeft"))
        // {
        //     blowerL.gameObject.SetActive(false);
        // }

        if (Input.GetButtonDown("BlowRight"))
        {
            blowerR.gameObject.SetActive(true);
            // TODO: deduct air capacity
        }
        // else if (Input.GetButtonUp("BlowRight"))
        // {
        //     blowerR.gameObject.SetActive(false);
        // }

        if (isInflating)
            bubbleScale += Time.deltaTime * 2f;
        // else
        //     SL_BubbleInflation.value -= Time.deltaTime;

        // bubbleScale = SL_BubbleInflation.value * 2f;
        if (newBubble != null)
            newBubble.transform.localScale = new Vector3(bubbleScale, bubbleScale, bubbleScale);

        if (bubbleScale >= 2f)
        {
            Destroy(newBubble);
            Debug.Log("POP!!!");
            bubbleScale = 0f;
        }
    }
}
