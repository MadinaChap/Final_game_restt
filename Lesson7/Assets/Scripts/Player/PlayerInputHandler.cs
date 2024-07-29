using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BHSCamp
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private float _horizontal;
        private IMove _movable;
        private CharacterSound _sound;
        private IJump _jump;
        private AttackBase _attack;
        private Health _health;
        private PlayerAnimation _animation;
        private Ground _ground;
        private bool _isDead;

        [SerializeField] private Button pauseButton;

        private void OnEnable()
        {
            _health.OnDeath += HandleDeath;
        }

        private void OnDisable()
        {
            _health.OnDeath -= HandleDeath;
        }

        private void Awake()
        {
            _movable = GetComponent<IMove>();
            _jump = GetComponent<IJump>();
            _animation = GetComponent<PlayerAnimation>();
            _attack = GetComponent<AttackBase>();
            _ground = GetComponent<Ground>();
            _health = GetComponent<Health>();
            _sound = GetComponent<CharacterSound>();
        }

        private void Update()
        {
            if (_isDead) return;

            _horizontal = Input.GetAxisRaw("Horizontal");

            _horizontal = _attack.IsAttacking && _ground.OnGround? 0 : _horizontal;
            _movable.SetVelocity(new Vector2(_horizontal, 0), _speed);
            _animation.SetInputX(_horizontal);
            _sound.SetInputX(_horizontal);

            if (Input.GetButtonDown("Attack"))
                _attack.BeginAttack();

            if (Input.GetButtonDown("Jump"))
                _jump.Action();
        }

        private void HandleDeath()
        {
            _isDead = true;
            _movable.SetVelocity(Vector2.zero, 0);
            _sound.StopWalkingSound();
            _sound.SetInputX(0);
            StartCoroutine(WaitAndPauseGame());
        }

        private IEnumerator WaitAndPauseGame()
        {
            yield return new WaitForSeconds(1f);
            PauseGame();
        }

        private void PauseGame(){
            if(pauseButton != null){
                pauseButton.onClick.Invoke();
            }
        }
        
    }
}