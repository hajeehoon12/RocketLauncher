using UnityEngine;
using UnityEngine.UI;

public class EnergyDashboardC : MonoBehaviour
{
    [SerializeField] private EnergySystemC energySystem;
    [SerializeField] private RocketControllerC rocketControllerC;
    [SerializeField] private Image fillBar;
    [SerializeField] private float fuelConsumeSpeed;

    private void Start()
    {
        // 에너지시스템의 에너지 사용에 대해 fillBar가 변경되도록 수정
        energySystem.OnEnergyChanged += FillUpdate;
    }

    void FillUpdate(float fuel)
    {
        fillBar.fillAmount = energySystem.Fuel/ energySystem.MaxFuel; 
    }


}