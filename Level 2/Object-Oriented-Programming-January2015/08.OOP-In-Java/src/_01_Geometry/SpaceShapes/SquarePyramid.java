package _01_Geometry.SpaceShapes;

import _01_Geometry.SpaceShape;
import _01_Geometry.Vertices.Vertex3D;

public class SquarePyramid extends SpaceShape {
	private double width;
	private double height;
	private double triangleHeight;
	
	public SquarePyramid(Vertex3D vertex3d, double width, double height, double triangleHeight) {
		super(vertex3d);
		this.setWidth(width);
		this.setHeight(height);
		this.setTriangleHeight(triangleHeight);
	}
	
	public double getWidth() {
		return width;
	}

	private void setWidth(double width) {
		this.width = width;
	}

	public double getHeight() {
		return height;
	}

	private void setHeight(double height) {
		this.height = height;
	}

	public double getTriangleHeight() {
		return triangleHeight;
	}

	private void setTriangleHeight(double triangleHeight) {
		this.triangleHeight = triangleHeight;
	}

	@Override
	public double getVolume() {
		return this.width * this.width * this.height / 3;
	}

	@Override
	public double getArea() {
		double baseArea = this.width * this.width;
		double triangleArea = this.width * this.triangleHeight / 2;
		
		return baseArea + 4 * triangleArea;
	}

}
