package _01_Geometry;

import _01_Geometry.Interfaces.AreaMeasurable;
import _01_Geometry.Interfaces.VolumeMeasurable;
import _01_Geometry.Vertices.Vertex3D;

public abstract class SpaceShape extends Shape 
	implements AreaMeasurable, VolumeMeasurable {
	
	public SpaceShape(Vertex3D... vertices) {
		for (Vertex3D vertex3d : vertices) {
			this.vertices.add(vertex3d);
		}
	}

	@Override
	public abstract double getVolume();

	@Override
	public abstract double getArea();
	
	@Override
	public String toString() {
		String output = super.toString();
		output += "Volume: " + this.getVolume() + String.format("%n");
		output += "Area: " + this.getArea() + String.format("%n");
		
		return output;
	}
}
