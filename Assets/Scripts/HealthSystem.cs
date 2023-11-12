using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.PostProcessing;

public class HealthSystem : MonoBehaviour
{

    public int playerHealth;
    public int damage;
    public CinemachineVirtualCamera vCam;
    private PostProcessVolume volume;
    public Vignette vignette;

    float timeElapsed;
    float lerpDuration = 0.5f;
    float startValue = 0;
    float endValue = 0.5f;
    float valueToLerp;
    float damageTimer = 0;
    bool canBeHit = true;
    bool wasHit = false;
    float lerpVignetteAmount;

    private bool vignetteMove = false;

    private float curVigIntensity = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;

        volume = vCam.GetComponent<PostProcessVolume>();

        volume.profile.TryGetSettings(out vignette);
    }

    // Update is called once per frame
    void Update()
    {
        vignette.active = true;
        lerpVignetteAmount = vignette.intensity.value;

        if (vignetteMove == true)
        {
            if (timeElapsed <= lerpDuration)
            {
                Debug.Log("Current Health: " + playerHealth);

                //Debug.Log("Max " + max);
                vignette.intensity.value = Mathf.Lerp(curVigIntensity, ((100.0f - playerHealth) / 100.0f) / 2.0f, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
            }
            else
            {
                Debug.Log("V INTENSITY: " + vignette.intensity.value);
                vignetteMove = false;
                timeElapsed = 0;
            }
        }

        if (wasHit == true)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= 3f)
            {
                wasHit = false;
                canBeHit = true;
                damageTimer = 0;
            }
        }
    }

    void TakeDamage(int damage)
    {
        playerHealth -= damage;
        vignetteMove = true;
        if (playerHealth <= 0)
        {
            Debug.Log("Player is dead :(");
        }


    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BoxEnemy" && canBeHit == true)
        {
            TakeDamage(25);
            wasHit = true;
            canBeHit = false;

            curVigIntensity = vignette.intensity.value;
        }

    }
}
