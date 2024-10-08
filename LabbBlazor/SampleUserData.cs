namespace LabbBlazor
{
    public class SampleUserData
    {
        public List<User> Users { get; private set; }
        public SampleUserData()
        {
            Users = new List<User>();
            Users.Add(new User(1, "Emma Johnson", "emma.johnson@example.com", "123 Oakwood Drive", "Seattle", 98109, "Horizon Solutions", "\"Innovating for a brighter tomorrow.\""));
            Users.Add(new User(2, "Michael Davis", "michael.davis@example.com", "456 Elm Street", "Austin", 78701, "Velocity Tech", "\"Accelerating digital transformation.\""));
            Users.Add(new User(3, "Sophia Lee", "sophia.lee@example.com", "789 Maple Avenue", "Chicago", 60616, "Peak Enterprises", "\"Reaching new heights in business.\""));
            Users.Add(new User(4, "James Wilson", "james.wilson@example.com", "321 Pine Lane", "Denver", 80203, "Quantum Innovations", "\"Pioneering the future of technology.\""));
            Users.Add(new User(5, "Olivia Martinez", "olivia.martinez@example.com", "654 Cedar Street", "San Francisco", 94107, "Stellar Designs", "\"Where creativity meets precision.\""));
            Users.Add(new User(6, "William Brown", "william.brown@example.com", "987 Birch Road", "Boston", 02115, "Apex Dynamics", "\"Engineering excellence, redefining limits.\""));
            Users.Add(new User(7, "Ava Taylor", "ava.taylor@example.com", "159 Chestnut Boulevard", "New York", 10001, "Summit Solutions", "\"Empowering growth through innovation.\""));
            Users.Add(new User(8, "Lucas Anderson", "lucas.anderson@example.com", "753 Spruce Drive", "Los Angeles", 90012, "Nova Systems", "\"Bringing ideas to life.\""));
            Users.Add(new User(9, "Mia Thompson", "mia.thompson@example.com", "468 Redwood Street", "Miami", 33130, "Vortex Industries", "\"Transforming industries with innovation.\""));
            Users.Add(new User(10, "Ethan White", "ethan.white@example.com", "247 Willow Way", "Houston", 77002, "Zenith Technologies", "\"Leading the way in tech evolution.\""));
            
        }
    }
}
