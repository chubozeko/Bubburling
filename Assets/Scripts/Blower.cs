using UnityEngine;

public class Blower : MonoBehaviour
{
    Animator animBlower;
    public GameObject gustOfAir;
    void Awake()
    {
        animBlower = GetComponent<Animator>();
        // TODO: play blowing sound
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
