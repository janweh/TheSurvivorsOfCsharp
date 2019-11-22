using System;


namespace WindowsFormsApp15.model
{
    public class University : Storable
    {
        private string universityName;

        /// <summary>
        /// Constructor for the class University without giving an ID.
        /// ID will be generated automatically.
        /// Should be used when creating a truly new object that is not yet stored.
        /// </summary>
        /// <param name="name">cannot be null</param>
        public University(string name)
        {
            WindowsFormsApp15.Data.DataSearch ds = new WindowsFormsApp15.Data.DataSearch();
            Init(name);
        }

        /// <summary>
        /// Constructs a new Entity of University from a line from the datafiles.
        /// Should only be used when creating objects from files!
        /// </summary>
        /// <param name="line"></param>
        public University(string[] line)
        {
            Init(line[1]);
        }

        public string UniversityName { get => universityName; }
        public override int ID { get; set; }

        private void Init(string name)
        {
            this.universityName = name ?? throw new ArgumentNullException("name cannot be null.");
        }

        /// <summary>
        /// Returns a string containing the objects properties in the format:
        /// "universityID;universityName".
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string info = ID.ToString() + ";" +
                UniversityName + "\n";
            return info;
        }

        public University() : base() { }
    }
}
