import java.util.Scanner;


public class Pr06SumTwoNumbers {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		
		int num1 = Integer.parseInt(scan.nextLine());
		int num2 = Integer.parseInt(scan.nextLine());
		
		scan.close();
		
		System.out.println(num1 + num2);
	}
}