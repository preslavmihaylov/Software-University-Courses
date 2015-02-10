package _01_Geometry.Vertices;

import _01_Geometry.Interfaces.Vertex;

public class Vertex3D implements Vertex {
	private double x;
	private double y;
	private double z;
	
	public Vertex3D(double x, double y, double z) {
		this.setX(x);
		this.setY(y);
		this.setZ(z);
	}
	
	public double getX() {
		return x;
	}

	public void setX(double x) {
		this.x = x;
	}

	public double getY() {
		return y;
	}

	public void setY(double y) {
		this.y = y;
	}

	public double getZ() {
		return z;
	}

	public void setZ(double z) {
		this.z = z;
	}

	@Override
	public double calculateDistance(Vertex vertex) {
		Vertex3D vertex3d = (Vertex3D)vertex;
		
		double distance = Math.sqrt(Math.pow(this.getX() - vertex3d.getX(), 2) + 
				Math.pow(this.getY() - vertex3d.getY(), 2) + 
				Math.pow(this.getZ() - vertex3d.getZ(), 2));
		
		return distance;
	}

	@Override
	public String toString() {
		return "(" + this.getX() + ", " + this.getY() + this.getZ() + ")";
	}
}
