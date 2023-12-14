using UnityEngine;
using UnityEngine.UI;

public class InvisSkillTD : MonoBehaviour
{

    private GameObject player;
    [SerializeField] private Image cooldownBar;
    [SerializeField] private Image skillIcon;
    [SerializeField] private Image tooltip;

    public float duration = 5f;
    public float cooldown = 30f;
    private float cooldownTimer = 0f;
    private bool onCooldown = false;
    private bool isActivated = false;
    private float timer = 0f;


    private void Start(){
        player = GameObject.Find("Player");
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Q)) ActivateSkill();

        if (onCooldown){
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= cooldown){
                onCooldown = false;
                cooldownTimer = 0f;
                skillIcon.color = new Color(skillIcon.color.r, skillIcon.color.g, skillIcon.color.b, 1f);
                tooltip.color = new Color(tooltip.color.r, tooltip.color.g, tooltip.color.b, 1f);
            }
            cooldownBar.fillAmount = cooldownTimer / cooldown;
        }
        if (isActivated){
            timer += Time.deltaTime;
            if (timer >= duration){
                isActivated = false;
                timer = 0f;
                DeactivateSkill();
            }
        }
    }

    public void ActivateSkill(){
        if (!onCooldown && !isActivated){
            onCooldown = true;
            isActivated = true;
            SpriteRenderer sr = player.GetComponentInChildren<SpriteRenderer>();
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
            PlayerTD playerScript = player.GetComponent<PlayerTD>();
            playerScript.detectable = false;
            skillIcon.color = new Color(skillIcon.color.r, skillIcon.color.g, skillIcon.color.b, 0.25f);
            tooltip.color = new Color(tooltip.color.r, tooltip.color.g, tooltip.color.b, 0.25f);
            AudioManager.instance.AddToAudioQueue(0);
        }
    }
    private void DeactivateSkill(){
        SpriteRenderer sr = player.GetComponentInChildren<SpriteRenderer>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        PlayerTD playerScript = player.GetComponent<PlayerTD>();
        playerScript.detectable = true;
        AudioManager.instance.AddToAudioQueue(1);

    }
}
