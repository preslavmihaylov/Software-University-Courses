import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Scanner;


public class _01_VideoDurations {

	public static void main(String[] args) throws ParseException {
		Scanner scan = new Scanner(System.in);
		
		SimpleDateFormat sdf = new SimpleDateFormat("HH:mm");
		int hours = 0;
		int minutes = 0;
		
		while (true) {
			String input = scan.nextLine();
			if (input.equals("End")) {
				break;
			}
			
			Date currentTime = sdf.parse(input);
			
			hours += currentTime.getHours();
			minutes += currentTime.getMinutes();
		}
		
		hours += minutes / 60;
		minutes %= 60;
		String minutesOutput = "" + minutes;
		minutesOutput = String.format("%02d", Integer.parseInt(minutesOutput));
		
		System.out.println(hours + ":" + minutesOutput);
	}

}
