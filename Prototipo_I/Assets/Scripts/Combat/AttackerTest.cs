using UnityEngine;

public class AttackerTest : MonoBehaviour, IAttacker
{
    [SerializeField] private int strength;
    [SerializeField] private GameObject go;
    public int Damage => strength;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            (this as IAttacker).Attack(go);
        }
    }
}
