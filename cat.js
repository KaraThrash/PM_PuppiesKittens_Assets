#pragma strict

function Start() {

	stateEnum = {
		HOLD:0,
		SETTLE:1,
		UNSETTLE:2
	}

	function Cat() {
		var state = stateEnum.SETTLE;
		this.getHappiness = function() {};
		this.updateHappiness = function() {
			this.tempHappiness = gameObject.GetComponent<zone>().temperature; * tempOpinion;
		};
		this.settle = function() {};
	}
}

function Update() {

}

function OnTriggerEnter( col : collider ) {
	console.log(col.toString);
	/*
	switch ( col.toString ) {
		case "hot":
			updateHot;
			break;
		case "wet":
			updateWet:
	}
	*/
}
