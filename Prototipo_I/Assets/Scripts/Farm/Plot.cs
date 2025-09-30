using UnityEngine;

public class Plot : MonoBehaviour
{
    public PlantData plantData;
    private int currentStage = -1;
    private float plantedTime;
    private GameObject currentPlant;

    public bool IsPlanted => plantData != null;

    public void Plant(PlantData newPlant)
    {
        if (IsPlanted) return;

        plantData = newPlant;
        currentStage = -1;
        plantedTime = Time.time;

        NextGrowth();
    }

    public void CheckGrowth()
    {
        if (IsPlanted) return;

        float elapsed = Time.time - plantedTime;

        if(currentStage + 1 < plantData.growthStages.Length && elapsed >= plantData.growthStages[currentStage + 1])
        {
            NextGrowth();
        }
    }

    private void NextGrowth()
    {
        currentStage++;

        if(currentPlant != null)
            Destroy(currentPlant);

        if(currentStage < plantData.growthStages.Length)
        {
            currentPlant = Instantiate(plantData.growthStages[currentStage], transform.position, Quaternion.identity, transform);
        }
    }

    public void Harvest()
    {
        if (!IsPlanted || currentStage < plantData.growthStages.Length - 1) return;

        Debug.Log("Harvested");

        Destroy(currentPlant);
        plantData = null;
        currentStage = -1;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlantManager.Instance.AssginPlot(this);
    }
}
