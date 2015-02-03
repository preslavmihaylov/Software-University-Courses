package main;

public class Ammunition {

	int clip;
	int reloadDelay = 0;
	private static final int CLIP_SIZE = 40;
	boolean reloading = false;
	
	public Ammunition() {
		
		// the initial ammo is 50. It cannot get beyond this.
		clip = CLIP_SIZE;
	}
	
	public void tick() {
		// while we are reloading, we cannot shoot.
		if (reloadDelay > 0) {
			reloadDelay--;
		}
		
		// when we have reloaded, we get the clip to its initial value
		if (reloadDelay <= 0 && reloading) {
			clip = CLIP_SIZE;
			reloading = false;
		}
	}
	
	// in case we click R
	public void reload() {
		reloadDelay = 20;
		reloading = true;
	}

	// getters and setters for the clip
	public int getClip() {
		return clip;
	}

	public void setClip(int clip) {
		this.clip = clip;
	}
	
	
}
