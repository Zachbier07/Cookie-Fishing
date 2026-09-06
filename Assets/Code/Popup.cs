using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Popup : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] TextMeshProUGUI cookieNameText;
    bool active  = false;
    RectTransform rTransform;
    Vector3 goalRot = new Vector3(90,180,0);
    Vector3 goalSize = Vector3.zero;

    void Start()
    {
        rTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        rTransform.eulerAngles = Vector3.Lerp(rTransform.eulerAngles,goalRot,.15f);
        rTransform.localScale = Vector3.Lerp(rTransform.localScale,goalSize,.15f);
    }

    public void Show(Cookie cookie)
    {
        image.texture = cookie.texture;
        goalRot = Vector3.zero;
        goalSize = new Vector3(1,1,1);
        cookieNameText.text = cookie.cookieType + " Cookie";
        StartCoroutine(goAway());
    }

    IEnumerator goAway()
    {
        yield return new WaitForSeconds(2);
        goalRot = new Vector3(90,180,0);
        goalSize = new Vector3(0,0,0);
    }
}
