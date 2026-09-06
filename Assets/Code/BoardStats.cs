using UnityEngine;
using TMPro;
using UnityEngine.InputSystem.Controls;

public class BoardStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TotalNum;
    [SerializeField] private TextMeshProUGUI HeldNum;

    public void addOne()
    {
        TotalNum.text = int.Parse(TotalNum.text)+1 +"";
        HeldNum.text = int.Parse(HeldNum.text)+1 +"";
    }
}
