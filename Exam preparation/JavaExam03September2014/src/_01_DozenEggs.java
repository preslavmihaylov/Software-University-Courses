import java.util.Scanner;


public class _01_DozenEggs {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		
		int dozens = 0;
		int eggs = 0;
		
		for (int i = 0; i < 7; i++) {
			String[] input = scan.nextLine().split(" ");
			
			if (input[1].equals("eggs")) {
				eggs += Integer.parseInt(input[0]);
			} else {
				dozens += Integer.parseInt(input[0]);
			}
		}
		
		dozens += eggs / 12;
		eggs %= 12;
		
		System.out.println(dozens + " dozens + " + eggs + " eggs");
	}

}
