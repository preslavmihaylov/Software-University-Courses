package _01_Geometry.SpaceShapes;

import _01_Geometry.SpaceShape;
import _01_Geometry.Interfaces.Vertex;
import _01_Geometry.Vertices.Vertex3D;

public class Sphere extends SpaceShape {
	private double radius;
	
	public Sphere(Vertex3D vertex, double radius) {
		super(vertex);
		
		this.setRadius(radius);
	}
	
	
	public double getRadius() {
		return radius;
	}


	private void setRadius(double radius) {
		this.radius = radius;
	}


	@Override
	public double getVolume() {
		return 4 * Math.PI * Math.pow(radius, 3) / 3;
	}

	@Override
	public double getArea() {
		return 4 * Math.PI * Math.pow(radius, 2);
	}

}
