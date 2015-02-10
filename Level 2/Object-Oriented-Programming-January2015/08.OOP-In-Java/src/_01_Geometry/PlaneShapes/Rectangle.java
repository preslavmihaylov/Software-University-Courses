package _01_Geometry.PlaneShapes;

import _01_Geometry.PlaneShape;
import _01_Geometry.Vertices.Vertex2D;

public class Rectangle extends PlaneShape {
	private double width;
	private double height;
	
	public Rectangle(Vertex2D vertex2d, double width, double height) {
		super(vertex2d);
		
		this.setWidth(width);
		this.setHeight(height);
	}
	
	public double getWidth() {
		return width;
	}

	public void setWidth(double width) {
		this.width = width;
	}

	public double getHeight() {
		return height;
	}

	public void setHeight(double height) {
		this.height = height;
	}

	@Override
	public double getPerimeter() {
		double perimeter = this.getWidth() * 2 + this.getHeight() * 2;
		return perimeter;
	}

	@Override
	public double getArea() {
		double area = this.getWidth() * this.getHeight();
		return area;
	}
}
