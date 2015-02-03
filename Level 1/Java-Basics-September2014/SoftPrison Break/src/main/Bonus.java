package main;

import java.awt.Graphics;
import java.awt.Image;
import java.awt.Rectangle;
import java.util.Random;

import javax.swing.ImageIcon;

public class Bonus {
	int x;
	int y;
	int bonusDuration;
	int bonusType;
	Image bonusImage;
	
	Random randGenerator;
	
	public Bonus(int x, int y) {
		randGenerator = new Random();
		this.x = x;
		this.y = y;
		
		bonusType = randGenerator.nextInt(101);
		// if we don't collect the bonus, it will disappear in time
		bonusDuration = 90;
		loadBonusImage();
	}
	
	// visual part
	public void paint(Graphics g) {
		g.drawImage(bonusImage, x, y, null);
	}
	
	// the logic
	public void tick() {
		bonusDuration--;
		
		// we remove the bonus if the duration is over
		if (bonusDuration < 0) {
			Player.bonuses.remove(this);
		}
	}
	
	// helps out the collision detector
	public Rectangle getBounds(){
		return new Rectangle (this.x,this.y, bonusImage.getWidth(null), bonusImage.getHeight(null));
	}

	// in case we collect the bonus, we get the corresponding extras
	public void getBonus() {
		if (bonusType <= 10) {
			Sound.LIVES_BONUS.play();
			GamePanel.player.lives++;
		} else if (bonusType <= 80) {
			Sound.SCORE_BONUS.play();
			GamePanel.statistics.score += 100;
		} else {
			Sound.SLOW_BONUS.play(); 
			Enemy.enemySpeed -= 0.7;
		}
	}
	
	// according to the bonus type, we load a different image
	public void loadBonusImage() {
		ImageIcon ii;
		
		if (bonusType <= 10) {
			ii = new ImageIcon("res/Images/heart.png");
		} else if (bonusType <= 80) {
			ii = new ImageIcon("res/Images/money.png");
		} else {
			ii = new ImageIcon("res/Images/slow.png");
		}
		
		bonusImage = ii.getImage();
	}
}
