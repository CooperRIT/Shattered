using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerSettings : MonoBehaviour
{
    //Sensitivity
    [SerializeField] Slider sensitivitySlider;
    [SerializeField] TextMeshProUGUI sensitvityTextValue;
    [SerializeField] FloatEventChannel sensitvityEventChannel;

    [SerializeField] TextMeshProUGUI waveCounter;
    float waveCount = 1;

    float storeSens;

    private void Start()
    {
        sensitivitySlider.value = GameManager.instance.StartingPlayerSens;
        UpdateSensitivty();
    }

    /// <summary>
    /// Used to update player sens
    /// </summary>
    public void UpdateSensitivty()
    {
        sensitvityEventChannel.CallEvent(new(sensitivitySlider.value));
        int value = (int)sensitivitySlider.value;
        sensitvityTextValue.text = value.ToString();
    }

    public void ZeroSens()
    {
        storeSens = sensitivitySlider.value;
        sensitivitySlider.value = 0;
        UpdateSensitivty();
    }

    public void ReappleSens()
    {
        sensitivitySlider.value = storeSens;
        UpdateSensitivty();
    }

    public void UpdateWaveCounter(VoidEvent ctx)
    {
        waveCount++;
        waveCount -= .5f;
        waveCounter.text = $"Wave: {Mathf.Floor(waveCount)}";
    }

}
