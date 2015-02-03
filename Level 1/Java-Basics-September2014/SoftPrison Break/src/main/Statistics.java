package main;

import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintWriter;

public class Statistics {


	public int score;
	static int highscore;
	public boolean loading = false;
	
	public Statistics() {
		// we read the highscore from a text file
		readHighScore();
		loading = false;
		score = 0;
	}
	
	// in case we get a new highscore. WOOHOO!
	public void tick() {
		if (highscore < score) {
			highscore = score;
		}
	}
	
	// we draw the statistics at the top of the screen.
	public void paint(Graphics g) {
		g.setColor(Color.RED);
		g.setFont(new Font("TimesRoman", Font.PLAIN, 30)); 
		g.drawString("Score" + " " + score, 10, 40);
		g.drawString("Highscore: " + highscore, GameFrame.WIDTH - 250, 40);
		g.drawString("Lives: " + GamePanel.player.lives, 10, 140);
		g.drawString("Ammo: " + GamePanel.player.ammo.getClip(), GameFrame.WIDTH - 220 , 140);
		
	}
	
	// we read the highscore from a text file
	private void readHighScore() {
		loading = true;
		
		BufferedReader reader = null;
		try {
			reader = new BufferedReader(new FileReader(
					"res/highscore.txt"));
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		}
		
		String line = null;
		
		try {
			while ((line = reader.readLine()) != null) {
			    highscore = Integer.parseInt(line);
			}
		} catch (NumberFormatException | IOException e) {
			e.printStackTrace();
		}
	}
	
	// we overwrite the new highscore to the textfile.
	public void overwriteHighscore() {
		
		PrintWriter out = null;
		try {
			out = new PrintWriter("res/highscore.txt");
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		}
		
		out.println(highscore);
		out.close();
		
	}
}
