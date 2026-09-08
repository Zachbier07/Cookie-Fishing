using UnityEngine;

public class DockManager : MonoBehaviour
{
    public GameObject dockPrefab;
    public Transform originDock;
    public int docksOwned = 0;
    public int dockPrice;
    [SerializeField] Transform sign;
    
    //To help with spawning
    Transform lastDock;

    private void Start()
    {
        //ONLY IF THERE IS NO SAVE
        lastDock = originDock;
    }

    public void addDock()
    {
        GameObject newDock = Instantiate(dockPrefab,transform); 
        newDock.transform.position = new Vector3(lastDock.position.x - 5, lastDock.position.y, lastDock.position.z);
        lastDock = newDock.transform;
        sign.position = sign.position + new Vector3(-5,0,0);
        docksOwned++;
    }

    public void purchase(Compendium comp)
    {
        if(comp.money >= dockPrice)
        {
            comp.money -= dockPrice;
            dockPrice += dockPrice/5;
            addDock();
        }
    }

}
