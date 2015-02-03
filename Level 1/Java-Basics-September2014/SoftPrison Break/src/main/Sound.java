package main;

import java.applet.Applet;
import java.applet.AudioClip;

public class Sound {
	// the audio clips for the game. Note that the folder with the sounds must be in the build path
	public static final AudioClip START_GAME = Applet.newAudioClip
			(Sound.class.getResource("/ThereIsARiot.wav"));
	public static final AudioClip SHOOT = Applet.newAudioClip
			(Sound.class.getResource("/shoot.wav"));
	public static final AudioClip RELOAD = Applet.newAudioClip
			(Sound.class.getResource("/gunReload.wav"));
	public static final AudioClip GAME_OVER = Applet.newAudioClip
			(Sound.class.getResource("/GameOver.wav"));
	public static final AudioClip ENEMY_ESCAPED = Applet.newAudioClip
			(Sound.class.getResource("/yay.wav"));
	public static final AudioClip PLAYER_HIT = Applet.newAudioClip
			(Sound.class.getResource("/playerHit.wav"));
	public static final AudioClip LIVES_BONUS = Applet.newAudioClip
			(Sound.class.getResource("/lives.wav"));
	public static final AudioClip SLOW_BONUS = Applet.newAudioClip
			(Sound.class.getResource("/slow.wav"));
	public static final AudioClip SCORE_BONUS = Applet.newAudioClip
			(Sound.class.getResource("/money.wav"));
	
}
