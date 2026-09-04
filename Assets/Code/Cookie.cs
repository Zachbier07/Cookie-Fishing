using UnityEngine;

[CreateAssetMenu(fileName = "Cookie", menuName = "ScriptableObjects/Cookie", order = 1)]
public class Cookie : ScriptableObject
{
    public Texture texture;
    public string cookieType;
    public int cookieWorth;
}
