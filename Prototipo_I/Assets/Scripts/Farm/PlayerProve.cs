using UnityEngine;

public class PlayerProve : MonoBehaviour
{
    public Plot plot;
    public Plant plant;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plot.Plant(plant);
    }

    // Update is called once per frame
    void Update()
    {
        //plot.CheckGrowth();
    }
}
