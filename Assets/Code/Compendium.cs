using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Compendium : MonoBehaviour
{
    public int money = 0;
    [SerializeField] TextMeshProUGUI moneyGui;
    [SerializeField] private BoardStats[] boards;
    [SerializeField] private GameObject physicalCompendium;
    [SerializeField] private MonoBehaviour[] disableWhenOpen;
    [SerializeField] AudioSource source;
    private InputAction inventory;
    private InputAction devButton;
    bool active;
    private void Start()
    {
        inventory = InputSystem.actions.FindAction("Inventory");
        devButton = InputSystem.actions.FindAction("Dev");
        active = physicalCompendium.activeInHierarchy;
    }

    private void Update()
    {
        if(inventory.WasPressedThisFrame())
        {
            active = !active;
            foreach(MonoBehaviour i in disableWhenOpen)
            {
                i.enabled = !active;
            }
            if(active) Cursor.lockState = CursorLockMode.None;
            else Cursor.lockState = CursorLockMode.Locked;
            physicalCompendium.SetActive(active);
        }
        if (devButton.WasPressedThisFrame())
        {
            money += 5;
        }
        moneyGui.text = "$"+money;
    }

    public void addOne(int x)
    {
        boards[x].addOne();
    }

    public void sellAll()
    {
        bool played = false;

        foreach(BoardStats i in boards)
        {
            int origMoney = 0;
            money += i.sell();
            if(origMoney != money && !played) {source.Play(); played =true;}
        }
        Debug.Log("SOLD!");
    }
}
