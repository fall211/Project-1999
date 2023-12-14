using Unity.AppUI.UI;
using UnityEngine;
using UnityEngine.UI;

public class SingularityAI : MonoBehaviour
{
    

    // health stuff
    [SerializeField] private Image healthBarFill;
    public float health = 1000f;
    private float maxHealth;

    // state stuff
    public BossState state = BossState.Start;
    public float stateTimer = 0f;
    public float timeUntilHealing = 30f;
    private bool _hasEnteredHealing = false;

    public float healthThresholdToBulletHell = 0.95f;
    private bool _hasEnteredBulletHell = false;
    public float healthThresholdToSwarm = 0.5f;
    private bool _hasEnteredSwarm = false;
    public float healthThresholdToEnd = 0.05f;


    // movement stuff
    public float speed = 5f;
    [SerializeField] private BoxCollider2D movementBounds;
    private Vector2 _targetPos;
    private Vector2 _direction;
    private bool _isMoving = false;
    private bool _canMove = true;

    // attack stuff
    private bool _isAttacking = false;
    public int attackSpeed = 1000;
    private float _attackRadius = 2f;
    public GameObject radialBulletPrefab;
    public GameObject directionalBulletPrefab;


    // swarm stuff
    private int swarmSize = 16;
    private float swarmRadius = 2.5f;
    public GameObject swarmerPrefab;

    // heal stuff
    public GameObject healPylonPrefab;


    void Start() {
        maxHealth = health;
        // play start animation
        // add start dialogue to the queue
    }
    public void Begin(){
        DialogueManager.instance.AddToDialogueQueue(0);
    }

    void Update() {
        if (TopDownManager.Instance.state != TopDownManager.GameState.Playing) return;
        stateTimer += Time.deltaTime;


        // check state transitions
        if (state == BossState.BulletHell || state == BossState.Swarm){
            if (stateTimer >= timeUntilHealing){
                TransitionToState(BossState.Healing);
                stateTimer = 0f;
            }
        }
        if (state == BossState.Start){
            if (health <= healthThresholdToBulletHell * maxHealth){
                TransitionToState(BossState.BulletHell);
                stateTimer = 0f;
            }
        }
        else if (state == BossState.BulletHell){
            if (health <= healthThresholdToSwarm * maxHealth){
                TransitionToState(BossState.Swarm);
                stateTimer = 0f;
            }
        }
        else if (state == BossState.Swarm){
            if (health <= healthThresholdToEnd){
                TransitionToState(BossState.End);
                stateTimer = 0f;
            }
        }

        // state actions
        if (state == BossState.BulletHell){
            MoveBulletHell();
            if (_isAttacking){
                SpawnRadialBullets();
                _isAttacking = false;
            }

        }
        else if (state == BossState.Swarm){
            Move();
            if (!SwarmersAlive()){
                SpawnSwarm();
            }


        }
        else if (state == BossState.Healing){
            if (!PylonsAlive()){
                if (health <= healthThresholdToSwarm * maxHealth){
                    TransitionToState(BossState.Swarm);
                }
                else {
                    TransitionToState(BossState.BulletHell);
                }
            }
        }

    }

    private async void SpawnRadialBullets()
    {
        for (int count = 0; count <= 4; count++)
        {
            AudioManager.instance.AddToAudioQueue(8);
            for (int i = 0; i < 8; i++)
            {
                if (this == null) return;   // if the singularity has been destroyed, don't spawn bullets
                float angle = (i + count * 0.2f) * Mathf.PI * 2 / 8; // Offset angle by count
                Vector2 pos = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * _attackRadius + (Vector2)transform.position;
                Quaternion rot = Quaternion.Euler(0f, 0f, (angle - Mathf.PI / 2) * Mathf.Rad2Deg); // Rotate by -90 degrees
                Instantiate(radialBulletPrefab, pos, rot);
            }
            await System.Threading.Tasks.Task.Delay(attackSpeed);
        }
        _canMove = true;
    }

    private void SpawnPylons(){
        // add pylon spawn dialogue to the queue
        for (int i = 0; i < 4; i++){
            float angle = i * Mathf.PI * 2 / 4;
            Vector2 pos = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * swarmRadius * 3 + (Vector2)transform.position;
            Instantiate(healPylonPrefab, pos, Quaternion.identity);
        }
    }
    private bool PylonsAlive(){
        // check if there are any pylons left
        return GameObject.FindGameObjectsWithTag("Pylon").Length > 0;
    }

