using Unity.VisualScripting;
using UnityEngine;

public class Bobber : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform m_camera;
    [SerializeField] private float chancePerFrame;
    [SerializeField] private int framesForBite = 90;
    [SerializeField] private GameObject alert;
    [SerializeField] AudioClip splash;
    [SerializeField] AudioClip biteSound;
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
        transform.position = m_camera.position + m_camera.forward;
        
        rb.AddForce(m_camera.transform.forward*force,ForceMode.Impulse);
        rb.AddForce(transform.up*(force/10));
    }

    void Update()
    {
        alert.SetActive(bit);
        if(transform.position.y < .15f) 
        {
            if(!inWater) GetComponent<AudioSource>().PlayOneShot(splash);
            inWater = true;
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            rb.isKinematic = true;
            if (!bit)
            {
                //Random chance for bite
                if(chancePerFrame >= Random.Range(0f, 100f))
                {
                    Debug.Log("Bite!");
                    GetComponent<AudioSource>().PlayOneShot(biteSound);
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
