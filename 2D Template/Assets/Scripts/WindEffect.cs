using UnityEngine;

public class WindEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem[] windParticleSystems;

    private int windDirection;
    private float windSpeed;

    [SerializeField] float windForceMultiplier = 100f;

    [SerializeField] private Collider2D windZoneCollider;

    private WindZone windZone;

    private bool effectEnabled;

    [SerializeField] PlayerController playerController;

    public delegate void WindEffectToggler(bool active);

    public static event WindEffectToggler OnWindEffectToggled;

    void Awake()
    {
        if (!playerController) Debug.LogError("WindEffect: PlayerController not set.");
        if (!windZoneCollider) Debug.LogError("WindEffect: WindZoneCollider not set.");
        windZoneCollider.isTrigger = true;
        windZoneCollider.enabled = false;

        windZone = windZoneCollider.gameObject.GetComponent<WindZone>();

        DeactivateWind();
    }

    void OnEnable()
    {
        if (!windZone) Debug.LogError("WindEffect: WindZone scirpt not found on WindZoneObject.");
        else windZone.OnWindZoneTrigger += ApplyWindForceToPlayer;
    }

    void OnDisable()
    {
        if (windZone) windZone.OnWindZoneTrigger -= ApplyWindForceToPlayer;
    }

    private void ApplyWindForceToPlayer(Collider2D collider2D)
    {
        if (collider2D.gameObject == playerController.gameObject) return; //&&
        //playerController.GetIsMoving() || playerController.GetIsStopped()) return;
        
        if (effectEnabled && collider2D.TryGetComponent<Rigidbody2D>(out var rb))
        {
            rb.AddForce(new Vector2(windDirection, windDirection) * (windSpeed * windForceMultiplier), ForceMode2D.Force);
        }
    }

    public void ActivateWind()
    {
        SetWindDirection(GetRandomWindDirection());
        foreach (ParticleSystem ps in windParticleSystems) if (!ps.isPlaying) ps.Play();
        windZoneCollider.enabled = true;
        effectEnabled = true;
    }

    public void DeactivateWind()
    {
        foreach (ParticleSystem ps in windParticleSystems) ps.Stop(withChildren: true, stopBehavior: ParticleSystemStopBehavior.StopEmitting);
        windZoneCollider.enabled = false;
        effectEnabled = false;
    }

    public void SetWindDirection(int direction)
    {
       // foreach (ParticleSystem ps in windParticleSystems)
       // {
         //   ps.transform.rotation = Quaternion.Euler(0, 0, 0);
       // }
    }

    public void SetWindSpeed(float speed)
    {
        if (speed <= .25f)
        {
            windSpeed = 0f;
            DeactivateWind();
            return;
        }
        else if (!effectEnabled) ActivateWind();

        windSpeed = speed;
        foreach (ParticleSystem ps in windParticleSystems)
        {
            ParticleSystem.MainModule main = ps.main;
            main.simulationSpeed = speed;
        }

        float windEffectResistance = 1 + (PlayerPrefs.GetInt("playerWindResistance", 0) * 0.1f);
        if (speed >= windEffectResistance) OnWindEffectToggled?.Invoke(true);
        else OnWindEffectToggled?.Invoke(false);
    }

    private int GetRandomWindDirection()
    {
        return Random.value < 0.5f ? -1 : 1;
    }

    public float GetWindSpeed()
    {
        return windSpeed;
    }
}
