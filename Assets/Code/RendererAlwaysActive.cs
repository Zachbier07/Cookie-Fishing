using UnityEngine;

public class RendererAlwaysActive : MonoBehaviour
{
    void LateUpdate()
    {
        if(transform.GetChild(0).GetComponent<MeshRenderer>())
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
    }
}
