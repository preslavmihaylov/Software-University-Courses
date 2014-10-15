import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;


public class _07_DaysBetweenTwoDates {

	public static void main(String[] args) throws ParseException {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		Date[] dates = new Date[2];
		
		SimpleDateFormat format = new SimpleDateFormat("dd-MM-yyyy");
		
		for (int inputs = 0; inputs < 2; inputs++) {
			String input = scan.next();
			dates[inputs] = format.parse(input);
		}
		
		long diff = dates[1].getTime() - dates[0].getTime();
		long diffDays = diff / (24 * 60 * 60 * 1000);
		
		System.out.println(diffDays);
	}

}
