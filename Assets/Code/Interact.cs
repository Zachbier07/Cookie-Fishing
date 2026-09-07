using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class Interact : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;
    [SerializeField] Camera m_camera;
    [SerializeField] TextMeshProUGUI text;
    private InputAction interact;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interact = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {   
        if (Physics.Raycast(m_camera.transform.position, m_camera.transform.forward, out hit)) {
            if (hit.transform.GetComponent<Interactable>())
            {
                text.text = hit.transform.GetComponent<Interactable>().interactText;
                if(interact.WasPressedThisFrame())
                {
                    hit.transform.GetComponent<Interactable>().intereact();
                }
            }
            else text.text = "";
        }
        else text.text = "";
    }
}
