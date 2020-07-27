namespace Student_Task.Migrations
{
    using Student_Task.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Student_Task.SchoolModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Student_Task.SchoolModel context)
        {
            context.Neighborhoods.AddOrUpdate(
                new Neighborhood
                {
                    GovernorateId = 4,
                    Name = "حي محرم بيك"
                },
                new Neighborhood
                {
                    GovernorateId = 4,
                    Name = "حي سيدي جابر"
                },
                new Neighborhood
                {
                    GovernorateId = 4,
                    Name = "حي سيدي بشر"
                },
                new Neighborhood
                {
                    GovernorateId = 4,
                    Name = "حي سموحة"
                },
                new Neighborhood
                {
                    GovernorateId = 4,
                    Name = "حي بحري"
                },
                new Neighborhood
                {
                    GovernorateId = 3,
                    Name = "بسيون"
                },
                new Neighborhood
                {
                    GovernorateId = 3,
                    Name = "زفتي"
                },
                new Neighborhood
                {
                    GovernorateId = 3,
                    Name = "طنطا"
                },
                new Neighborhood
                {
                    GovernorateId = 3,
                    Name = "المحله"
                },
                new Neighborhood
                {
                    GovernorateId = 2,
                    Name = "منية النصر"
                },
                new Neighborhood
                {
                    GovernorateId = 2,
                    Name = "بانوب"
                },
                new Neighborhood
                {
                    GovernorateId = 2,
                    Name = "كوم النور"
                },
                new Neighborhood
                {
                    GovernorateId = 2,
                    Name = "شاوة"
                }
            );

            context.Students.AddOrUpdate(
                new Student { 
                    Name = "Ahmed Mostafa",
                    BirthDate = Convert.ToDateTime("12/4/2001"),
                    FieldId = 1,
                    GovernorateId = 1,
                    NeighborhoodId = 2
                },
                new Student
                {
                    Name = "Safwet Mansour",
                    BirthDate = Convert.ToDateTime("7/31/2001"),
                    FieldId = 2,
                    GovernorateId = 4,
                    NeighborhoodId = 3
                },
                new Student
                {
                    Name = "Tamer Saleh",
                    BirthDate = Convert.ToDateTime("9/23/2001"),
                    FieldId = 2,
                    GovernorateId = 3,
                    NeighborhoodId = 8
                },
                new Student
                {
                    Name = "Slama Mohamed",
                    BirthDate = Convert.ToDateTime("12/5/2001"),
                    FieldId = 1,
                    GovernorateId = 2,
                    NeighborhoodId = 15
                },
                new Student
                {
                    Name = "Hady Slama",
                    BirthDate = Convert.ToDateTime("12/18/2002"),
                    FieldId = 1,
                    GovernorateId = 1,
                    NeighborhoodId = 1
                },
                new Student
                {
                    Name = "Hanan Mostafa",
                    BirthDate = Convert.ToDateTime("1/2/2002"),
                    FieldId = 2,
                    GovernorateId = 3,
                    NeighborhoodId = 9
                },
                new Student
                {
                    Name = "Mona El Sayed",
                    BirthDate = Convert.ToDateTime("10/4/2002"),
                    FieldId = 1,
                    GovernorateId = 4,
                    NeighborhoodId = 4
                }
            );
        }
    }
}
