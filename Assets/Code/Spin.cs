using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + speed, transform.eulerAngles.z);
    }
}
