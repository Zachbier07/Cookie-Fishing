using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rod : MonoBehaviour
{
    [SerializeField] float chargPerFrame;
    [SerializeField] float maxCharge;
    [SerializeField] float maxAngle;
    [SerializeField] Bobber bobber;
    [SerializeField] LineRenderer line;
    [SerializeField] Transform top;
    [SerializeField] Popup popup;
    float charge = 0;
    private InputAction castInput;
    [SerializeField]bool lockRod = false;

    void Start()
    {
        castInput = InputSystem.actions.FindAction("Cast");
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0,top.position);
        line.SetPosition(1,bobber.transform.position);

        //Allow casting again letting go after a catch
        if (castInput.WasReleasedThisFrame()) lockRod = false;

        //Catch
        if(bobber.bit && castInput.WasPressedThisFrame())
        {
            bobber.GetComponent<Rigidbody>().isKinematic = true;
            bobber.transform.position = new Vector3(0,10000,0);
            //Actually Catch the cookie
            Cookie cookie = GetComponent<Catch>().catchCookie();
            popup.Show(cookie);
            Debug.Log("Caught " + cookie.cookieType + " Cookie!");
            //Lock casting until let go
            lockRod = true;
            line.enabled = false;
            return;
        }
        //Lock temp after failed cast
        else if(castInput.WasPressedThisFrame() && bobber.inWater) {
            bobber.GetComponent<Rigidbody>().isKinematic = true;
            lockRod = true;
            line.enabled = false;
            bobber.transform.position = new Vector3(0,10000,0);
        }

        //Launch
        if (castInput.WasReleasedThisFrame() && charge > 0)
        {
            line.enabled = true;
            bobber.Launch(charge);
            return;
        }


        //Wind
        if(castInput.IsPressed() && !lockRod)charge += chargPerFrame;
        else charge = 0;
        if(charge > maxCharge) charge = maxCharge;
        transform.localEulerAngles = new Vector3(-(maxAngle*(charge/maxCharge)),0,0);
    }
}
