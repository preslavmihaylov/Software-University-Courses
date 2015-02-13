import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;

public class Point {
	private int x, y;
	private final int WIDTH = 20;
	private final int HEIGHT = 20;
	
	public Point(Point p){
		this(p.x, p.y);
	}
	
	public Point(int x, int y){
		this.x = x;
		this.y = y;
	}	
		
	public int getX() {
		return x;
	}
	public void setX(int x) {
		this.x = x;
	}
	public int getY() {
		return y;
	}
	public void setY(int y) {
		this.y = y;
	}
	
	/***
	 * Draws a rectangle with constant dimensions on the current point's position
	 * @param g Contains the graphics object on which to draw the components
	 * @param color Contains the color of the object to be drawn
	 */
	public void draw(Graphics g, Color color) {
		g.setColor(Color.BLACK);
		g.fillRect(x, y, WIDTH, HEIGHT);
		g.setColor(color);
		g.fillRect(x+1, y+1, WIDTH-2, HEIGHT-2);		
	}
	
	public String toString() {
		return "[x=" + x + ",y=" + y + "]";
	}
	
	/***
	 * Checks whether the given object is of type Point and compares the dimensions of the given points
	 */
	public boolean equals(Object object) {
        if (object instanceof Point) {
            Point point = (Point)object;
            return (x == point.x) && (y == point.y);
        }
        return false;
    }
}
