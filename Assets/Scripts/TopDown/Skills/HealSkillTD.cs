using UnityEngine.UI;
using UnityEngine;

public class HealSkillTD : MonoBehaviour
{
    private PlayerTD playerScript;

    [SerializeField] private Image cooldownBar;
    [SerializeField] private Image skillIcon;
    [SerializeField] private Image tooltip;
    public float cooldown = 60f;
    private float cooldownTimer = 0f;
    private bool onCooldown = false;


    private void Start(){
        playerScript = GameObject.Find("Player").GetComponent<PlayerTD>();
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.E)) ActivateSkill();
        
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
    }

    public void ActivateSkill(){
        if (!onCooldown){
            onCooldown = true;
            playerScript.ApplyToHealth(1);
            skillIcon.color = new Color(skillIcon.color.r, skillIcon.color.g, skillIcon.color.b, 0.25f);
            tooltip.color = new Color(tooltip.color.r, tooltip.color.g, tooltip.color.b, 0.25f);
            AudioManager.instance.AddToAudioQueue(2);
        }
    }

}
