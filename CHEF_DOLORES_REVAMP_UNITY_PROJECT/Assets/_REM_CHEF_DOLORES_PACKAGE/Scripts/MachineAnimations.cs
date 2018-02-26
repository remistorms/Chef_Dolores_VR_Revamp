using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineAnimations : MonoBehaviour {

	public Animator machineAnimator;

	public void OpenLid(){
		machineAnimator.SetBool ("isLidOpen", true);
	}

	public void CloseLid(){
		machineAnimator.SetBool ("isLidOpen", false);
	}

	public void ShakeMachine(){
		machineAnimator.SetTrigger ("turnOnMachine");
	}

	public void DeliverPlate(){
		machineAnimator.SetTrigger ("finishedFood");
	}

	public void ResetMachineAnimations(){
		machineAnimator.SetTrigger ("resetMachine");
	}
}
