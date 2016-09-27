using UnityEngine;
using System.Collections;

namespace KLib {
	/// <summary>
	/// static: Player Key Binding
	/// instance: certain player action
	/// </summary>
	public class KKeyAction {

		#region BINDINGS
		//Basic key references. Later allow panel for change.
		public static KeyCode KEY_NONE = KeyCode.None;
		public static KeyCode KEY_LEFT = KeyCode.LeftArrow;
		public static KeyCode KEY_RIGHT = KeyCode.RightArrow;
		public static KeyCode KEY_UP = KeyCode.UpArrow;
		public static KeyCode KEY_DOWN = KeyCode.DownArrow;
		public static KeyCode KEY_SLOW = KeyCode.LeftShift;
		public static KeyCode KEY_SHOOT = KeyCode.Z;
		public static KeyCode KEY_BOMB = KeyCode.X;
		public static KeyCode KEY_ESC = KeyCode.Escape;

		//Extension Keys just in case
		//Actually, thinking about dealing with a 2ND player with left hand LOL
		public static KeyCode KEY_OTHER_1 = KeyCode.None;
		public static KeyCode KEY_OTHER_2 = KeyCode.None;
		public static KeyCode KEY_OTHER_3 = KeyCode.None;
		public static KeyCode KEY_OTHER_4 = KeyCode.None;
		#endregion

		#region ENUMS
		public enum Keys {
			NONE,
			LEFT,
			RIGHT,
			UP,
			DOWN,
			SLOW,
			SHOOT,
			BOMB,
			ESC,
			OTHER_1,
			OTHER_2,
			OTHER_3
		}

		public enum KeyAction {
			NONE,
			UP,
			DOWN
		}
		#endregion

		#region STATIC
		#endregion
			
		/// <summary>
		/// Considered as a tuple, recording a certain player action;
		/// </summary>
		public KKeyAction(Keys _key, KeyAction _action) {
			key = _key;
			action = _action;
		}
		public Keys key = Keys.NONE;
		public KeyAction action = KeyAction.NONE;
	}
}
