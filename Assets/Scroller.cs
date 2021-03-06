using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scroller{
	private List<string> states;
	private int stateslength;
	private int stateindex;
	private TextMesh ScrollerText;

	public Scroller(List<string> states, TextMesh ScrollerText){
		this.states = states;
		this.stateslength = states.Count;
		this.stateindex = Random.Range(0,this.stateslength);
		this.ScrollerText = ScrollerText;
		this.ScrollerText.text = this.states [this.stateindex];
	}

	public void incrementState(){
		this.stateindex = (this.stateindex + 1) % this.stateslength;
		this.ScrollerText.text = this.states [this.stateindex];
	}

	public void decrementState(){
		this.stateindex = (this.stateindex + this.stateslength - 1) % this.stateslength;
		this.ScrollerText.text = this.states [this.stateindex];
	}

	public string getState(){
		return this.states[this.stateindex];
	}

}

