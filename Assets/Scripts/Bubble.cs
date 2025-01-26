using Unity.VisualScripting;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private float bubbleStrength = 100f;
    private SpriteRenderer sr;
    private Vector3 bubblePopPosition;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bubbleStrength -= Time.deltaTime * 2f;
        // Debug.Log(GetComponent<Rigidbody2D>().linearVelocityY);

        if (bubbleStrength <= 0f)
        {
            PopBubble();
        }

        sr.color = new Color(1,1,1, bubbleStrength/100);
    }

    public void ReduceBubbleHealth(float amount)
    {
        bubbleStrength -= amount;
    }

    public void PopBubble()
    {
        Debug.Log("BUBBLE POPPED!");
        // TODO: play bubble pop sound
        FindObjectsByType<BubbleTracker>(FindObjectsSortMode.None)[0]
            .RecordPoppedBubble(transform);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Borders")
        {
            PopBubble();
        }
    }
}
