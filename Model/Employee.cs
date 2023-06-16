namespace Model
{
    public class Employee
    {
        private static Employee instance;
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Username { get; set; }
        public UserType UserType { get; set; }

        public static Employee GetInstance()
        {
            if (instance == null)
            {
                instance = new Employee();
            }
            return instance;
        }

        private Employee(){}
    }
}