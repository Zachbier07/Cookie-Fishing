using UnityEngine;

public class Catch : MonoBehaviour
{
    public Cookie[] cookies;
    [Header("Out of 100000")]
    public float[] catchNum;

    public Cookie catchCookie()
    {
        float num = Random.Range(0,100000);
        Debug.Log(num);
        for(int i = 0; i < cookies.Length; i++)
        {
            if(num < catchNum[i] && num > catchNum[i+1])
            {
                return cookies[i];
            }
        }
        return null;
    }
}
