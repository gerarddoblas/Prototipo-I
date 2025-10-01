using System.Timers;
using TMPro;
using UnityEngine;

public class Plot : MonoBehaviour
{
    public PlantData plantData;
    private int currentStage;
    private float growthTimer;
    private GameObject currentPlant;
    float elapsed;

    public bool IsPlanted => plantData != null;
    public bool HasWater;
    public bool isFertilized;
    public float MultiplyerSpeed;

    public TextMeshProUGUI statusText;

    public void Plant(PlantData newPlant)
    {
        if (IsPlanted)
        {
            Debug.Log("Hey! I'm already a plant");
            return;
        }

        plantData = newPlant;
        currentStage = -1;
        growthTimer = Time.time;
        HasWater = true;
        isFertilized = false;

        Debug.Log("Calling Growth");
        NextGrowth();
    }

    public void CheckGrowth()
    {
        if (!IsPlanted || !HasWater)
        {
            Debug.Log("Hey! I'm don't exist yipiiie");
            return;
        }
        
        if(isFertilized)
        {
            MultiplyerSpeed = 2f;
        }else
        {
            MultiplyerSpeed = 1f;
        }
        
        elapsed = (Time.time - growthTimer) * MultiplyerSpeed;

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

    public void UpdateUI()
    {
        if(statusText == null)
        {
            return;
        }

        if(!IsPlanted)
        {
            statusText.text = "Anything :<";
            return;
        }

        statusText.text = $"{plantData.plantName}\n" + 
                          $"Tiempo: {elapsed:F1}s\n";
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        PlantManager.Instance.AssignPlot(this);
    }
    
}
