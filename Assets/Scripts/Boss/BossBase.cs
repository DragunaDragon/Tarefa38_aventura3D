using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
using Ebac.StateMachine;
using Animation;


namespace Boss
{

    public enum BossAction
    {
        INIT,
        IDLE,
        WALK,
        ATTACK,
        DEATH
    }


    public class BossBase : MonoBehaviour
{


		[Header("Waypoints")]
		public float minDistance = 1f;
		

		private int _index = 0;


		[Header("Animation")]
		public float startAnimationDuration = .5f;
		public Ease startAnimationEase = Ease.OutBack;


		[Header("Attack")]
		public int attackAmount = 5;
		public float timeBetweenAttacks = .5f;

		public float speed = 5f;
		public List<Transform> waypoints;


		public HealthBase healthBase;

		public Collider _collider;
		public FlashColor flashColor;
		public ParticleSystem _particleSystem;

		[SerializeField] private float _currentLife;
		[SerializeField] private AnimationBase animationBase;
		private StateMachine<BossAction> stateMachine;



		private void OnValidate()
		{
			if (healthBase == null) healthBase = GetComponent<HealthBase>();
		}



		private void Awake()
		{
			Init();
			OnValidate();
			if(healthBase != null)
            {
				healthBase.OnKill += OnBossKill;
			}

			
		}


	

		private void Init()
		{
			stateMachine = new StateMachine<BossAction>();
			stateMachine.Init();


			stateMachine.RegisterStates(BossAction.INIT, new BossStateInit());
			stateMachine.RegisterStates(BossAction.WALK, new BossStateWalk());
			stateMachine.RegisterStates(BossAction.ATTACK, new BossStateAttack());
			stateMachine.RegisterStates(BossAction.DEATH, new BossStateDeath());
		}


	
		
		private void OnBossKill(HealthBase h)
		{
			SwitchState(BossAction.DEATH);
			
		}




		public void OnDamage(float f)
		{
			if (flashColor != null) flashColor.Flash();
			if (_particleSystem != null) _particleSystem.Emit(15);

			transform.position -= transform.forward;

			_currentLife -= f;

			if (_currentLife <= 0)
			{
				Kill();
			}
		}


		protected virtual void Kill()
		{
			OnKill();
		}


		protected virtual void OnKill()
		{
			if (_collider != null) _collider.enabled = false;
			Destroy(gameObject, 3f);
			PlayAnimationByTrigger(AnimationType.DEATH);
		}


		#region ATTACK
		public void StartAttack(Action endCallback = null)
		{
			StartCoroutine(AttackCoroutine(endCallback));
		}


		IEnumerator AttackCoroutine(Action endCallback = null)
		{
			int attacks = 0;
			while (attacks < attackAmount)
			{
				attacks++;
				transform.DOScale(1.1f, .1f).SetLoops(2, LoopType.Yoyo);
				yield return new WaitForSeconds(timeBetweenAttacks);
			

			}

			endCallback?.Invoke();
		}  


		#endregion 



		
		#region WALK

		public void GoToRandomPoint(Action onArrive = null)
		{
			StartCoroutine(GoToPointCoroutine(waypoints[UnityEngine.Random.Range(0, waypoints.Count)], onArrive));
			
			

		}

		IEnumerator GoToPointCoroutine(Transform t, Action onArrive = null)
		{
			while (Vector3.Distance(transform.position, t.position) > 1f)
			{
				transform.position = Vector3.MoveTowards(transform.position, t.position, Time.deltaTime * speed);
				transform.LookAt(waypoints[_index].transform.position);
				yield return new WaitForEndOfFrame();
			}

			onArrive?.Invoke();
		} 
		#endregion  



		#region ANIMATION
		public void StartInitAnimation()
		{
			transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
		}


		private void BornAnimation()
		{
			transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
		}

		public void PlayAnimationByTrigger(AnimationType animationType)
		{
			animationBase.PlayAnimationByTrigger(animationType);
		}


		#endregion





		#region DEBUG

		[NaughtyAttributes.Button]
		private void SwitchInit()
		{
			SwitchState(BossAction.INIT);
		}

		
		[NaughtyAttributes.Button]
		private void SwitchWalk()
		{
			SwitchState(BossAction.WALK);
		}


		[NaughtyAttributes.Button]
		private void SwitchAttack()
		{
			SwitchState(BossAction.ATTACK);
		} 
		#endregion 


		#region STATE MACHINE

		public void SwitchState(BossAction state)
		{

			stateMachine.SwitchState(state, this);
		}

		#endregion







		//damage 

		public void Damage(float damage)
		{
			//Debug.Log("Damage");
			OnDamage(damage);
		}

		public void Damage(float damage, Vector3 dir)
		{
			OnDamage(damage);
			transform.DOMove(transform.position - dir, .1f);

		}

		private void OnCollisionEnter(Collision collision)
		{
			Player p = collision.transform.GetComponent<Player>();
			if (p != null)
			{
				p.healthBase.Damage(1);
			}

		}
	}

	
}