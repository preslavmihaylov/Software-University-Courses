import java.util.Scanner;


public class _01_Timespan {
	
	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		String[] input = scan.nextLine().split(":");
		
		int hours = Integer.parseInt(input[0]);
		int minutes = Integer.parseInt(input[1]);
		int seconds = Integer.parseInt(input[2]);
		
		input = scan.nextLine().split(":");
		
		hours -= Integer.parseInt(input[0]);
		minutes -= Integer.parseInt(input[1]);
		seconds -= Integer.parseInt(input[2]);
		
		while (seconds < 0) {
			minutes--;
			seconds += 60;
		}
		
		while (seconds > 60) {
			minutes++;
			seconds -= 60;
		}
		
		while (minutes < 0) {
			hours--;
			minutes += 60;
		}
		
		while (minutes > 60) {
			hours++;
			minutes -= 60;
		}
		
		System.out.printf("%d:%02d:%02d", hours, minutes, seconds);
	}
}
