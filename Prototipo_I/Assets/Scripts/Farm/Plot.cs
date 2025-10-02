using System.Timers;
using TMPro;
using UnityEngine;

public class Plot : MonoBehaviour
{
    private Plant plant;

    public bool IsPlanted => plant != null;

    [SerializeField] private bool hasWater;
   // public bool HasWater => hasWater;
    private bool isFertilized;
    private float MultiplierSpeed;

    [SerializeField] private TextMeshProUGUI statusText;

    public void Plant(Plant plant)
    {
        if (IsPlanted)
        {
            Debug.Log("Hey! I'm already a plant");
            return;
        }

        this.plant = plant;
        hasWater = true;
        isFertilized = false;

        Debug.Log("Calling Growth");
        this.plant.Create();
    }

    public void Harvest()
    {
        if (!IsPlanted || !this.plant.IsGrown)
        {
            Debug.Log("Not today");
            return;
        }

        Debug.Log("Yw. Harvested");
        //Spawn drop and stuff
        this.plant = null;
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
        
        statusText.text = $"{plant.Name}\n" + 
                          $"Tiempo: {plant.currentTime:F1}s\n";
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Plant Bulbasaur = new Plant("Bulbasaur", 3, 25f);
        Plant(Bulbasaur);
        PlantManager.Instance.AssignPlot(this);
    }
    
}
