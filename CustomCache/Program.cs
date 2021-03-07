namespace CustomCache
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessManager businessManager = new BusinessManager();
            //businessManager.GetAllDbStudents();
            //businessManager.UpdateDbStudent();
            businessManager.TaskDbStudentCache();
        }
    }
}
