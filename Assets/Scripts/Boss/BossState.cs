using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;



namespace Boss
{

    public class BossState: StateBase

	{

		protected BossBase boss;
		
		
		public override void OnStateEnter(params object[] objs)
		{
			base.OnStateEnter(objs);
			boss = (BossBase)objs[0];
			//boss.StartAnimation();
		}

		
	}


	public class BossStateInit : BossState
    {
		public override void OnStateEnter(params object[] objs)
		{
			base.OnStateEnter(objs);
			boss.StartInitAnimation();
			
		}


	}



	public class BossStateWalk : BossState
	{
		
		public override void OnStateEnter(params object[] objs)
		{
			base.OnStateEnter(objs);
			boss.GoToRandomPoint(OnArrive);
		}

		private void OnArrive()
		{
			boss.SwitchState(BossAction.ATTACK);
		}



		public override void OnStateExit()
		{
			base.OnStateExit();
			Debug.Log("Exit Walk");
			boss.StopAllCoroutines();
		}
		
	}


	public class BossStateAttack : BossState
	{
		
		public override void OnStateEnter(params object[] objs)
		{
			base.OnStateEnter(objs);
			boss.StartAttack(EndAttacks);
		}

		
		private void EndAttacks()
		{
			boss.SwitchState(BossAction.WALK);
		}



		public override void OnStateExit()
		{
			Debug.Log("Exit Attack");
			base.OnStateExit();
			boss.StopAllCoroutines();
		}



	}



	public class BossStateDeath : BossState
	{
		
		public override void OnStateEnter(params object[] objs)
		{
			base.OnStateEnter(objs);
			Debug.Log("Enter Death");
			boss.transform.localScale = Vector3.one * .2f;
		}
		

	}


}


