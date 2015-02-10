package _01_Geometry.SpaceShapes;

import _01_Geometry.SpaceShape;
import _01_Geometry.Vertices.Vertex3D;

public class Cuboid extends SpaceShape {
	private double width;
	private double height;
	private double depth;
	
	public Cuboid(Vertex3D vertex3d, double width, double height, double depth) {
		super(vertex3d);
		this.setDepth(depth);
		this.setWidth(width);
		this.setHeight(height);
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



	public double getDepth() {
		return depth;
	}



	private void setDepth(double depth) {
		this.depth = depth;
	}



	@Override
	public double getVolume() {
		return this.width * this.height * this.depth;
	}

	@Override
	public double getArea() {
		return (this.width * this.height * 2) + 
				(this.width * this.depth * 2) + 
				(this.depth * this.height * 2);
	}
}
