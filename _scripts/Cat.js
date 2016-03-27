#pragma strict

// i should find a unityscript linter

public class Cat
{

	public var happiness : int;
	public var envScore : int;
	public var likes : Object;

	public function Cat( h : int, e : int, l : Object ) {
		happiness = h; // 0 to 100
		envScore  = e; // 0 to 100, rate of change of happiness
		likes     = l;
	}

	public function getEnvScore() {
		return envScore;
	}

	public function setEnvScore( addend : int ) {
		var tmpEnvScore : int;
		tmpEnvScore = getEnvScore() + addend;
		if (tmpEnvScore > 100) tmpEnvScore = 100;
		if (tmpEnvScore < 0) tmpEnvScore = 0;
		envScore = tmpEnvScore;
	}

	public function getHappiness() {
		return happiness;
	};

	public function setHappiness( addend : int ) {
		var tmpHappiness : int;
		tmpHappiness = happiness + addend;
		if (tmpHappiness > 100) tmpHappiness = 100;
		if (tmpHappiness < 0) tmpHappiness = 0;
		happiness = tmpHappiness;
	};

	// State update functions
	public function settle() {};
	public function unsettle() {};
	public function hold() {};
}

var cat : Cat;
cat = new Cat( 50, 50, {
	"hot" : 0.8,
	"wet" : -1
});

function Start() {}
function Update() {}

function OnTriggerEnter( col : Collider ) {
	var zone : Zone;
	var heat : int;
	heat = col.gameObject.GetComponent.<Zone>().hot;
	// score the mood of the cat
	var score : int = cat.getEnvScore();
	//score += heat * cat.likes['hot'];
	cat.settle();
}
