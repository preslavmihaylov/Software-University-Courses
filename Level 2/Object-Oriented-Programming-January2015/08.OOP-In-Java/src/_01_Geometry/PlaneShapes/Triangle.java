package _01_Geometry.PlaneShapes;

import _01_Geometry.PlaneShape;
import _01_Geometry.Vertices.Vertex2D;

public class Triangle extends PlaneShape {
	private double a;
	private double b;
	private double c;
	
	public Triangle(Vertex2D first, Vertex2D second, Vertex2D third) {
		super(first, second, third);
		this.setA(first.calculateDistance(second));
		this.setB(second.calculateDistance(third));
		this.setC(third.calculateDistance(first));
	}
	
	public double getA() {
		return a;
	}

	public void setA(double a) {
		this.a = a;
	}

	public double getB() {
		return b;
	}

	public void setB(double b) {
		this.b = b;
	}

	public double getC() {
		return c;
	}

	public void setC(double c) {
		this.c = c;
	}

	@Override
	public double getPerimeter() {
		return this.getA() + this.getB() + this.getC();
	}

	@Override
	public double getArea() {
		double halfPerimeter = this.getPerimeter() / 2;
		
		double area = Math.sqrt(halfPerimeter * 
				(halfPerimeter - this.getA()) * 
				(halfPerimeter - this.getB()) * 
				(halfPerimeter - this.getC()));
		
		return area;
	}
}
