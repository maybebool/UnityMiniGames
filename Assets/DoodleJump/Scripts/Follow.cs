using UnityEngine;


namespace DoodleJump.Scripts {
	public class Follow : MonoBehaviour
	{
		public Transform target;
		public Transform self;
		private Vector3 _tempVec3;

		void LateUpdate()
		{
			if (target != null)
			{
				_tempVec3.x = target.position.x;
				_tempVec3.y = target.position.y; 
				_tempVec3.z = this.transform.position.z;
				// tempVec3.z = Target.position.y; // For 3D
				this.transform.position = _tempVec3;
			}
			
			else if (target == null)
			{
				_tempVec3.x = self.position.x;
				_tempVec3.y = self.transform.position.y;
				_tempVec3.z = self.transform.position.z;
				self.transform.position = _tempVec3;
			}
		}
	}
}
