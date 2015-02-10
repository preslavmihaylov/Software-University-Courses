package _01_Geometry;

import java.util.ArrayList;
import java.util.List;

import _01_Geometry.Interfaces.Vertex;


public abstract class Shape {
	protected ArrayList<Vertex> vertices = new ArrayList<Vertex>();

	public List<Vertex> getVertices() {
		return vertices;
	}
	
	@Override
	public String toString() {
		String output = this.getClass().getSimpleName() + String.format("%n");
		output += "Vertices: " + this.vertices.toString() + String.format("%n");
		return output;
	}
}
