
import java.io.FileOutputStream;
import java.io.IOException;
 
import com.itextpdf.text.BaseColor;
import com.itextpdf.text.Document;
import com.itextpdf.text.DocumentException;
import com.itextpdf.text.Font;
import com.itextpdf.text.Phrase;
import com.itextpdf.text.pdf.BaseFont;
import com.itextpdf.text.pdf.PdfPCell;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;
 
public class Pr09GeneratePDF {
 
    /** Path to the resulting PDF file. */
    public static final String RESULT
        = "D:\\Programming\\Java-Basics-September2014\\01.IntroToJava\\deckofcards.pdf";
 
    public static void main(String[] args)
    	throws DocumentException, IOException {
    	new Pr09GeneratePDF().createPdf(RESULT);
    }
 
    public void createPdf(String filename)
	throws DocumentException, IOException {
        
        Document document = new Document();
      
        PdfWriter.getInstance(document, new FileOutputStream(filename));
        
        document.open();
        
        BaseFont baseFont = BaseFont.createFont("D:\\Programming\\Java-Basics-September2014\\01.IntroToJava\\times.ttf", BaseFont.IDENTITY_H, true);
        Font black = new Font(baseFont, 75, 0, BaseColor.BLACK);
        Font red = new Font(baseFont, 75, 0, BaseColor.RED);
        
        PdfPTable table = new PdfPTable(4);
        PdfPCell cell;
        
        char spade = '\u2660';
		char heart = '\u2665';
		char diamond = '\u2666';
		char club = '\u2663';
		boolean isBlack = false;
		
		for (int face = 1; face < 15; face++) {
			for (int suit = 0; suit < 4; suit++) {
				String output = "";
				
				switch (face) {
				case 11:
					output += "J";
					break;
				case 12:
					output += "Q";
					break;
				case 13:
					output += "K";
					break;
				case 14:
					output += "A";
					break;
				default:
					output += face;
					break;
				}
				
				output += "  ";
				switch (suit) {
				case 0:
					output += club;
					isBlack = true;
					break;
				case 1:
					output += diamond;
					isBlack = false;
					break;
				case 2:
					output += heart;
					isBlack = false;
					break;
				case 3:
					output += spade;
					isBlack = true;
					break;
				}
				
				if (isBlack) {
					cell = new PdfPCell(new Phrase(output, black));
					cell.setRowspan(2);
			        table.addCell(cell);
				}
				else {
					cell = new PdfPCell(new Phrase(output, red));
					cell.setRowspan(2);
			        table.addCell(cell);
				}
			}
			
		}
        
		document.add(table);
        document.close();
    }
}