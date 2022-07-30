namespace WorkerContracts.Entities
{
    public class HourContract
    {
        public DateTime Date { get; private set; }
        public double ValuePerHour { get; private set; }
        public int Hours { get; private set; }

        public HourContract(DateTime date, double valuePerHour, int hours)
        {
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hours;
        }

        public double TotalValue()
        {
            return ValuePerHour * Hours;
        }
    }
}
