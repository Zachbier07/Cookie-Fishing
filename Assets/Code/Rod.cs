using UnityEngine;
using UnityEngine.InputSystem;

public class Rod : MonoBehaviour
{
    [SerializeField] float chargPerFrame;
    [SerializeField] float maxCharge;
    [SerializeField] float maxAngle;
    float charge = 0;
    private InputAction castInput;

    void Start()
    {
        castInput = InputSystem.actions.FindAction("Cast");
    }

    // Update is called once per frame
    void Update()
    {
        if(castInput.IsPressed())charge += chargPerFrame;
        else charge = 0;
        if(charge > maxCharge) charge = maxCharge;
        transform.localEulerAngles = new Vector3(-(maxAngle*(charge/maxCharge)),0,0);
    }
}
