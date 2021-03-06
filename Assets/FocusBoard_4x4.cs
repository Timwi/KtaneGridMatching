using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusBoard_4x4{

	private int boardstate4x4;
	private int sector_x;
	private int sector_y;

	public FocusBoard_4x4(int boardstate4x4, int sector_x, int sector_y){
		this.boardstate4x4 = boardstate4x4;
		this.sector_x = sector_x;
		this.sector_y = sector_y;
	}
		
	public long translateToBoardState6x6(){
		int xshift = this.sector_x;
		int yshift = this.sector_y;
		long state6x6=
			(
				((((long) this.boardstate4x4 >>  0) & 0xFL) << (6 * yshift + xshift +  0)) |
				((((long) this.boardstate4x4 >>  4) & 0xFL) << (6 * yshift + xshift +  6)) |
				((((long) this.boardstate4x4 >>  8) & 0xFL) << (6 * yshift + xshift + 12)) |
				((((long) this.boardstate4x4 >> 12) & 0xFL) << (6 * yshift + xshift + 18)) 
			);
		return state6x6;
	}

	public void rotateClockwise(){
		int newstate = 0;
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				int cellval = this.boardstate4x4 & ((1 << i) << (j * 4));
				if (cellval > 0) {
					newstate |= (1 << (3 - j)) << (4 * i);
				}
			}
		}
		this.boardstate4x4 = newstate;
	}
	public void rotateCounterClockwise(){
		this.rotateClockwise ();
		this.rotateClockwise ();
		this.rotateClockwise ();
	}
		
	public int getBoard4x4State(){
		return this.boardstate4x4;
	}

	public void setSectorX(int sector_x){
		this.sector_x = sector_x;
	}

	public void setSectorY(int sector_y){
		this.sector_y = sector_y;
	}

	public int getSectorX(){
		return this.sector_x;
	}

	public int getSectorY(){
		return this.sector_y;
	}
}