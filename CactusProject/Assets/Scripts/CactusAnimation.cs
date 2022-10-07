using System;
using UnityEngine;
using static ARTapToPlaceObject;

public class CactusAnimation : MonoBehaviour
{
   private Animator animator;
	
	private String triggerName;

   void Start()
   {
       animator = GetComponent<Animator>();
		 triggerName = "Idle";
   }

   void Update()
   {
		if(animator != null){
			
			if(String.Equals(triggerName, "Idle")){
       		foreach(GameObject cactus in ARTapToPlaceObject.spawnedObjects)
       		{
			  		float distance = Vector3.Distance(cactus.transform.position, transform.position);
			  
           		if (distance <= 0.25 && distance > 0)
           		{
           		    triggerName = "Attack";
           		}
       		}
			}
			
			 if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && String.Equals(triggerName, "Attack"))
				 animator.SetTrigger("Attack");
			 else if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
				 animator.SetTrigger(triggerName);
   	}
		
	}
}
