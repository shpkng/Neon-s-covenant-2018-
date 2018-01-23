using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{

	//定义敌人的Transform
	Transform m_transform;
	//CharacterController m_ch;

	//定义动画组件
	Animator m_animator;

	//定义寻路组件
	UnityEngine.AI.NavMeshAgent m_agent;

	//定义一个主角类的对象
	ThirdPersonUserControl m_player;
	//角色移动速度
	float m_moveSpeed = 0.5f;
	//角色旋转速度
	float m_rotSpeed = 120;


	//定义计时器 
	float m_timer = 2;

	//定义追逐状态
	bool isChasing = false;

	//敌人的生命值
	public int EnemyHp { set; get; }


	public float attackRange = 1;


	// Use this for initialization
	void Start()
	{
		//初始化m_transform 为物体本身的tranform
		m_transform = this.transform;

		//初始化动画m_ani 为物体的动画组件
		m_animator = this.GetComponent<Animator>();

		//初始化寻路组件m_agent 为物体的寻路组件
		m_agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

		//初始化主角
		m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonUserControl>();


	}

	// Update is called once per frame
	void Update()
	{

		if (EnemyHp == 0)
		{
			Die();
		}

		//判断是否进入攻击范围，若是，则停止移动，进行攻击
		if(Vector3.Distance(m_player.transform.position,this.transform.position)<=attackRange)
		{
			//isChasing = false;
			Attack();
		}

		//判断是否处于追击状态
		if (isChasing)
		{
			//设置敌人的寻路目标
			m_agent.SetDestination(m_player.transform.position);
		}

		//Debug用的键盘按键，在追逐时按下R可以停止追击
		if(Input.GetKeyDown(KeyCode.R))
		{
			isChasing = false;
		}

	}

	////敌人的自动寻路函数
	//void MoveTo()
	//{

	//	//定义敌人的移动量
	//	float speed = m_moveSpeed * Time.deltaTime;

	//	//通过寻路组件的Move()方法实现寻路移动
	//	m_agent.Move(m_transform.TransformDirection(new Vector3(0, 0, speed)));
	//}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("Player sensored");
			isChasing = true;

		}
	}

	private void Attack()
	{

	}

	private void Die()
	{

	}

	private void GetHurt()
	{

	}

}