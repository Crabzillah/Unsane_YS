using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

		bool canLook;
		bool canMove;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			if (Inventory.instance.inventoryActive == true)
			{
				MoveInput(Vector2.zero);


			}
			else if (PauseMenu.isPaused == true)
			{
				MoveInput(Vector2.zero);
			}
			else
			{
				
				MoveInput(value.Get<Vector2>());
				
				
			}
			
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				if (Inventory.instance.inventoryActive == true)
				{

					LookInput(Vector2.zero);

				}

				else if (PauseMenu.isPaused == true)
				{
					LookInput(Vector2.zero);
				}
				else
				{
					
					LookInput(value.Get<Vector2>());
					
					
				}
				
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection; 
			
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}
		
		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}