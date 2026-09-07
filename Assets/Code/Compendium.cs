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
    private InputAction inventory;
    bool active;
    private void Start()
    {
        inventory = InputSystem.actions.FindAction("Inventory");
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
        moneyGui.text = "$"+money;
    }

    public void addOne(int x)
    {
        boards[x].addOne();
    }

    public void sellAll()
    {
        foreach(BoardStats i in boards)
        {
            money += i.sell();
        }

        Debug.Log("SOLD!");
    }
}