    private async void SpawnSwarm(){
        // spawn swarmsize swarmer prefabs in a perfect circle around the singularity
        AudioManager.instance.AddToAudioQueue(7);
        for (int i = 0; i < swarmSize; i++){
            float angle = i * Mathf.PI * 2 / swarmSize;
            Vector2 pos = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * swarmRadius + (Vector2)transform.position;
            Instantiate(swarmerPrefab, pos, Quaternion.identity);
            await System.Threading.Tasks.Task.Delay(250);
        }
    }
    private bool SwarmersAlive(){
        // check if there are any swarmers left
        return GameObject.FindGameObjectsWithTag("Enemy").Length > 0;
    }

    private void MoveBulletHell(){
        if (_canMove) {
            GetNewTargetPos();
        }
        if (_isMoving){
            _canMove = false;
            transform.position += (Vector3)_direction * speed * Time.deltaTime;
            if (Vector2.Distance(transform.position, _targetPos) <= 0.1f){
                _isMoving = false;
                _isAttacking = true;
            }
        }
    }

    private void Move(){
        if (!_isMoving) {
            GetNewTargetPos();
            return;
        }
        transform.position += (Vector3)_direction * speed * Time.deltaTime;
        if (Vector2.Distance(transform.position, _targetPos) <= 0.1f){
            _isMoving = false;
        }
    }
    private void GetNewTargetPos(){
        // Get a new target position within the bounds, and set the direction, and start moving
        Vector2 newTargetPos = new Vector2(
            Random.Range(movementBounds.bounds.min.x, movementBounds.bounds.max.x),
            Random.Range(movementBounds.bounds.min.y, movementBounds.bounds.max.y)
        );
        _targetPos = newTargetPos;
        _direction = (_targetPos - (Vector2)transform.position).normalized;
        _isMoving = true; 
    }

    public void ApplyToHealth(float amount){
        health += amount;
        if (amount < 0) AudioManager.instance.AddToAudioQueue(4);
        UpdateHealthBar();
        if (health > maxHealth) health = maxHealth;
        if (health <= 0) Die();
    }
    private void UpdateHealthBar(){
        healthBarFill.fillAmount = 1 - health / maxHealth;
    }

    private async void Die(){
        // slowly make the singularity smaller until it is gone
        while (transform.localScale.x >= 0.04f){
            transform.localScale -= new Vector3(0.01f, 0.01f, 0f);
            await System.Threading.Tasks.Task.Delay(100);
        }
        while (DialogueManager.instance.typing){
            await System.Threading.Tasks.Task.Delay(100);
        }
        TopDownManager.Instance.EndGame(true);
    }

    private void TransitionToState(BossState newState){
        stateTimer = 0f;
        if (newState == BossState.BulletHell && !_hasEnteredBulletHell){
            // add bullet hell dialogue to the queue
            DialogueManager.instance.AddToDialogueQueue(1);
            DialogueManager.instance.AddToDialogueQueue(2);
            DialogueManager.instance.AddToDialogueQueue(3);
            DialogueManager.instance.AddToDialogueQueue(4);

            _hasEnteredBulletHell = true;
        }
        else if (newState == BossState.Swarm && !_hasEnteredSwarm){
            // add swarm dialogue to the queue
            DialogueManager.instance.AddToDialogueQueue(7);
            DialogueManager.instance.AddToDialogueQueue(8);
            DialogueManager.instance.AddToDialogueQueue(9);

            _hasEnteredSwarm = true;
        }
        else if (newState == BossState.Healing){
            SpawnPylons();
            if (!_hasEnteredHealing){
                // add healing dialogue to the queue
                DialogueManager.instance.AddToDialogueQueue(5);
                DialogueManager.instance.AddToDialogueQueue(6);

                _hasEnteredHealing = true;
            }
            // play healing animation
        }
        else if (newState == BossState.End){
            // add end dialogue to the queue
            DialogueManager.instance.AddToDialogueQueue(10);
            DialogueManager.instance.AddToDialogueQueue(11);
            // play end animation
        }
        if (newState == BossState.Swarm){
            speed = 2.5f;
        } else {
            speed = 5f;
        }

        state = newState;
    }

    public enum BossState{
        Start,
        BulletHell,
        Healing,
        Swarm,
        End
    }
}
