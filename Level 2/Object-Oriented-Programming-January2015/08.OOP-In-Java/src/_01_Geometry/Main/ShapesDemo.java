package _01_Geometry.Main;

import java.util.ArrayList;

import _01_Geometry.PlaneShape;
import _01_Geometry.Shape;
import _01_Geometry.Interfaces.VolumeMeasurable;
import _01_Geometry.PlaneShapes.Circle;
import _01_Geometry.PlaneShapes.Rectangle;
import _01_Geometry.PlaneShapes.Triangle;
import _01_Geometry.SpaceShapes.Cuboid;
import _01_Geometry.SpaceShapes.Sphere;
import _01_Geometry.SpaceShapes.SquarePyramid;
import _01_Geometry.Vertices.Vertex2D;
import _01_Geometry.Vertices.Vertex3D;

public class ShapesDemo {

	public static void main(String[] args) {
		ArrayList<Shape> shapes = new ArrayList<>();
		shapes.add(new Circle(new Vertex2D(1, 2), 3));
		shapes.add(new Circle(new Vertex2D(-1, 4), 6));
		shapes.add(new Circle(new Vertex2D(3, 7), 7));
		
		shapes.add(new Triangle(new Vertex2D(1, 2), new Vertex2D(3, 4), new Vertex2D(2, 2)));
		shapes.add(new Triangle(new Vertex2D(-1, 4), new Vertex2D(6, 5), new Vertex2D(3, 3)));
		shapes.add(new Triangle(new Vertex2D(3, 7), new Vertex2D(1, 8), new Vertex2D(4, 7)));
		
		shapes.add(new Rectangle(new Vertex2D(1, 2), 4, 3));
		shapes.add(new Rectangle(new Vertex2D(-1, 4), 5, 1));
		shapes.add(new Rectangle(new Vertex2D(3, 7), 8, 2));
		
		shapes.add(new Cuboid(new Vertex3D(1, 2, 5), 3, 5, 7));
		shapes.add(new Cuboid(new Vertex3D(-1, 4, 7), 6, 5, 7));
		shapes.add(new Cuboid(new Vertex3D(3, 7, 1), 7, 5, 7));
		
		shapes.add(new Sphere(new Vertex3D(3, 7, 1), 3));
		shapes.add(new Sphere(new Vertex3D(2, 1, -5), 2));
		shapes.add(new Sphere(new Vertex3D(7, 4, 3), 4));
		
		shapes.add(new SquarePyramid(new Vertex3D(3, 6, 3), 6, 5, 8));
		shapes.add(new SquarePyramid(new Vertex3D(7, 6, -2), 1, 1, 2));
		shapes.add(new SquarePyramid(new Vertex3D(1, 6, 2), 3, 5, 9));
		
		System.out.println("Volume measurable shapes filtered by volume greater than 40");
		
		shapes.stream()
		.filter(s -> s instanceof VolumeMeasurable)
		.filter(s -> ((VolumeMeasurable)s).getVolume() > 40)
		.forEach(s -> {
			System.out.println(s);
		});
		
		System.out.println();
		System.out.println("Plane shapes sorted by perimeter:");
		
		shapes.stream()
		.filter(s -> s instanceof PlaneShape)
		.sorted((s1, s2) -> {
			PlaneShape planeShape1 = (PlaneShape)s1;
			PlaneShape planeShape2 = (PlaneShape)s2;
			
			if (planeShape1.getPerimeter() > planeShape2.getPerimeter()) {
				return 1;
			} else if (planeShape1.getPerimeter() < planeShape2.getPerimeter()) {
				return -1;
			} else {
				return 0;
			}
		})
		.forEach(s -> {
			System.out.println(s);
		});
		
	}

}
