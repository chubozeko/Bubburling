using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private float bubbleStrength = 100f;
    SpriteRenderer sr;
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
            Debug.Log("BUBBLE POPPED!");
            Destroy(gameObject);
        }

        sr.color = new Color(1,1,1, (bubbleStrength*2)/100);
    }

    public void ReduceBubbleHealth(float amount)
    {
        bubbleStrength -= amount;
    }
}
