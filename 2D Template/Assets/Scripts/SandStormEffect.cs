using UnityEngine;

public class SandStormEffect : MonoBehaviour
{
   [SerializeField] ParticleSystem[] sandParticleSystems;

    private float sandSpeed;

    private int sandDirection;
    private SandZone sandZone;

    private bool effectEnabled3;

    [SerializeField] float sandForceMultiplier = 100f;

    [SerializeField] PlayerController playerController3;

    [SerializeField] private Collider2D sandZoneCollider;

    public delegate void SandStormEffectToggler(bool active);

    public static event SandStormEffectToggler OnSandStormEffectToggled;

    public GameObject SandBlur;

    void Awake()
    {
        if (!playerController3) Debug.LogError("SandStormEffect: PlayerController not set.");
        if (!sandZoneCollider) Debug.LogError("SandStormEffect: SandZoneCollider not set.");
        sandZoneCollider.isTrigger = true;
        sandZoneCollider.enabled = false;

        sandZone = sandZoneCollider.gameObject.GetComponent<SandZone>();

        DeactivateSand();
    }

    void OnEnable()
    {
        if (!sandZone) Debug.LogError("SandStormEffect: SandZone scirpt not found on SandZoneObject.");
        else sandZone.OnSandZoneTrigger += ApplySandForceToPlayer;
    }

    void OnDisable()
    {
        if (sandZone) sandZone.OnSandZoneTrigger -= ApplySandForceToPlayer;
    }

    private void ApplySandForceToPlayer(Collider2D collider2D)
    {
        if (collider2D.gameObject == playerController3.gameObject) return; //&&
                                                                          //playerController.GetIsMoving() || playerController.GetIsStopped()) return;

        if (effectEnabled3 && collider2D.TryGetComponent<Rigidbody2D>(out var rb))
        {
            rb.AddForce(new Vector2(sandDirection, sandDirection) * (sandSpeed * sandForceMultiplier), ForceMode2D.Force);
        }
    }

    public void ActivateSand()
    {
        SetSandDirection(GetRandomSandDirection());
        foreach (ParticleSystem ps in sandParticleSystems) if (!ps.isPlaying) ps.Play();
        sandZoneCollider.enabled = true;
        effectEnabled3 = true;
    }

    public void DeactivateSand()
    {
        foreach (ParticleSystem ps in sandParticleSystems) ps.Stop(withChildren: true, stopBehavior: ParticleSystemStopBehavior.StopEmitting);
        sandZoneCollider.enabled = false;
        effectEnabled3 = false;
    }

    public void SetSandDirection(int direction)
    {
        // foreach (ParticleSystem ps in sandParticleSystems)
        // {
        //   ps.transform.rotation = Quaternion.Euler(0, 0, 0);
        // }
    }

    public void SetSandSpeed(float speed)
    {
        if (speed <= .25f)
        {
            sandSpeed = 0f;
            DeactivateSand();
            return;
        }
        else if (!effectEnabled3) ActivateSand();

        sandSpeed = speed;
        foreach (ParticleSystem ps in sandParticleSystems)
        {
            ParticleSystem.MainModule main = ps.main;
            main.simulationSpeed = speed;
        }

        float sandStormEffectResistance = 1 + (PlayerPrefs.GetInt("playerSandStormResistance", 0) * 0.1f);
        if (speed >= sandStormEffectResistance) OnSandStormEffectToggled?.Invoke(true);
        else OnSandStormEffectToggled?.Invoke(false);
    }

    private int GetRandomSandDirection()
    {
        return Random.value < 0.5f ? -1 : 1;
    }

    public float GetSandSpeed()
    {
        return sandSpeed;
    }
}
