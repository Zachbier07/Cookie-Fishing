using UnityEngine;
using TMPro;
using UnityEngine.InputSystem.Controls;

public class BoardStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TotalNum;
    [SerializeField] private TextMeshProUGUI HeldNum;
    [SerializeField] private Cookie cookie;

    public void addOne()
    {
        TotalNum.text = int.Parse(TotalNum.text)+1 +"";
        HeldNum.text = int.Parse(HeldNum.text)+1 +"";
    }

    public int sell()
    {
        int amount = int.Parse(HeldNum.text);
        HeldNum.text = "0";
        return cookie.cookieWorth * amount;
    }
}
