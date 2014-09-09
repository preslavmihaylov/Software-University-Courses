package JavaSyntax;

import java.awt.Dimension;
import java.awt.Rectangle;
import java.awt.Graphics2D;
import java.awt.Color;
import java.awt.geom.Ellipse2D;
import java.io.Writer;
import java.io.OutputStreamWriter;
import java.io.IOException;

import javafx.scene.shape.Ellipse;
import javafx.scene.shape.Shape;

import org.apache.batik.svggen.GenericImageHandler;
import org.apache.batik.svggen.ImageHandlerPNGEncoder;
import org.apache.batik.svggen.SVGGeneratorContext;
import org.apache.batik.svggen.SVGGraphics2D;
import org.apache.batik.dom.GenericDOMImplementation;
import org.w3c.dom.Document;
import org.w3c.dom.DOMImplementation;

public class Pr10PaintHouseAsSVG {

    public void paint(Graphics2D g2d) {
        g2d.setPaint(Color.red);
        g2d.fill(new Rectangle(10, 10, 100, 100));
    }

    public static void main(String[] args) throws IOException {

        // Get a DOMImplementation.
        DOMImplementation domImpl =
            GenericDOMImplementation.getDOMImplementation();

        // Create an instance of org.w3c.dom.Document.
        String svgNS = "http://www.w3.org/2000/svg";
        Document document = domImpl.createDocument(svgNS, "svg", null);
        
        SVGGraphics2D g = new SVGGraphics2D(document);

        // Do some drawing.
        Ellipse circle = new Ellipse(0, 0, 50, 50);
        g.setPaint(Color.red);
        g.fill((java.awt.Shape) circle);
        g.translate(60, 0);
        g.setPaint(Color.green);
        g.fill((java.awt.Shape) circle);
        g.translate(60, 0);
        g.setPaint(Color.blue);
        g.fill((java.awt.Shape) circle);
        g.setSVGCanvasSize(new Dimension(180, 50));
        //test.paint(svgGenerator);

        // Finally, stream out SVG to the standard output using
        // UTF-8 encoding.
        boolean useCSS = true; // we want to use CSS style attributes
        Writer out = new OutputStreamWriter(System.out, "UTF-8");
        //svgGenerator.stream(out, useCSS);
    }
}
