using System;
using UnityEngine;

[Serializable]
public class WeatherEffectParameters
{
    public Color cloudColor;
    [Range(0, 1000)] public float cloudEmissionRate;
    [Range(0, 1000)] public float sandSpeed;
    [Range(0, 1000)] public float windSpeed;
    [Range(0, 1000)] public float cloudSpeed;
    public GameObject HeatBlur;
    public GameObject Sun;
    public GameObject SandBlur;
    public bool heatWaveActive;
    public bool sunRaysActive;
    public bool sandBlurActive;
}
