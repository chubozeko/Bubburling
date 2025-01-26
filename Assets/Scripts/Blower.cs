using UnityEngine;

public class Blower : MonoBehaviour
{
    Animator animBlower;
    public GameObject gustOfAir;
    public float blowForce = 2f;
    void Awake()
    {
        // blowForce = 0f;
        animBlower = GetComponent<Animator>();
        animBlower.SetBool("isBlowing", true);
        // TODO: play blowing sound
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // blowForce += Time.deltaTime * 0.5f;
    }

    public float GetBlowForce() { return blowForce; }

    public void ResetBlow()
    {
        blowForce = 0f;
    }
}
