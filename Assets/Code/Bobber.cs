using Unity.VisualScripting;
using UnityEngine;

public class Bobber : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform m_camera;
    [SerializeField] private float chancePerFrame;
    [SerializeField] private int framesForBite = 90;
    private float framesLeft;
    public bool bit;
    public bool inWater = false;

    void Start()
    {
        framesLeft = framesForBite;
    }
    public void Launch(float force)
    {
        rb.isKinematic = false;
        transform.position = m_camera.position;
        rb.AddForce(m_camera.transform.forward*force,ForceMode.Impulse);
        rb.AddForce(transform.up*(force/10));
    }

    void Update()
    {
        if(transform.position.y < .15f) 
        {
            inWater = true;
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            rb.linearVelocity = Vector3.zero;
            if (!bit)
            {
                //Random chance for bite
                if(chancePerFrame >= Random.Range(0f, 100f))
                {
                    Debug.Log("Bite!");
                    bit = true;
                }
            }
            else
            {
                framesLeft--;
                if(framesLeft <= 0)
                {
                    bit = false;
                    framesLeft = framesForBite;
                }
            }
        }
        else 
        {
            inWater = false;
            bit = false;
        }
    }
}
