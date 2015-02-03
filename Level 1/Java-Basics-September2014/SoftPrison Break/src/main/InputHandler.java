package main;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;


public class InputHandler implements KeyListener {

	// we invoke the player's key pressed and released methods
	@Override
	public void keyPressed(KeyEvent key) {

		GamePanel.player.keyPressed(key);
		
	}

	@Override
	public void keyReleased(KeyEvent key) {

		GamePanel.player.keyReleased(key);
	}

	@Override
	public void keyTyped(KeyEvent arg0) {

	}

}
