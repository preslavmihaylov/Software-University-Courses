import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class InputHandler implements KeyListener{
	
	public InputHandler(Game game){
		game.addKeyListener(this);
	}
	
	/***
	 * Handles the KeyPressed event and sets the snake velocity according to the key pressed
	 */
	public void keyPressed(KeyEvent e) {
		int keyCode = e.getKeyCode();
		
		if (keyCode == KeyEvent.VK_W || keyCode == KeyEvent.VK_UP) {
			if(Game.snake.getVelY() != 20){
				Game.snake.setVelX(0);
				Game.snake.setVelY(-20);
			}
		}
		if (keyCode == KeyEvent.VK_S || keyCode == KeyEvent.VK_DOWN) {
			if(Game.snake.getVelY() != -20){
				Game.snake.setVelX(0);
				Game.snake.setVelY(20);
			}
		}
		if (keyCode == KeyEvent.VK_D || keyCode == KeyEvent.VK_RIGHT) {
			if(Game.snake.getVelX() != -20){
			Game.snake.setVelX(20);
			Game.snake.setVelY(0);
			}
		}
		if (keyCode == KeyEvent.VK_A || keyCode == KeyEvent.VK_LEFT) {
			if(Game.snake.getVelX() != 20){
				Game.snake.setVelX(-20);
				Game.snake.setVelY(0);
			}
		}
		//Other controls
		if (keyCode == KeyEvent.VK_ESCAPE) {
			System.exit(0);
		}
	}
	
	public void keyReleased(KeyEvent e) {
	}
	
	public void keyTyped(KeyEvent e) {
		
	}

}
