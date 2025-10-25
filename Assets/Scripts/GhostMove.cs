using UnityEngine;

public class GhostMove : MonoBehaviour
{
	public AudioSource source;
	public AudioClip sound;
	public Transform[] waypoints;
	int cur = 0;
	private Vector3 startPos;
	private bool isDead=false;
	private bool isResurgence=false;
	private SpriteRenderer spriteRenderer;

	public float speed = 0.3f;

	void Start()
	{
		source.clip = sound;
		startPos = transform.position;
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void FixedUpdate()
	{
		if (isDead)
		{ 
			Destroy();
			return;
		}
		if (isResurgence)
		{
			Resurgence();
			return;
		}
		// Waypoint not reached yet? then move closer
		if (transform.position != waypoints[cur].position)
		{
			Vector2 p = Vector2.MoveTowards(transform.position,
				waypoints[cur].position,
				speed);
			GetComponent<Rigidbody2D>().MovePosition(p);
		}
		// Waypoint reached, select next one
		else cur = (cur + 1) % waypoints.Length;

		// Animation
		Vector2 dir = waypoints[cur].position - transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator>().SetFloat("DirY", dir.y);
	}

	void OnTriggerEnter2D(Collider2D co)
	{
		if (co.name == "pacman")
		{
			//eat
			int dir = 0;
			if (transform.position.x > co.transform.position.x) dir = 0;
			else if (transform.position.x < co.transform.position.x) dir = 2;
			else if (transform.position.y > co.transform.position.y) dir = 1;
			else if (transform.position.y < co.transform.position.y) dir = 3;
			bool isLastDir = co.GetComponent<PacmanMove>().GetLastDir(dir);
			if (isLastDir)
			{
				isDead = true;
				spriteRenderer.color = new Color(1, 1, 1, 0.3f);
			}
			else
			{
				Destroy(co.gameObject);
				Messenger.Broadcast(GameEvent.PACMAN_HIT);
				source.Play();
			}

		}
	}
	private void Destroy()
	{
		//逐渐回到出生点
		transform.position = Vector2.MoveTowards(transform.position, startPos, speed);
		if (transform.position == startPos)
		{
			isResurgence = true;
			isDead = false;
		}
	}
	private void Resurgence()
	{
		//逐渐恢复透明度
		spriteRenderer.color = new Color(1, 1, 1, Mathf.MoveTowards(spriteRenderer.color.a, 1, 0.01f));
		if (spriteRenderer.color.a == 1)
		{
			isResurgence = false;
		}
	}
}
