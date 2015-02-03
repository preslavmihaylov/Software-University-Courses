package main;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.Rectangle;
import java.awt.event.KeyEvent;
import java.util.ArrayList;
import java.util.Random;

import javax.swing.ImageIcon;


public class Player {
	int x;
	int y;
	
	// the variables responsible for player movement.
	int velX = 0;
	int velY = 0;
	
	// the delay between our shots.
	int shootDelay = 0;
	Random randGenerator;
	
	public int lives;
	
	// the speed of our character.
	int speed = 14;
	Image characterImage;
	
	// our ammo and the bonuses on the screen.
	Ammunition ammo;
	public static ArrayList<Bonus> bonuses;
	
	public Player() {
		x = 15;
		y = 250;
		
		lives = 5;
		randGenerator = new Random();
		
		ammo = new Ammunition();
		bonuses = new ArrayList<>();
		loadCharacterImage();
	}
	
	// updates the logic of the player
	public void tick() {
		x += velX;
		y += velY;
		
		ammo.tick();
		
		// updates the shoot delay.
		if (shootDelay > 0) {
			shootDelay -= 1;
		}
		
		// we invoke the tick methods for each of the bonuses on the screen.
		for (int i = 0; i < bonuses.size(); i++) {
			bonuses.get(i).tick();
		}
		
		checkBonusCollection();
		checkOutOfBounds();
	}

	// the visual part
	public void paint(Graphics g) {
		g.setColor(Color.RED);
		g.drawImage(characterImage, x, y, null);
		
		// we draw the bonus images as well.
		for (int i = 0; i < bonuses.size(); i++) {
			bonuses.get(i).paint(g);
		}
	}
	
	// in case we collect a bonus.
	private void checkBonusCollection() {
		for (int index = 0; index < bonuses.size(); index++) {
			if (this.getBounds().intersects(bonuses.get(index).getBounds())) {
				bonuses.get(index).getBonus();
				bonuses.remove(index);
			}
		}
	}

	// we generate a bonus if we are lucky when we kill an enemy.
	public void bonusChance(int x, int y) {
		int chance = randGenerator.nextInt(100);
		if (chance <= 5) {
			bonuses.add(new Bonus(x, y));
		}
		
	}

	// the player cannot get off the screen.
	private void checkOutOfBounds() {
		if (x <= 0) {			
			x = 0;			
		}
		if (y <= 170) {			
			y = 170; 
		}
		if (x >= GameFrame.WIDTH - characterImage.getWidth(null)) {
			x = GameFrame.WIDTH - characterImage.getWidth(null);
		}
		if (y >= GameFrame.HEIGHT - characterImage.getHeight(null)) {
			y = GameFrame.HEIGHT - characterImage.getHeight(null);
		}
	}
	
	// the keyPressed method for the player. It is invoked by the input handler.
	public void keyPressed(KeyEvent e){
		int key = e.getKeyCode();
		
		if (key == KeyEvent.VK_W ) { // W - move forward
			velY = -speed;
		} else if (key == KeyEvent.VK_S) { // S - move down
			velY = speed;
		} else if (key == KeyEvent.VK_A) { // A - move left
			velX = -speed;
		} else if(key == KeyEvent.VK_D){ // D - move right
			velX = speed;
			
		} else if (key == KeyEvent.VK_R) { // R - reload
			if (ammo.reloadDelay <= 0) {
				Sound.RELOAD.play();
				ammo.reload();
			}
			
		} else if (key == KeyEvent.VK_SPACE && shootDelay == 0 // Space - shoot
				&& ammo.getClip() > 0 && !ammo.reloading) {
			Sound.SHOOT.play();
			
			// in case we have selected Deyan, the bullet gets out from the pistol at the top of the image.
			if (GamePanel.choice != 1) {
				GamePanel.bullets.add(new Bullet(x + characterImage.getWidth(null), y
					+ characterImage.getHeight(null) / 2));
			} else {
				GamePanel.bullets.add(new Bullet(x + characterImage.getWidth(null), y
						+ characterImage.getHeight(null) / 5 - 5));
			}
			
			// we lose some ammo when we shoot.
			ammo.setClip(ammo.getClip() - 1);
			shootDelay = 4;
			
		}
	}
	
	// when we release the key, the player stops.
	public void keyReleased(KeyEvent e){
			
		int key = e.getKeyCode();
		
		if (key == KeyEvent.VK_W) {
			velY = 0;
		}
		else if (key == KeyEvent.VK_S){
			velY = 0;
		}
		else if (key == KeyEvent.VK_A){
			velX = 0;
		}
		else if(key == KeyEvent.VK_D){
			velX = 0;
		}
		
   }
		
	// we load the image of our player
	private void loadCharacterImage() {
		ImageIcon ii;
		
		if (GamePanel.choice == 0) {
			ii = new ImageIcon("res/Images/nakov.png");
		} else if (GamePanel.choice == 1) {
			ii = new ImageIcon("res/Images/deyan.png");
		} else {
			ii = new ImageIcon("res/Images/angel.png");
		}
		
	    characterImage = ii.getImage();
	}
	
	// helps out the collision detection
	public Rectangle getBounds(){
		return new Rectangle (this.x,this.y,
				characterImage.getWidth(null), characterImage.getHeight(null));
	}
	
}

