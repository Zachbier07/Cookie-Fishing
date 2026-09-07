using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private UnityEvent action;
    public string interactText;

    public void intereact()
    {
        action.Invoke();
    }
}
