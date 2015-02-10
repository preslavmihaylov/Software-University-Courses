package _01_Geometry.PlaneShapes;

import _01_Geometry.PlaneShape;
import _01_Geometry.Vertices.Vertex2D;

public class Circle extends PlaneShape {
	private double radius;
	
	public Circle(Vertex2D vertex2d, double radius) {
		super(vertex2d);
		this.setRadius(radius);
	}
	
	public double getRadius() {
		return radius;
	}

	private void setRadius(double radius) {
		this.radius = radius;
	}

	@Override
	public double getPerimeter() {
		double perimeter = this.radius * Math.PI * 2;
		return perimeter;
	}

	@Override
	public double getArea() {
		double area = Math.pow(this.radius, 2) * Math.PI;
		return area;
	}
}
