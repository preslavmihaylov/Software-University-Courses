import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;


public class Apple {
	public static Random randGenerator;
	private Point applePoint;
	private Color snakeColor;
	
	public Apple(Snake snake) {
		applePoint = createApple(snake);
		snakeColor = Color.RED;		
	}
	
	/***
	 * Creates an apple on a random position
	 * @param snake The snake is used to check whether the new positions will be contained in the snake body
	 * @return a new Point with the coordinates of the apple
	 */
	private Point createApple(Snake snake) {
		randGenerator = new Random();
		int x = randGenerator.nextInt(30) * 20; 
		int y = randGenerator.nextInt(30) * 20;
		for (Point snakePoint : snake.snakeBody) {
			if (x == snakePoint.getX() || y == snakePoint.getY()) {
				return createApple(snake);				
			}
		}
		return new Point(x, y);
	}
	
	public void draw(Graphics g){
		applePoint.draw(g, snakeColor);
	}	
	
	public Point getPoint(){
		return applePoint;
	}
}
