package _01_Geometry.Vertices;

import _01_Geometry.Interfaces.Vertex;

public class Vertex2D implements Vertex {
	private double x;
	private double y;
	
	public Vertex2D(double x, double y) {
		this.setX(x);
		this.setY(y);
	}

	@Override
	public double getX() {
		return this.x;
	}
	
	private void setX(double x) {
		this.x = x;
	}

	@Override
	public double getY() {
		return this.y;
	}
	
	private void setY(double y) {
		this.y = y;
	}

	@Override
	public double calculateDistance(Vertex vertex) {
		Vertex2D vertex2d = (Vertex2D)vertex;
		
		double distance = Math.sqrt(Math.pow(this.getX() - vertex2d.getX(), 2) + 
				Math.pow(this.getY() - vertex2d.getY(), 2));
		
		return distance;
	}
	
	@Override
	public String toString() {
		return "(" + this.getX() + ", " + this.getY() + ")";
	}

}
