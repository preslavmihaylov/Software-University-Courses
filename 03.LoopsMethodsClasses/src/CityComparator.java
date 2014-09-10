import java.util.Comparator;


public class CityComparator implements Comparator<Income>
{
    public int compare(Income in1, Income in2)
    {
       return in1.getCity().compareTo(in2.getCity());
   }
}
