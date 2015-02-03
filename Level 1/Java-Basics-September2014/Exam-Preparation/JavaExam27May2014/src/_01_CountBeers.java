import java.util.Scanner;


public class _01_CountBeers {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		
		int beers = 0;
		int stacks = 0;
		
		String[] info = new String[3];
		info = scan.nextLine().split(" ");
		
		while (!info[0].equals("End")) {
			if (info[1].equals("beers")) {
				beers += Integer.parseInt(info[0]);
			}
			else {
				stacks += Integer.parseInt(info[0]);
			}
			
			info = scan.nextLine().split(" ");
		}
		
		stacks += beers / 20;
		beers %= 20;
		System.out.println(stacks + " stacks + " + beers + " beers");
	}

}
