import java.io.FileInputStream;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.ss.usermodel.Sheet;
import org.apache.poi.ss.usermodel.Workbook;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

public class _11_Excel {
	
	static List<Income> incomes = new ArrayList<Income>();
	
	public static void main(String[] args) throws IOException {
		
			// open the required excel file from the homework assignment. 
			
			// Change the path according to your file location
			String fileName = "_11_Excel.xlsx";
		    FileInputStream inputStream = new FileInputStream(fileName); 
		    
		    // create some POI variables which will be used to read info from the excel file
		    Workbook workbook = new XSSFWorkbook(inputStream);
		    Sheet sheet = workbook.getSheetAt(0);
		    Row row;
		    Cell city;
		    Cell income;
		    
		    // go through the necessary rows and cols and get the information you want
		    for (int i = 1; i <= 12; i++) {
				row = sheet.getRow(i);
				if (row != null) {
					city = row.getCell(0);
					income = row.getCell(5);
					
					// use the generated method to check whether the current info
					// is contained in the list
					checkIfListContainsValue(city.getStringCellValue(),
							income.getNumericCellValue());
				}
			}
		    
		    // use the Collections.sort method as well as the generated class
		    // CityComparator to sort Strings in an object such as Income
		    Collections.sort(incomes, new CityComparator());
		    
		    // calculate the total incomes and print the required information on the console
		    double totalIncomes = 0;
		    
		    for (Income element : incomes) {
				System.out.print(element.getCity() + " Total --> ");
				System.out.printf("%.2f", element.getValue());
				System.out.println();
				totalIncomes += element.getValue();
			}
		    
		    System.out.print("Grand Total --> ");
		    System.out.printf("%.2f", totalIncomes);
		    
	}

	private static void checkIfListContainsValue(String cityName, double value) {
		
		boolean contained = false;
		int listIndex = 0;
		
		for (int index = 0; index < incomes.size(); index++) {
			if (incomes.get(index).getCity().equals(cityName)) {
				contained = true;
				listIndex = index;
				break;
			}
		}
		
		if (contained) {
			incomes.get(listIndex).setValue(
					incomes.get(listIndex).getValue() + value);
		}
		else {
			incomes.add(new Income());
			incomes.get(incomes.size() - 1).setCity(cityName);
			incomes.get(incomes.size() - 1).setValue(value);
		}
		
	}
}
