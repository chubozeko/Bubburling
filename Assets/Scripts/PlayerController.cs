using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform bubbleSpawner;
    public Transform bubbleStartPos;
    public GameObject bubblePrefab;
    public CameraMovement cameraMovement;
    public Blower blowerL;
    public Blower blowerR;
    // public Slider SL_BubbleInflation;
    public GameObject activeBubble;
    public float upwardsForce = 4f;
    bool isInflating = false;
    public bool canInflateBubbles;
    float bubbleScale;
    GameObject newBubble = null;
    [Range(4,16)]
    public int maxBubbles;
    int bubblesBlown = 0;

    void Start()
    {
        // SL_BubbleInflation.value = 0f;
        bubbleScale = 0f;
        bubblesBlown = 0;
        bool isInflating = false;
        canInflateBubbles = true;
        activeBubble = null;
        
        blowerL.gameObject.SetActive(false);
        blowerR.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canInflateBubbles)
        {
            if (Input.GetButtonDown("Inflate"))
            {
                isInflating = true;
                // SL_BubbleInflation.value += Time.deltaTime;
                newBubble = Instantiate(bubblePrefab, bubbleSpawner);
                newBubble.transform.localScale = Vector3.zero;
                bubblesBlown++;

            }
            else if (Input.GetButtonUp("Inflate"))
            {
                isInflating = false;
                // SL_BubbleInflation.value -= 0.05f * Time.deltaTime;
                if (newBubble != null)
                {
                    newBubble.transform.SetParent(null);
                    newBubble.transform.position = bubbleStartPos.position;
                    // bubbles.Add(Instantiate(newBubble, bubbleStartPos.position, Quaternion.identity).GetComponent<Bubble>());
                    activeBubble = newBubble;
                    canInflateBubbles = false;
                    cameraMovement.SetCameraTarget(activeBubble.transform);
                    GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
                }
            }
        } 
        
        if (Input.GetButtonDown("BlowLeft"))
        {
            blowerL.gameObject.SetActive(true);
            // TODO: deduct air capacity
        }
        else if (Input.GetButtonUp("BlowLeft"))
        {
            blowerL.gameObject.SetActive(false);
            Debug.Log("LEFT-BLOW with force " + blowerL.blowForce);
            if (activeBubble != null)
                BlowBubbleTowards(Vector2.right, blowerL.blowForce);
        }

        if (Input.GetButtonDown("BlowRight"))
        {
            blowerR.gameObject.SetActive(true);
            // TODO: deduct air capacity
        }
        else if (Input.GetButtonUp("BlowRight"))
        {
            blowerR.gameObject.SetActive(false);
            Debug.Log("RIGHT-BLOW with force " + blowerR.blowForce);
            if (activeBubble != null)
                BlowBubbleTowards(Vector2.left, blowerR.blowForce);
        }

        if (activeBubble != null)
        {
            if (Input.GetButtonDown("BlowUpwards"))
            {
                BlowBubbleTowards(Vector2.up, upwardsForce);
            }
        }
        else 
        {
            canInflateBubbles = true;
            cameraMovement.SetCameraTarget(transform);
            GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
            // if (bubblesBlown >= maxBubbles)
            // {
                
            // }
            // else
            // {
            //     canInflateBubbles = false;
            //     bubblesBlown = 0;
            //     canInflateBubbles = true;
            // }
        }

        if (isInflating)
            bubbleScale += Time.deltaTime * 2f;
        // else
        //     SL_BubbleInflation.value -= Time.deltaTime;

        // bubbleScale = SL_BubbleInflation.value * 2f;
        if (newBubble != null)
            newBubble.transform.localScale = new Vector3(bubbleScale, bubbleScale, bubbleScale);

        if (bubbleScale >= 2f)
        {
            newBubble.GetComponent<Bubble>().PopBubble();
            bubbleScale = 0f;
        }
    }

    private void BlowBubbleTowards(Vector2 direction, float blowForce)
    {
        activeBubble.GetComponent<Rigidbody2D>().AddForce(direction * blowForce);
        activeBubble.GetComponent<Bubble>().ReduceBubbleHealth(blowForce);
    }
}
