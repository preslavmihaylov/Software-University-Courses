package _01_Geometry;

import _01_Geometry.Interfaces.AreaMeasurable;
import _01_Geometry.Interfaces.PerimeterMeasurable;
import _01_Geometry.Vertices.Vertex2D;

public abstract class PlaneShape extends Shape 
	implements AreaMeasurable, PerimeterMeasurable {

	protected PlaneShape(Vertex2D... vertices) {
		for (Vertex2D vertex2d : vertices) {
			this.vertices.add(vertex2d);	
		}
		// TODO Auto-generated constructor stub
	}

	@Override
	public abstract double getPerimeter();

	@Override
	public abstract double getArea();
	
	@Override
	public String toString() {
		String output = super.toString();
		output += "Perimeter: " + this.getPerimeter() + String.format("%n");
		output += "Area: " + this.getArea() + String.format("%n");
		
		return output;
	}
}
