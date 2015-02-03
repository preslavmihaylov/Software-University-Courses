package main;

import java.awt.Graphics;
import java.awt.Image;
import java.awt.event.KeyListener;
import java.util.ArrayList;
import java.util.Random;

import javax.swing.ImageIcon;
import javax.swing.JOptionPane;
import javax.swing.JPanel;


@SuppressWarnings("serial")
public class GamePanel extends JPanel {
	
	// initial variables, we declare them here in order to use them in every method of the class
	static Random randGenerator;
	static Player player;
	
	public static Statistics statistics;
	
	static Image background;
	
	public static ArrayList<Enemy> enemies;
	public static ArrayList<Bullet> bullets;
	public static int choice;
	
	public GamePanel() {
		// we initialize the variables
		Sound.START_GAME.play();
		
		// the Statistics class is responsible for the game statistics at the top of the screen
		statistics = new Statistics();
		
		/*here, we load the background, show the statistics
		at the start of the game and the character selection screen*/
		loadBackground();
		showInstructions();
		characterSelection();
		
		player = new Player();
		enemies = new ArrayList<>();
		bullets = new ArrayList<>();
		
		// we create the input handler
		KeyListener input = new InputHandler();
		addKeyListener(input);
		
		randGenerator = new Random();
		
		// we set the size of the panel according to the frame size and we make the panel focusable
		setSize(GameFrame.WIDTH, GameFrame.HEIGHT);
		setFocusable(true);
	}

	// this method is responsible for the visual part of our game
	public void paint(Graphics g) {
		// here, we clear the old elements of the screen
		super.paint(g);
		
		// the background for the game
		g.drawImage(background, 0, 0, null);
		
		/*for every bullet and enemy on the screen
		we invoke the paint method in the corresponding classes*/
		
		for (int i = 0; i < enemies.size(); i++) {
			enemies.get(i).paint(g);
		}
		
		for (int i = 0; i < bullets.size(); i++) {
			bullets.get(i).paint(g);
		}
		
		// the paint methods for the player and the statistics accordingly
		player.paint(g);
		statistics.paint(g);
		
	}
	
	// updates the logic of our  game
	public void tick() {
		
		/*the speed of the enemies increases constantly. 
		We access the variable statically in order to apply the changes for every enemy*/
		
		Enemy.enemySpeed += 0.0015;
		
		// on each step of our game there is a chance to spawn a new enemy
		if (randGenerator.nextInt(100) < 10 && !statistics.loading) {
			generateEnemies();
		}
		
		// the corresponding tick methods for the different components
		statistics.tick();
		player.tick();
		
		// if the bullet is out of bounds, we remove it
		for (int index = 0; index < bullets.size(); index++) {
			checkBulletOutOfBounds(index);
		}
		
		// if we hit an enemy, he dies... tragically.
		for (int index = 0; index < bullets.size(); index++) {
			checkEnemyKilled(bullets.get(index));
		}
		
		// if the enemy gets near the player, we get punched in the face.
		for (int i = 0; i < enemies.size(); i++) {
			enemies.get(i).tick();
			checkPlayerEnemiesCollision(enemies.get(i));
		}
		
		// this is obvious, isn't it?
		if (player.lives <= 0) {
			gameOver();
		}
	}

	// in case the bullet gets off the screen, we remove it
	private void checkBulletOutOfBounds(int index) {
		bullets.get(index).tick();
		if (bullets.get(index).getX() + 10 > GameFrame.WIDTH) {
			bullets.remove(index);
		}
	}
	
	// any enemies killed ?
	private void checkEnemyKilled(Bullet bullet) {
		for (int index = 0; index < GamePanel.enemies.size(); index++) {
			if (GamePanel.enemies.get(index).getBounds().intersects(bullet.getBounds())) {
				GamePanel.enemies.remove(GamePanel.enemies.get(index));
				player.bonusChance(bullet.getX(), bullet.getY());
				bullets.remove(bullet);
				statistics.score += 10;
				Sound.PLAYER_HIT.play();
			}
		}
		
	}
	
	// we get punched in the face.
	private void checkPlayerEnemiesCollision(Enemy enemy) {
		if (enemy.getBounds().intersects(player.getBounds())) {
			Sound.PLAYER_HIT.play();
			enemies.remove(enemy);
			player.lives--;
		}
		
	}

	// the algorithm for generating enemies. Note that they cannot spawn upon each other
	public void generateEnemies() {
		Enemy tempEnemy;
		
		do {
			tempEnemy = new Enemy(GameFrame.WIDTH + randGenerator.nextInt(300), 
					190 + randGenerator.nextInt(GameFrame.HEIGHT - 210
							- player.characterImage.getHeight(null)));
			
		} while (avoidEnemyIntersection(tempEnemy));
		
		enemies.add(tempEnemy);
		
		checkEnemyOutOfBounds();
		
	}

	// Attention! Enemies escaped!
	private void checkEnemyOutOfBounds() {
		for (int index = 0; index < enemies.size(); index++) {
			if (enemies.get(index).getX() < 0) {
				Sound.ENEMY_ESCAPED.play();
				enemies.remove(index);
				player.lives--;
			}
		}
		
	}
	
	// the method for avoiding the enemy to enemy collision
	private boolean avoidEnemyIntersection(Enemy tempEnemy) {
		for (Enemy enemy : enemies) {
			if (enemy.getBounds().intersects(tempEnemy.getBounds())) {
				return true;
			}
		}
		return false;
	}
	
	// the character selection at the start of the game
	private void characterSelection() {
		Object[] options = {"Nakov", "Deyan", "Angel"};
		
		choice = JOptionPane.showOptionDialog(null,
				"Choose your character", "Character selection", JOptionPane.YES_NO_CANCEL_OPTION,
						JOptionPane.PLAIN_MESSAGE, null, options, options[0]);
	}
	
	// the initial instructions
	private void showInstructions() {
		
		JOptionPane.showMessageDialog(this, "You are a warden of the famous SoftPrison.\n "
				+ "Your duty is not to let the miserable prisoners escape.\n"
				+ "Use all means necessary.\n"
				+ "Be careful though, they will attack you if they get near.\n" + 
		"\nW,A,S,D - Move character\n"
				+ "R - Reload\n"
				+ "Spacebar - Shoot", "Instructions", 
				JOptionPane.PLAIN_MESSAGE);
	}

	// yeah... the tragic end
	private void gameOver() {
		Sound.ENEMY_ESCAPED.stop();
		Sound.GAME_OVER.play();
		JOptionPane.showMessageDialog(this, "Your score is " + statistics.score,
			"Game Over", JOptionPane.YES_NO_OPTION);
		statistics.overwriteHighscore();
		System.exit(0);
	}
	
	// the image for the background
	private void loadBackground() {
		ImageIcon ii = new ImageIcon("res/Images/background.png");
		background = ii.getImage();
		
	}
}
