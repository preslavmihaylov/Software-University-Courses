package main;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.Rectangle;

import javax.swing.ImageIcon;


public class Enemy {
	// initial variables.
	private int x;
	private int y;
	static double enemySpeed = 5;
	static Image enemyImage;
	
	public Enemy(int x, int y) {
		this.x = x;
		this.y = y;
		
		enemyImage();
	}
	
	// the update of the logic of the enemy
	public void tick() {
		x -= (int)enemySpeed;
	}
	
	// paint the image on the screen
	public void paint(Graphics g) {
		g.drawImage(enemyImage, x, y, null);
	}
	
	// method which helps out the collision detection
	public Rectangle getBounds() {
		return new Rectangle(this.x, this.y, enemyImage.getWidth(null), enemyImage.getHeight(null));
	}
	
	// getter for X
	public int getX() {
		return x;
	}
	
	// the enemy image
	private void enemyImage(){
		
		ImageIcon ii = new ImageIcon("res/Images/enemy.png");
		enemyImage = ii.getImage();
		
	}
}
