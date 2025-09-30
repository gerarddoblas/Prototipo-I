using UnityEngine;

public class Plot : MonoBehaviour
{
    public PlantData plantData;
    private int currentStage;
    private float plantedTime;
    private GameObject currentPlant;

    public bool IsPlanted => plantData != null;

    public void Plant(PlantData newPlant)
    {
        if (IsPlanted)
        {
            Debug.Log("Hey! I'm already a plant");
            return;
        }

        plantData = newPlant;
        currentStage = -1;
        plantedTime = Time.time;

        Debug.Log("Calling Growth");
        NextGrowth();
    }

    public void CheckGrowth()
    {
        if (!IsPlanted)
        {
            Debug.Log("Hey! I'm don't exist yipiiie");
            return;
        }

        float elapsed = Time.time - plantedTime;

        if(currentStage + 1 < plantData.growthStages.Length && elapsed >= plantData.growthTimes[currentStage + 1])
        {
            Debug.Log("Calling Growth");
            NextGrowth();
        }
    }

    private void NextGrowth()
    {
        currentStage++;

        if(currentPlant != null)
        {
            Debug.Log("Bye bye old me");
            Destroy(currentPlant);
        }


        if(currentStage < plantData.growthStages.Length)
        {
            Debug.Log("Yeeeeey! I grow up");
            currentPlant = Instantiate(plantData.growthStages[currentStage], transform.position, Quaternion.identity, transform);
        }
    }

    public void Harvest()
    {
        if (!IsPlanted || currentStage < plantData.growthStages.Length - 1)
        {
            Debug.Log("Not today");
            return;
        }

        Debug.Log("Yw. Harvested");

        Destroy(currentPlant);
        plantData = null;
        currentStage = -1;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        //PlantManager.Instance.AssignPlot(this);
    }
    
}
