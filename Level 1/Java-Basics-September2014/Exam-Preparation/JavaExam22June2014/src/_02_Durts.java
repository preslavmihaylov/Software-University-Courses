import java.util.Scanner;


public class _02_Durts {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		int xCenter = scan.nextInt();
		int yCenter = scan.nextInt();
		
		int durtsSize = scan.nextInt();
		int inputCount = scan.nextInt();
		
		int x = 0;
		int y = 0;
				
		for (int count = 0; count < inputCount; count++) {
			x = scan.nextInt();
			y = scan.nextInt();
			
			boolean firstFigure = x >= xCenter - durtsSize && x <= xCenter + durtsSize
					&& y >= yCenter - durtsSize / 2 && y <= yCenter + durtsSize / 2;
					
			boolean secondFigure = x >= xCenter - durtsSize / 2 && x <= xCenter + durtsSize / 2
					&& y >= yCenter - durtsSize && y <= yCenter + durtsSize;
			
			if (firstFigure || secondFigure) {
				System.out.println("yes");
			} else {
				System.out.println("no");
			}
		}
	}

}
