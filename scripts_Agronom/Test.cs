using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShovelInput : MonoBehaviour
{
    public ShovelDigging shovel;
    [SerializeField] DigPlants dig;
    public void StartDigging()
    {
        shovel.StartDigging();
    }
    public void StopDigging()
    {
        shovel.StopDigging();
        dig.EndDigging();
    }
}
