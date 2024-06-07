using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HealthSystem : MonoBehaviour
{

    public float playerHealth;
    public int damage;
    
    [SerializeField] public Volume volume;
    [SerializeField] public Vignette vignette;
    
    public float timeElapsed;
    public float lerpDuration = 0.5f;
    public float startValue = 0; 
    public float endValue = 0.5f;
    public float valueToLerp;
    public float damageTimer = 0;
    public bool canBeHit = true;
    public bool wasHit = false;
    public float lerpVignetteAmount;
 
    public bool vignetteMove = false;

    public float curVigIntensity = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;

        volume.profile.TryGet(out Vignette vignette);
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

        if (playerHealth <= 0)
        {
            Debug.Log("Player is dead :(");
            Destroy(gameObject);
        }
    }
}
