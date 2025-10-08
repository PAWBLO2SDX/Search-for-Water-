using UnityEngine;

public class CloudEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem[] cloudParticleSystems;

    private float cloudSpeed;

    private int cloudDirection;
    private CloudZone cloudZone;

    private bool effectEnabled2;

    [SerializeField] float cloudForceMultiplier = 100f;

    [SerializeField] PlayerController playerController2;

    [SerializeField] private Collider2D cloudZoneCollider;

    public delegate void CloudEffectToggler(bool active);

    public static event CloudEffectToggler OnCloudEffectToggled;

    void Awake()
    {
        if (!playerController2) Debug.LogError("CloudEffect: PlayerController not set.");
        if (!cloudZoneCollider) Debug.LogError("CloudEffect: CloudZoneCollider not set.");
        cloudZoneCollider.isTrigger = true;
        cloudZoneCollider.enabled = false;

        cloudZone = cloudZoneCollider.gameObject.GetComponent<CloudZone>();

        DeactivateClouds();
    }

    void OnEnable()
    {
        if (!cloudZone) Debug.LogError("CloudEffect: CloudZone scirpt not found on CloudZoneObject.");
        else cloudZone.OnCloudZoneTrigger += ApplyCloudForceToPlayer;
    }

    void OnDisable()
    {
        if (cloudZone) cloudZone.OnCloudZoneTrigger -= ApplyCloudForceToPlayer;
    }

    private void ApplyCloudForceToPlayer(Collider2D collider2D)
    {
        if (collider2D.gameObject == playerController2.gameObject) return; //&&
                                                                          //playerController.GetIsMoving() || playerController.GetIsStopped()) return;

        if (effectEnabled2 && collider2D.TryGetComponent<Rigidbody2D>(out var rb))
        {
            rb.AddForce(new Vector2(cloudDirection, cloudDirection) * (cloudSpeed * cloudForceMultiplier), ForceMode2D.Force);
        }
    }

    public void ActivateClouds()
    {
        SetCloudDirection(GetRandomCloudDirection());
        foreach (ParticleSystem ps in cloudParticleSystems) if (!ps.isPlaying) ps.Play();
        cloudZoneCollider.enabled = true;
        effectEnabled2 = true;
    }

    public void DeactivateClouds()
    {
        foreach (ParticleSystem ps in cloudParticleSystems) ps.Stop(withChildren: true, stopBehavior: ParticleSystemStopBehavior.StopEmitting);
        cloudZoneCollider.enabled = false;
        effectEnabled2 = false;
    }

    public void SetCloudDirection(int direction)
    {
        // foreach (ParticleSystem ps in cloudParticleSystems)
        // {
        //   ps.transform.rotation = Quaternion.Euler(0, 0, 0);
        // }
    }

    public void SetCloudSpeed(float speed)
    {
        if (speed <= .25f)
        {
            cloudSpeed = 0f;
            DeactivateClouds();
            return;
        }
        else if (!effectEnabled2) ActivateClouds();

        cloudSpeed = speed;
        foreach (ParticleSystem ps in cloudParticleSystems)
        {
            ParticleSystem.MainModule main = ps.main;
            main.simulationSpeed = speed;
        }

        float cloudEffectResistance = 1 + (PlayerPrefs.GetInt("playerWindResistance", 0) * 0.1f);
        if (speed >= cloudEffectResistance) OnCloudEffectToggled?.Invoke(true);
        else OnCloudEffectToggled?.Invoke(false);
    }

    private int GetRandomCloudDirection()
    {
        return Random.value < 0.5f ? -1 : 1;
    }

    public float GetCloudSpeed()
    {
        return cloudSpeed;
    }
}
