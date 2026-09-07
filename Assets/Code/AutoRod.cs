using UnityEngine;
using UnityEngine.UI;

public class AutoRod : MonoBehaviour
{
    [SerializeField] Interactable interact;
    [Header("SaveStuff")]
    [SerializeField] int rodLevel;
    [SerializeField] int chestLevel;
    [Header("Line")]
    [SerializeField] RawImage cookieSprite;
    [SerializeField] Transform lineStart;
    [SerializeField] Transform lineEnd;
    [SerializeField] Vector3 lineEndUncaught;
    [SerializeField] Vector3 lineEndCaught;
    [SerializeField] LineRenderer line;
    [SerializeField] bool caught = false;
    Cookie cookieOnLine;

    void Update()
    {
        line.SetPosition(0, lineStart.position);
        line.SetPosition(1, lineEnd.position);
        
        if (caught)
        {
            lineEnd.localPosition = lineEndCaught;
        }
        else lineEnd.localPosition = lineEndUncaught;

        //Try to catch       
        if(rodLevel >= Random.Range(0f, 3600f) && !caught)
        {
            caught = true;
            cookieOnLine = FindAnyObjectByType<Catch>().catchCookie();
            cookieSprite.texture = cookieOnLine.texture; 
            interact.interactText = "Collect " + cookieOnLine.cookieType + " Cookie";
        }
    }

    public void Collect()
    {
        if (caught)
        {
            caught = false;
            interact.interactText = "";
            FindAnyObjectByType<Popup>().Show(cookieOnLine);
            FindAnyObjectByType<Compendium>().addOne(cookieOnLine.ID);
        }
    }
}
