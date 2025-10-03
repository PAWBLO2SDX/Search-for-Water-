using System.Collections;
using UnityEngine;

public class WeatherEffects : MonoBehaviour
{
    private WeatherEffectParameters currentWeatherEffectParameters;
    private WeatherEffectParameters targetWeatherEffectParameters;

    [SerializeField] WeatherEffectsParameters sunnyWeatherParameters;
    [SerializeField] WeatherEffectsParameters heatWaveWeatherParameters;
    [SerializeField] WeatherEffectsParameters cloudyWeatherParameters;
    [SerializeField] WeatherEffectsParameters windyWeatherParameters;
    [SerializeField] WeatherEffectsParameters sandStormWeatherParameters;

    [SerializeField] SunnyEffects sunnyEffects;
    [SerializeField] HeatWaveEffects heatWaveEffects;
    [SerializeField] CloudEffects cloudEffects;
    [SerializeField] WindEffects windEffects;
    [SerializeField] SandStormEffects sandStormEffects;


    void Awake()
    {
        currentWeatherEffectParameters = sunnyWeatherParameters;
        targetWeatherEffectParameters = new WeatherEffectParameters();
    }

    void Start()
    {
        SetWeatherEffect(WeaterState.State.Sunny);
    }

    public void SetWeatherEffect(WeatherState.State weatherState)
    {
        switch (weatherState)
        {
            case WeatherState.State.Sunny:
                targetWeatherEffectParameters = sunnyWeatherParameters;
                break;
            case WeatherState.State.HeatWave:
                targetWeatherEffectParameters = heatWaveWeatherParameters;
                break;
            case WeatherState.State.Cloudy:
                targetWeatherEffectParameters = cloudyWeatherParameters;
                break;
            case WeatherState.State.Windy:
                targetWeatherEffectParameters = windyWeatherParameters;
                break;
            case WeatherState.State.SandStorm:
                targetWeatherEffectParameters = sandStormWeatherParameters;
                break;
        }
        StartCorutine(TransitionToNextEffect());
    }

    private IEnumerator TransitionToNextEffect()
    {
        float transitionTime = 3f;
        float elapsedTime = 0;

        WeatherEffectParameters startWeatherEffectParameters = currentWeatherEffectParameters;

        while (elapsedTime < transitionTime)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / transitionTime);

            currentWeatherEffectParameters = LerpWeatherEffectParameters(startWeatherEffectParameters, targetWeatherEffectParameters, t);
            UpdateWeatherEffects(currentWeatherEffectParameters);
        }
        currentWeatherEffectParameters = targetWeatherEffectParameters;
        UpdateWeatherEffects(currentWeatherEffectParameters);
    }
}
