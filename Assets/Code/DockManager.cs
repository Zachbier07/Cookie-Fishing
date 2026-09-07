using UnityEngine;

public class DockManager : MonoBehaviour
{
    public GameObject dockPrefab;
    public Transform originDock;
    public int docksOwned;
    public int[] rodLevel;
    public int[] chectLevel;
    
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
    }

}
