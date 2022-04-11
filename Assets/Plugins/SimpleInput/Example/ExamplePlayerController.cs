using UnityEngine;

public class ExamplePlayerController : MonoBehaviour
{
	public Color materialColor;
	private Rigidbody2D m_rigidbody;

	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";
	public string jumpButton = "Jump";

	private float inputHorizontal;
	private float inputVertical;

	void Awake()
	{
		m_rigidbody = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		inputHorizontal = SimpleInput.GetAxis( horizontalAxis );
		inputVertical = SimpleInput.GetAxis( verticalAxis );

		transform.Rotate( 0f, inputHorizontal * 5f, 0f, Space.World );

		//if( SimpleInput.GetButtonDown( jumpButton ) && IsGrounded() )
		//	m_rigidbody.AddForce( 10f, ForceMode2D.Impulse);
	}

	void FixedUpdate()
	{
		m_rigidbody.AddRelativeForce( new Vector2( 0f, 0f ) * 20f );
	}

	void OnCollisionEnter( Collision collision )
	{
		if( collision.gameObject.CompareTag( "Player" ) )
			m_rigidbody.AddForce( collision.contacts[0].normal * 10f, ForceMode2D.Impulse );
	}

	bool IsGrounded()
	{
		return Physics.Raycast( transform.position, Vector3.down, 1.75f );
	}
}