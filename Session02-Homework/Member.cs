using System;


namespace SerializeDeserializeXMLData
{
    [Serializable]
    public class Member
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime JoiningDate { get; set; }

    }
}
