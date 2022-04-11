using UnityEngine;
using System.Collections;
using Spine.Unity;

namespace Spine.Unity.Examples {
	public class FootSoldierExample : MonoBehaviour 
	{
		[SpineAnimation("Idle")]
		public string idleAnimation;

		[SpineAnimation]
		public string attackAnimation;

		[SpineAnimation]
		public string moveAnimation;

		[SpineSlot]
		public string eyesSlot;

		[SpineAttachment(currentSkinOnly: true, slotField: "eyesSlot")]
		public string eyesOpenAttachment;

		[SpineAttachment(currentSkinOnly: true, slotField: "eyesSlot")]
		public string blinkAttachment;

		[Range(0, 0.2f)]
		public float blinkDuration = 0.05f;

		public KeyCode attackKey = KeyCode.Mouse0;
		public KeyCode rightKey = KeyCode.D;
		public KeyCode leftKey = KeyCode.A;

		public float moveSpeed = 3;

		SkeletonAnimation skeletonAnimation;

		void Awake () {
			skeletonAnimation = GetComponent<SkeletonAnimation>();
			skeletonAnimation.OnRebuild += Apply;
		}

		void Apply (SkeletonRenderer skeletonRenderer) {
			StartCoroutine(Blink());
		}

		void Update () {
			if (Input.GetKey(attackKey)) {
				skeletonAnimation.AnimationName = attackAnimation;
			} else {
				if (Input.GetKey(rightKey)) {
					skeletonAnimation.AnimationName = moveAnimation;
					skeletonAnimation.Skeleton.ScaleX = 1;
					transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
				} else if(Input.GetKey(leftKey)) {
					skeletonAnimation.AnimationName = moveAnimation;
					skeletonAnimation.Skeleton.ScaleX = -1;
					transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
				} else {
					skeletonAnimation.AnimationName = idleAnimation;
				}
			}
		}

		IEnumerator Blink() {
			while (true) {
				yield return new WaitForSeconds(Random.Range(0.25f, 3f));
				skeletonAnimation.Skeleton.SetAttachment(eyesSlot, blinkAttachment);
				yield return new WaitForSeconds(blinkDuration);
				skeletonAnimation.Skeleton.SetAttachment(eyesSlot, eyesOpenAttachment);
			}
		}
	}
}
