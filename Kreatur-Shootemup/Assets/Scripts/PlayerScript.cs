using UnityEngine;
using System.Collections;

/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour
{
	/// <summary>
	/// 1 - The speed of the cat unicorn
	/// </summary>
	public Vector2 speed = new Vector2(50, 50);
	/*
		it as a public variable allows you to modify it in Unity through 
		the "Inspector" pane, even during the game execution. 
		This is a powerful feature of Unity, letting you tweaks the 
		gameplay without coding. Remember that we are doing scripting here,
		not classic C# programming. This implies to break some rules and 
		conventions.
		#Sorry Mr.Guidet.
	 */

	
	// 2 - Store the movement
	private Vector2 movement;
	
	void Update()
	{
		// 3 - Retrieve axis information
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		
		// 4 - Movement per direction
		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);
			
		// 5 - Shooting
		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");
		// Careful: For Mac users, ctrl + arrow is a bad idea
		
		if (shoot)
		{
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
			{
				// false because the player is not an enemy
				weapon.Attack(false);
			}
		}
	}
	
	void FixedUpdate()
	{
		// 5 - Move the game object
		rigidbody2D.velocity = movement;
	}
}
