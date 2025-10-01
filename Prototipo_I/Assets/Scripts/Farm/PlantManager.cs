using UnityEngine;
using System.Collections.Generic;

public class PlantManager : MonoBehaviour
{
    
    public static PlantManager Instance;
    private List<Plot> plots = new List<Plot>();
    private Plant plant;

    private void Awake()
    {
        Instance = this;
    }

    public void AssignPlot(Plot plot)
    {
        if(!plots.Contains(plot))
        {
            plots.Add(plot);
        }
    }

    private void Update()
    {
        foreach (var plot in plots)
        {
            //plant.Grow();
            plot.UpdateUI();
        }
    }
}
