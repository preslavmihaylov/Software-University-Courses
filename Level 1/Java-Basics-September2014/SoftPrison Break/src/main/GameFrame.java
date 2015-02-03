package main;
import javax.swing.JFrame;


@SuppressWarnings("serial")
public class GameFrame extends JFrame{

	// constants for the width and height of the screen
	static final int WIDTH = 498;
	static final int HEIGHT = 684;
	static GamePanel game;
	
	public static void main(String[] args) {
		// creates the JFrame for our game
		new GameFrame();
		
	}
	
	public GameFrame() {
		// basics settings for the JFrame
		this.setSize(WIDTH, HEIGHT);
		this.setTitle("SoftPrison Break");
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLocationRelativeTo(null);
		this.setResizable(false);
		
		// We create JPanel and add it to our game
		game = new GamePanel();
		this.add(game);
		
		this.setVisible(true);
		// the main game loop
		gameLoop();
	}

	private void gameLoop() {
		while (true) {
			// the tick methods are responsible for the the logic of our game
			game.tick();
			// the repaint method invokes the paint(Graphics g) method in our game panel
			repaint();
			
			// we use a Thread sleep in order to set a constant speed for our game
			try {
				Thread.sleep(50);
			} catch (InterruptedException e) {
				
				e.printStackTrace();
			}
		}
		
	}

}
